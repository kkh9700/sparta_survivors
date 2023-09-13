using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;
    private Vector2 _movementDirection = Vector2.zero;
    private ICharacter monster;
    private float curTime = 0;
    private bool stageUp = false;
    private GameObject player;
    [SerializeField]
    public ItemDropTable itemDropTable;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
        int n = GameManager.I.stage;
        monster = new Monster(1 * n, 1 * n, 3, 1, 1);
        transform.SetAsFirstSibling();
    }

    void Start()
    {
        SetMonsterLocation();
    }
    void Update()
    {
        SetDirection();
        ApplyMovment(_movementDirection);
        Rotate(_movementDirection);
    }

    private void SetDirection()
    {
        float x = player.transform.position.x - transform.position.x;
        float y = player.transform.position.y - transform.position.y;
        _movementDirection = new Vector2(x, y).normalized;
    }

    private void ApplyMovment(Vector2 direction)
    {
        direction = direction * 3;

        _rigidbody.velocity = direction;
    }

    private void Rotate(Vector2 direction)
    {
        if (direction.x != 0)
            _renderer.flipX = direction.x < 0;
    }

    public void SetMonsterLocation()
    {
        float x = Random.Range(-8.3f, 8.3f) + player.transform.position.x;
        float y = 4.4f + player.transform.position.y;
        transform.position = new Vector3(x, y, 0);
    }

    public float GetAttack()
    {
        return monster.Attack;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))     //if (!collision.CompareTag("Enemy") || per == -1)
            return;

        monster.HP -= collision.GetComponent<BulletController>().damage;

        if (monster.HP <= 0)
        {
            itemDropTable.ItemDrop(transform.position, ((Monster)monster).Exp);
            Destroy(gameObject);
        }
    }
}
