using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeHit : MonoBehaviour
{
    SpriteRenderer[] renders;

    public float redTime = 0.1f;   // ���ֺ�ɫ��ʱ�䣬�ɵ�
    float changeColorTime;  // ��ذ�ɫ��ʱ��

    public float hp = 10;

    public Transform prefabBoom;    // ��ը����

    void Start()
    {
        renders = GetComponentsInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Time.time >= changeColorTime)
        {
            SetColor(Color.white);
        }
    }

    void SetColor(Color c)
    {
        if (renders[0].color == c)
        {
            return;
        }

        foreach (var r in renders)
        {
            r.color = c;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SetColor(Color.red);
        changeColorTime = Time.time + redTime;

        hp -= 1;
        if (hp <= 0)
        {
            // ����
            Destroy(gameObject);

            // ���ű�ը��Ч
            Instantiate(prefabBoom, transform.position, Quaternion.identity);
        }
    }

}
