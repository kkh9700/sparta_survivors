using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Camera _camera;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;
    private Vector2 _movementDirection = Vector2.zero;

    private void Awake()
    {
        _camera = Camera.main;
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
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

    private void ApplyMovment(Vector2 direction)
    {
        direction = direction * 10;

        _rigidbody.velocity = direction;
    }

    private void Rotate(Vector2 direction)
    {
        if (direction.x != 0)
            _renderer.flipX = direction.x < 0;
    }
}