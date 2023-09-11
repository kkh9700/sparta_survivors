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
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        monster = new Monster(2, 1, 3, 1, 1);
    }

	 void Start()
	{
        SetMonsterLocation();
	}
	void Update()
    {
		curTime += Time.deltaTime;
        MonsterAtkUp();
		SetDirection();
        ApplyMovment(_movementDirection);
        Rotate(_movementDirection);
    }

    private void SetDirection()
    {
        GameObject player = GameObject.FindWithTag("Player");
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

    public int GetAttack()
    {
        return monster.Attack;
    }

	public void SetMonsterLocation()
	{
		float x = Random.Range(-8.3f, 8.3f);
		float y = 4.4f;
		transform.position = new Vector3(x, y, 0);
	}

	void MonsterAtkUp()
	{
        if (curTime > 30f && !stageUp)
        {
			monster.Attack += 1;
            stageUp = true;
		}
        
	}
}
