using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class GameSys
{
    Dictionary<int, Dictionary<string, LuaTable>> dictLuaEnvs = new Dictionary<int, Dictionary<string, LuaTable>>();
    Dictionary<string, string> dictLuaSources = new Dictionary<string, string>();

    private static LuaEnv _luaEnv;
    public static LuaEnv luaEnv
    {
        get
        {
            if (_luaEnv == null)
            {
                _luaEnv = new LuaEnv();
            }
            return _luaEnv;
        }
    }

    private static GameSys instance;
    public static GameSys Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameSys();
            }
            return instance;
        }
    }

    public void AddLuaEnv(int id, string name, LuaTable table)
    {
        if (!dictLuaEnvs.ContainsKey(id))
        {
            dictLuaEnvs[id] = new Dictionary<string, LuaTable>();
        }
        dictLuaEnvs[id].Add(name, table);
    }

    public LuaTable GetLuaEnv(int id, string name)
    {
        Debug.Log($"GetLuaEnv {id} {name}");
        return dictLuaEnvs[id][name];
    }

    public bool RemoveLuaEnv(int id, string name)
    {
        return dictLuaEnvs[id].Remove(name);
    }

    public void AddLuaSource(string luaName, string source)
    {
        dictLuaSources.Add(luaName, source);
    }

    public string GetLuaSource(string luaName)
    {
        return dictLuaSources[luaName];
    }


}
