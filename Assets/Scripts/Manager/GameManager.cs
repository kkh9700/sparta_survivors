using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject monster;
    // Start is called before the first frame update
    void Start()
    {
        SpawnMonster();
	}

    // Update is called once per frame
    void Update()
    {

	}

    void CloneMonster()
    {
		Instantiate(monster);
	}	

    void SpawnMonster()
    {
		InvokeRepeating("CloneMonster", 0.0f, 1.0f);
	}
}
