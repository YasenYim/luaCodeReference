using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeHit : MonoBehaviour
{
    SpriteRenderer[] renders;

    public float redTime = 0.1f;   // 保持红色的时间，可调
    float changeColorTime;  // 变回白色的时间

    public float hp = 10;

    public Transform prefabBoom;    // 爆炸动画

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
            // 死亡
            Destroy(gameObject);

            // 播放爆炸特效
            Instantiate(prefabBoom, transform.position, Quaternion.identity);
        }
    }

}
