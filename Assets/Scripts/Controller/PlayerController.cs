using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Image HP;
    [SerializeField] private GameObject BulletTimeEffect;
    private Camera _camera;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;
    private Vector2 _movementDirection = Vector2.zero;
    private Player player;
    private float speed;
    private int maxHP = 10;
    private bool isBulletTime = false;

    private void Awake()
    {
        _camera = Camera.main;
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        player = new Player(maxHP, 1, 5, 1);
        speed = player.Speed;
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        ApplyMovment(_movementDirection);
        Rotate(_movementDirection);
    }

    public void OnMove(InputValue value)
    {
        // Debug.Log("OnMove" + value.ToString());
        Vector2 moveInput = value.Get<Vector2>().normalized;
        _movementDirection = moveInput;
    }

    public void OnLook(InputValue value)
    {
        // Debug.Log("OnLook" + value.ToString());
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;
    }

    public void OnDash()
    {
        speed = 50;
        Invoke("OffDash", .05f);
    }

    public void OnBulletTime()
    {
        if (!isBulletTime)
        {
            Time.timeScale = .5f;
            speed *= 2;
            BulletTimeEffect.SetActive(true);
            isBulletTime = true;
            Invoke("OffBulletTime", 5f);
        }
    }

    private void OffDash()
    {
        speed = player.Speed;
    }

    private void OffBulletTime()
    {
        Time.timeScale = 1;
        speed /= 2;
        isBulletTime = false;
        BulletTimeEffect.SetActive(false);
    }

    private void ApplyMovment(Vector2 direction)
    {
        direction = direction * speed;

        _rigidbody.velocity = direction;
    }

    private void Rotate(Vector2 direction)
    {
        if (direction.x != 0)
            _renderer.flipX = direction.x < 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.tag == "Monster")
        {
            player.Damaged(collision.transform.GetComponent<MonsterController>().GetAttack());
            HP.fillAmount = player.HP / (float)maxHP;
        }
    }
}