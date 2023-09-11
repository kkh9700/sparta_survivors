using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControllerTest : MonoBehaviour
{
    public float damage;
    public int pen; //����

    public Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Init(float damage, int pen, Vector3 dir)
    {
        this.damage = damage;
        this.pen = pen;
        if (pen > -1)
        {
            rigid.velocity = dir * 13f;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))     //if (!collision.CompareTag("Enemy") || per == -1)
            return;

        pen--;

        if (pen == -1)
        {
            rigid.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }

    }
}

