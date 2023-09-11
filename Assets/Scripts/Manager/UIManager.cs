using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject scorePanel;
    public GameObject optionPanel;

    private void Awake()
    {
        scorePanel.SetActive(false);
        optionPanel.SetActive(false);
        Screen.fullScreen = true;
    }

    public void StartBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void ResolutionChange(int index)
    {
        switch (index)
        {
            case 0:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 1:
                Screen.SetResolution(1600, 900, Screen.fullScreen);
                break;
            case 2:
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                break;
        }
    }

    public void FullOrWindow()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
