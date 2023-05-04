using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class PlayerSprites : MonoBehaviour
{
    public AssetReferenceT<Sprite> spBody;
    public AssetReferenceT<Sprite> spWing;

    void Start()
    {
        SpriteRenderer playerBody = transform.GetChild(0).GetComponent<SpriteRenderer>();
        SpriteRenderer playerWing1 = transform.GetChild(1).GetComponent<SpriteRenderer>();
        SpriteRenderer playerWing2 = transform.GetChild(2).GetComponent<SpriteRenderer>();

        spBody.LoadAssetAsync().Completed += (sp) =>
        {
            playerBody.sprite = sp.Result;
        };

        spWing.LoadAssetAsync().Completed += (sp) =>
        {
            playerWing1.sprite = sp.Result;
            playerWing2.sprite = sp.Result;
        };
    }
}
