using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;

public class StartScene : MonoBehaviour
{
    public AudioClip startSound;    // ��ʼ��ť��Ч

    AudioSource audioSource;

    public List<string> assetNames;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnStartButton()
    {
        // ������Ч
        audioSource.clip = startSound;
        audioSource.Play();

        // ����Э��
        StartCoroutine(CoGameStart());
    }

    IEnumerator CoGameStart()
    {
        GameObject btn = GameObject.Find("��ʼ��ť");
        // ��ʼ��ť��˸
        for (int i=0; i<6; i++)
        {
            // ����->��ʾ   ��ʾ->����
            btn.SetActive(!btn.activeInHierarchy);
            yield return new WaitForSeconds(0.3f);
        }

        // ������Դ
        yield return Addressables.LoadAssetsAsync<GameObject>(assetNames, null, Addressables.MergeMode.Union);

        var luas = Addressables.LoadAssetsAsync<TextAsset>(new List<string> { "PlayerCha.lua", "PlayerController.lua" }, null
            , Addressables.MergeMode.Union);

        yield return luas;
        // �ȴ��������

        foreach (var textAsset in luas.Result)
        {
            Debug.Log("����Lua�ɹ� " + textAsset.name);
            GameSys.Instance.AddLuaSource(textAsset.name, textAsset.text);
        }


        // �л�����
        Debug.Log("�л�����");

        // ������Ϸ����
        SceneManager.LoadScene("Game");
    }
}
