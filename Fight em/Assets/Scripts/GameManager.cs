using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private GameObject LoadingScreen, mainmenuui;
    [HideInInspector] public int levelno;

    private void Awake()
    {
        getinstance();
        LoadingScreen = GameObject.Find("/UI/Canvas/Loading");
        mainmenuui = GameObject.Find("/UI/Canvas/MainMenuPanel");
        StartCoroutine(FirstLoading());

    }

    private void Start()
    {
        
        CheckPlayerPrefs();
    }

    IEnumerator FirstLoading()
    {
        yield return new WaitForSeconds(0.5f);
        LoadingScreen.gameObject.SetActive(false);
        mainmenuui.gameObject.SetActive(true);
    }

    IEnumerator startButton_()
    {
        mainmenuui.gameObject.SetActive(false);
        LoadingScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        AsyncOperation asyncload = SceneManager.LoadSceneAsync("Game");
        while (!asyncload.isDone) yield return null;


    }
    public void CheckPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            levelno = PlayerPrefs.GetInt("Level");
        }
        else
        {
            levelno = 1;
            PlayerPrefs.SetInt("Level", levelno);
            PlayerPrefs.Save();
            
        }
    }

    public void StartButton()
    {
        StartCoroutine(startButton_());
    }
    void getinstance()
    {
        if (instance == null)
        {
            
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
