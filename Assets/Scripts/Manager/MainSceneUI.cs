using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneUI : MonoBehaviour
{
    public GameObject scorePanel;
    public GameObject optionPanel;

    private void Awake()
    {
        scorePanel.SetActive(false);
        optionPanel.SetActive(false);
    }

    public void StartBtn()
    {
        //SceneManager.LoadScene("");
        Debug.Log("∞‘¿” æ¿ ∑ŒµÂ");
    }
}
