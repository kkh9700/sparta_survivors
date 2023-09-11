using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		SetMonsterLocation();
    }

    // Update is called once per frame
    void Update()
    {
        MoveMonster();
	}

    void SetMonsterLocation()
    {
		float x = Random.Range(-8.3f, 8.3f);
		float y = 4.4f;
		transform.position = new Vector3(x, y, 0);
	}

    void MoveMonster()
    {
		transform.position += new Vector3(0.0f, -0.01f, 0.0f);
	}
}
