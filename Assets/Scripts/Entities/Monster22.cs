using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster22 : MonoBehaviour
{
    public float curTime = 0; // GameManager.cs
    public int monsterAtk = 0; // MonsterInterface.Atk 

    void Start()
    {
        Time.timeScale = 1.0f;
		SetMonsterLocation();
    }

    void Update()
    {
        curTime += Time.deltaTime; // GameManager.cs
		MonsterAtkUp();
	}

    void SetMonsterLocation()
    {
		float x = Random.Range(-8.3f, 8.3f);
		float y = 4.4f;
		transform.position = new Vector3(x, y, 0);
	}

    void MonsterAtkUp()
    {
        if(curTime > 30f)
        {
            monsterAtk += 1; // MonsterInterface.Atk
		}
    }
}
