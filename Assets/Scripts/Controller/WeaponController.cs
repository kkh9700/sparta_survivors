using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public int id;
    public int prefabId;
    public int count;
    public float freq;
    float timer;
    PlayerController player;

    private void Awake()
    {
        player = GetComponentInParent<PlayerController>();
    }

    private void Start()
    {
        freq = player.GetAtkSpeed();
    }

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

    public void LevelUp(int count) // ���� ������
    {
        this.count += count;

    }

    void Fire()
    {
        if (!player._scanner.nearestTarget)
            return;

        SoundManager.I.PlaySound("Spear", .5f);

        Vector3 targetPos = player._scanner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;

        Transform bullet = PoolManager.I.Get(prefabId).transform;
        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        bullet.GetComponent<BulletController>().Init(player.GetAtk(), count, dir);
    }
}
