using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMove : MonoBehaviour
{
    Material mat;
    public float speed;

    void Start()
    {
        mat = GetComponent<MeshRenderer>().sharedMaterial;
    }

    void Update()
    {
        mat.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
    }
}
