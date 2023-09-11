using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class HUDTest : MonoBehaviour
{
    public enum InfoType { Exp, Level, Score, Time, Health}
    public InfoType type;

    TMP_Text myText;
    Slider mySlider;

    private void Awake()
    {
        myText = GetComponent<TMP_Text>();
        mySlider = GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        switch(type)
        {
            case InfoType.Exp:
                float curExp = GameManagerTest.instanceTest.exp;
                float maxExp = GameManagerTest.instanceTest.nextExp[GameManagerTest.instanceTest.level];
                mySlider.value = curExp / maxExp;
                break;
            case InfoType.Level:
                myText.text = string.Format("Lv.{0:F0}", GameManagerTest.instanceTest.level);
                break;
            case InfoType.Score:
                myText.text = string.Format("Score : {0:F0}", GameManagerTest.instanceTest.score);
                break;
            case InfoType.Time:
                float remainTime = GameManagerTest.instanceTest.maxGameTime - GameManagerTest.instanceTest.gameTime;
                int min = Mathf.FloorToInt(remainTime / 60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                myText.text = string.Format("{0:D2}:{1:D2}", min, sec);
                break;
            case InfoType.Health:
                float curHealth = GameManagerTest.instanceTest.health;
                float maxHealth = GameManagerTest.instanceTest.maxHealth;
                mySlider.value = curHealth / maxHealth;
                break;
            default: 
                break;
        }
    }
}