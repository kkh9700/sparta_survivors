using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Image HPImg;
    [SerializeField] private Image BulletTimeImg;
    [SerializeField] private Image DashImg;
    [SerializeField] private GameObject BulletTimeEffect;
    public Scanner _scanner;
    private Camera _camera;
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;
    private Vector2 _movementDirection = Vector2.zero;
    private Player player;
    private float speed;
    private int maxHP = 10;
    private bool isBulletTime = false;
    private float BTGauge = 5;
    private float BTScale = 3;
    private float DashCoolTime = 2;
    private float DamagedDelay = 0;

    private void Awake()
    {
        _camera = Camera.main;
        _scanner = GetComponent<Scanner>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
        player = new Player(maxHP, 1, 5, .3f);
        speed = player.Speed;
    }

    private void Update()
    {
        if (isBulletTime)
        {
            BTGauge -= Time.unscaledDeltaTime;
            if (BTGauge < 0)
                OffBulletTime();
        }
        else
        {
            BTGauge += Time.unscaledDeltaTime * .5f;
            if (BTGauge > 5)
                BTGauge = 5;
        }

        DashCoolTime += Time.unscaledDeltaTime;

        if (DashCoolTime > 2)
            DashCoolTime = 2;

        DamagedDelay -= Time.unscaledDeltaTime;

        if (DamagedDelay < 0)
            DamagedDelay = 0;

        BulletTimeImg.fillAmount = BTGauge / 5f;
        DashImg.fillAmount = DashCoolTime / 2f;
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
        if (DashCoolTime < 2)
            return;

        DashCoolTime = 0;
        speed += 50;
        Invoke("OffDash", .05f);
    }

    public void OnBulletTime()
    {
        if (!isBulletTime)
        {
            Time.timeScale = 1 / BTScale;
            speed *= BTScale;
            isBulletTime = true;
            BulletTimeEffect.SetActive(true);
        }
        else
        {
            OffBulletTime();
        }
    }

    private void OffDash()
    {
        speed -= 50;
    }

    private void OffBulletTime()
    {
        Time.timeScale = 1;
        speed /= BTScale;
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

    void OnCollisionStay2D(Collision2D collision)
    {
        if (DamagedDelay <= 0)
        {
            if (collision.gameObject.tag == "Monster")
            {
                DamagedDelay = .5f;
                player.Damaged(collision.transform.GetComponent<MonsterController>().GetAttack());
                HPImg.fillAmount = player.HP / (float)maxHP;
            }
        }
    }

    public float GetAtk()
    {
        return player.Attack;
    }

    public float GetAtkSpeed()
    {
        return player.AtkSpeed;
    }

    public void SetSpeed(float n)
    {
        speed *= n;

        StartCoroutine(RestoreSpeed(n));
    }

    IEnumerator RestoreSpeed(float n)
    {
        yield return new WaitForSeconds(3f);
        speed /= n;
    }

    public void RecoveryHp(float n)
    {
        player.HP += maxHP * n;

        if (player.HP < maxHP)
            player.HP = maxHP;
    }
}