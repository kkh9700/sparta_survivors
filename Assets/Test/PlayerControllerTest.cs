using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerTest : MonoBehaviour
{
    public Vector2 inputVec;
    Rigidbody2D rigid;
    public float speed;
    public ScannerTest scanner;

    // SpriteRenderer spriter;
    // Animator anim;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        scanner = GetComponent<ScannerTest>();

        /*spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();*/
    }

    private void LateUpdate()
    {
        /*anim.SetFloat("Speed", inputVec.magnitude);
        if(inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }*/
    }

    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);

    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
