using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTest : MonoBehaviour
{
    public static GameManagerTest instanceTest;

    public float gameTime;
    public float maxGameTime = 10f;
    public int health;
    public int maxHealth = 100;
    public int exp;
    public int[] nextExp;
    public int level;
    public int score;
    public GameObject pausePanel;

    public PoolManagerTest pool;
    public PlayerControllerTest player;

    private void Awake()
    {
        instanceTest = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        if (gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if(Time.timeScale > 0.1f)
        {
            Time.timeScale = 0.0f;
            pausePanel.SetActive(true);

        } else
        {
            Time.timeScale = 1.0f;
            pausePanel.SetActive(false);

        }

    }
}
