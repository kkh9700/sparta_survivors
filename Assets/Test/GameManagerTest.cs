using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTest : MonoBehaviour
{
    public static GameManagerTest instanceTest;

    public float gameTime;
    public float maxGameTime = 2 * 10f;

    public PoolManagerTest pool;
    public PlayerControllerTest player;

    private void Awake()
    {
        instanceTest = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }
}
