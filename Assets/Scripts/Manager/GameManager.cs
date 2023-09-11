using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    public GameObject monster;
    Monster monster1 = new Monster(10, 5, 1, 1, 1);
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
