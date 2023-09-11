using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    public GameObject monster;
    // Start is called before the first frame update

    void CloneMonster()
    {
		Instantiate(monster);
	}
    
    void SpawnMonster()
    {
		InvokeRepeating("CloneMonster", 0.0f, 1.0f);
	}
}
