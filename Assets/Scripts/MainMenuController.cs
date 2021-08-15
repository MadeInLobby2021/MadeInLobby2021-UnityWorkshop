using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    /*public Button playButton;

    private void Start()
    {
        playButton.onClick.AddListener(Play);
    }*/

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
