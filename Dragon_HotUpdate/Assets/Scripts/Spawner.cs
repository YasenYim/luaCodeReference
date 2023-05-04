using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // 多个怪物的预制体
    public List<Transform> monsters;

    public float minTime = 0.5f;
    public float maxTime = 2;

    void Start()
    {
        StartCoroutine(Create());
    }

    IEnumerator Create()
    {
        while (true)
        {
            // 等一段时间
            float t = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(t);

            // 创建怪物
            // 随机怪物下标
            int i = Random.Range(0, monsters.Count);
            // 随机位置
            Vector3 pos = new Vector3(Random.Range(-2.1f, 2.1f), transform.position.y, 0);
            Transform m = Instantiate(monsters[i], pos, Quaternion.identity);
        }
    }
}
