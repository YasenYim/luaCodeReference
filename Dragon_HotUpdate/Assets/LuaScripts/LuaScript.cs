/*
 * Tencent is pleased to support the open source community by making xLua available.
 * Copyright (C) 2016 THL A29 Limited, a Tencent company. All rights reserved.
 * Licensed under the MIT License (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
 * http://opensource.org/licenses/MIT
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XLua;
using System;
using UnityEngine.AddressableAssets;

[System.Serializable]
public class Reference
{
    public string name;
    public GameObject value;
}

[LuaCallCSharp]
public class LuaScript : MonoBehaviour
{
    public string luaName;

    public Reference[] injections;

    internal static float lastGCTime = 0;
    internal const float GCInterval = 1;//1 second 

    private Action luaAwake;
    private Action luaStart;
    private Action luaUpdate;
    private Action luaOnDestroy;
    private Action<Collision> luaOnCollisionEnter;
    private Action<Collider> luaOnTriggerEnter;
    private Action<Collision2D> luaOnCollisionEnter2D;
    private Action<Collider2D> luaOnTriggerEnter2D;

    private LuaTable scriptEnv;

    public void Init(string luaName, Reference[] injections=null)
    {
        scriptEnv = GameSys.luaEnv.NewTable();

        // 为每个脚本设置一个独立的环境，可一定程度上防止脚本间全局变量、函数冲突
        LuaTable meta = GameSys.luaEnv.NewTable();
        meta.Set("__index", GameSys.luaEnv.Global);
        scriptEnv.SetMetaTable(meta);
        meta.Dispose();

        scriptEnv.Set("self", this);
        foreach (var injection in injections)
        {
            scriptEnv.Set(injection.name, injection.value);
        }

        string luaSource = GameSys.Instance.GetLuaSource(luaName);
        GameSys.luaEnv.DoString(luaSource, luaName, scriptEnv);

        scriptEnv.Get("awake", out luaAwake);
        scriptEnv.Get("start", out luaStart);
        scriptEnv.Get("update", out luaUpdate);
        scriptEnv.Get("ondestroy", out luaOnDestroy);
        scriptEnv.Get("oncollisionenter", out luaOnCollisionEnter);
        scriptEnv.Get("ontriggerenter", out luaOnTriggerEnter);
        scriptEnv.Get("oncollisionenter2d", out luaOnCollisionEnter2D);
        scriptEnv.Get("ontriggerenter2d", out luaOnTriggerEnter2D);

        // 将自身注册到GameSys里
        GameSys.Instance.AddLuaEnv(gameObject.GetInstanceID(), luaName, scriptEnv);
    }

    [LuaCallCSharp]
    public LuaTable GetLua(string name)
    {
        //Debug.Log("GetLua " + name);
        return GameSys.Instance.GetLuaEnv(gameObject.GetInstanceID(), name);
    }

    void Awake()
    {
        Init(luaName, injections);

        if (luaAwake != null)
        {
            luaAwake();
        }
    }

    // Use this for initialization
    void Start()
    {
        if (luaStart != null)
        {
            luaStart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (luaUpdate != null)
        {
            luaUpdate();
        }
        if (Time.time - lastGCTime > GCInterval)
        {
            GameSys.luaEnv.Tick();
            lastGCTime = Time.time;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (luaOnCollisionEnter != null)
        {
            luaOnCollisionEnter(collision);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (luaOnTriggerEnter != null)
        {
            luaOnTriggerEnter(other);
        }
    }

    void OnDestroy()
    {
        if (luaOnDestroy != null)
        {
            luaOnDestroy();
        }
        luaOnDestroy = null;
        luaUpdate = null;
        luaStart = null;
        luaOnCollisionEnter = null;
        luaOnCollisionEnter2D = null;
        luaOnTriggerEnter = null;
        luaOnTriggerEnter2D = null;
        scriptEnv.Dispose();
        injections = null;

        GameSys.Instance.RemoveLuaEnv(gameObject.GetInstanceID(), luaName);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (luaOnCollisionEnter2D != null)
        {
            luaOnCollisionEnter2D(collision);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (luaOnTriggerEnter2D != null)
        {
            luaOnTriggerEnter2D(collision);
        }
    }
}
