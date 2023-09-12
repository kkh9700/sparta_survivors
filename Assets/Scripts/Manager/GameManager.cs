using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public GameObject monster;
	public GameObject pausePanel;
	public float gameTime;
	public float maxGameTime = 10f;
	public int stage = 1;
	public int exp = 0;
	public int[] nextExp;
	public int level = 0;
	public int score;
	public TMP_Text stageTxt;

	public static GameManager I;

	void Awake()
	{
		if (I == null)
		{
			I = this;
		}
		else if (I != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	void Start()
	{
		score = 0;
		SpawnMonster();
	}

	void Update()
	{
		gameTime += Time.deltaTime;
		if (gameTime > maxGameTime)
		{
			gameTime = 0;
			stage++;
		}
	}

	public void OnPause()
	{
		if (Time.timeScale == 0f)
		{
			Time.timeScale = 1.0f;
			pausePanel.SetActive(false);
		}
		else
		{
			Time.timeScale = 0.0f;
			pausePanel.SetActive(true);
		}
	}


	void CloneMonster()
	{

		Instantiate(monster);
	}

	void SpawnMonster()
	{
		InvokeRepeating("CloneMonster", 0.0f, 1.0f);
	}

	public void AddExp(int n)
	{
		exp += n;
		if (exp >= nextExp[level])
		{
			exp -= nextExp[level];
			level++;
		}
	}
}
