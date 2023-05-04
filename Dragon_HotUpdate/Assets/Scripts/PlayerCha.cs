using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCha : MonoBehaviour
{
    public Transform prefabBullet;
    public float speed = 3;

    public float fireCD = 0.2f;
    float lastFireTime;

    // 移动的边界范围
    public Border moveBorder;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Move(Vector3 input)
    {
        Vector3 pos = transform.position + input * speed * Time.deltaTime;

        // Clamp:限定范围
        pos.x = Mathf.Clamp(pos.x, moveBorder.left, moveBorder.right);
        pos.y = Mathf.Clamp(pos.y, moveBorder.bottom, moveBorder.top);

        transform.position = pos;
    }

    public void Fire()
    {
        if (Time.time < lastFireTime + fireCD)
        {
            return;
        }

        Vector3 pos = transform.position + new Vector3(0, 0.8f, 0);
        Transform bullet = Instantiate(prefabBullet, pos, Quaternion.identity);
        lastFireTime = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("玩家碰到怪物");

        //Destroy(gameObject);
    }
}
