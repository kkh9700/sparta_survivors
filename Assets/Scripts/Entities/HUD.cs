using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class HUDTest : MonoBehaviour
{
    public enum InfoType { Exp, Level, Score, Time, Health }
    public InfoType type;

    TMP_Text myText;
    Slider mySlider;

    private void Awake()
    {
        myText = GetComponent<TMP_Text>();
        if(InfoType.Exp == type)
        mySlider = GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                float curExp = GameManager.I.exp;
                float maxExp = GameManager.I.nextExp[GameManager.I.level];
                mySlider.value = curExp / maxExp;
                break;
            case InfoType.Level:
                myText.text = string.Format("Lv.{0:F0}", GameManager.I.level);
                break;
            case InfoType.Score:
                myText.text = string.Format("Score : {0:F0}", GameManager.I.score);
                break;
            case InfoType.Time:
                float remainTime = GameManager.I.maxGameTime - GameManager.I.gameTime;
                int min = Mathf.FloorToInt(remainTime / 60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                myText.text = string.Format("{0:D2}:{1:D2}", min, sec);
                break;
            default:
                break;
        }
    }
}
