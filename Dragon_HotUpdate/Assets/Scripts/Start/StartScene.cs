using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;

public class StartScene : MonoBehaviour
{
    public AudioClip startSound;    // 开始按钮音效

    AudioSource audioSource;

    public List<string> assetNames;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnStartButton()
    {
        // 播放音效
        audioSource.clip = startSound;
        audioSource.Play();

        // 开启协程
        StartCoroutine(CoGameStart());
    }

    IEnumerator CoGameStart()
    {
        GameObject btn = GameObject.Find("开始按钮");
        // 开始按钮闪烁
        for (int i=0; i<6; i++)
        {
            // 隐藏->显示   显示->隐藏
            btn.SetActive(!btn.activeInHierarchy);
            yield return new WaitForSeconds(0.3f);
        }

        // 加载资源
        yield return Addressables.LoadAssetsAsync<GameObject>(assetNames, null, Addressables.MergeMode.Union);

        var luas = Addressables.LoadAssetsAsync<TextAsset>(new List<string> { "PlayerCha.lua", "PlayerController.lua" }, null
            , Addressables.MergeMode.Union);

        yield return luas;
        // 等待加载完毕

        foreach (var textAsset in luas.Result)
        {
            Debug.Log("加载Lua成功 " + textAsset.name);
            GameSys.Instance.AddLuaSource(textAsset.name, textAsset.text);
        }


        // 切换场景
        Debug.Log("切换场景");

        // 加载游戏场景
        SceneManager.LoadScene("Game");
    }
}
