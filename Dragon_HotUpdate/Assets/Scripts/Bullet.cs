using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 6;
    public Transform prefabExpl;        // ��ըͼ��Ԥ����

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
        // ������ըͼ
        if (prefabExpl)     // �жϱ���ָ�����壬���������
        {
            Transform expl = Instantiate(prefabExpl, transform.position, Quaternion.identity);
        }
    }
}
