using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    PlayerCha player;

    void Start()
    {
        player = GetComponent<PlayerCha>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, v, 0);

        // ���ý�ɫ���ƶ�����
        player.Move(move);

        if (Input.GetButton("Fire1"))
        {
            player.Fire();
        }
    }
}
