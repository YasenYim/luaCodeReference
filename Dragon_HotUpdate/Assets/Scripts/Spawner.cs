using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // ��������Ԥ����
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
            // ��һ��ʱ��
            float t = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(t);

            // ��������
            // ��������±�
            int i = Random.Range(0, monsters.Count);
            // ���λ��
            Vector3 pos = new Vector3(Random.Range(-2.1f, 2.1f), transform.position.y, 0);
            Transform m = Instantiate(monsters[i], pos, Quaternion.identity);
        }
    }
}
