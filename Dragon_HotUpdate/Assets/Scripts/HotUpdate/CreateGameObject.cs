using UnityEngine;
using UnityEngine.AddressableAssets;

public class CreateGameObject : MonoBehaviour
{
    public AssetReferenceGameObject prefabRef;

    void Start()
    {
        if (prefabRef != null)
        {
            prefabRef.InstantiateAsync().Completed += (a) => {
                a.Result.transform.position = transform.position;
            };
        }
    }
}