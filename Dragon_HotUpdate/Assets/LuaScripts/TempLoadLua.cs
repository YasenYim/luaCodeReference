using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LuaTextAsset
{
    public string luaName;
    public TextAsset textAsset;
}

public class TempLoadLua : MonoBehaviour
{
    public List<LuaTextAsset> luaList;

    private void Awake()
    {
        foreach (var lua in luaList)
        {
            GameSys.Instance.AddLuaSource(lua.luaName, lua.textAsset.text);
        }
    }
}
