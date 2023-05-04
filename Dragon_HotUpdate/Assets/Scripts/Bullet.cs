using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 6;
    public Transform prefabExpl;        // 爆炸图的预制体

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        // 创建爆炸图
        if (prefabExpl)     // 判断变量指向物体，且物体存在
        {
            Transform expl = Instantiate(prefabExpl, transform.position, Quaternion.identity);
        }
    }
}
