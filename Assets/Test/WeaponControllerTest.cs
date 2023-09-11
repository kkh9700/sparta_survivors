using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControllerTest : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float freq;

    float timer;
    PlayerControllerTest player;
    public PoolManagerTest pool;

    private void Awake()
    {
        player = GetComponentInParent<PlayerControllerTest>();
        
    }

    void Start()
    {
        freq = 0.3f;
    }
    // Update is called once per frame
    void Update()
    {
        switch (id)
        {
            case 0:
                timer += Time.deltaTime;

                if (timer > freq)
                {
                    timer = 0f;
                    Fire();
                }
                break;
            default:

                break;
        }
        if (Input.GetButtonDown("Jump")) // 레벨업 테스트
        {
            LevelUp(2, 1);
        }

    }
        public void Init()
    {
        switch (id)
        {
            case 0:
                freq = 0.3f;
                break;
            default:

                break;
        }
    }

    public void LevelUp(float damage, int count) // 무기 레벨업
    {
        this.damage += damage;
        this.count += count;

    }

    void Fire()
    {
        if (!player.scanner.nearestTarget)
            return;

        Vector3 targetPos = player.scanner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;

        Transform bullet = GameManagerTest.instanceTest.pool.Get(prefabId).transform;
        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        bullet.GetComponent<BulletControllerTest>().Init(damage, count, dir);

    }



    // Update is called once per frame
}
