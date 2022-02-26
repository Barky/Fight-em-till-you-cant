using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;


    public GameObject[] levels ;

    private int levelno;

    private Text leveltext;
    

    private void Start()
    {
        // leveltext = GameObject.Find("/UI/Canvas/levelText").GetComponent<Text>();
        // leveltext.text = "Level = " + GameManager.instance.levelno.ToString();
        // GameObject newlevel = Instantiate(levels[0], Vector3.zero, Quaternion.identity);
        // newlevel.transform.parent = transform;
        //Instantiate(levels[0], transform);

    }

    

    // void getinstance()
    // {
    //     if (instance == null)
    //     {
    //         
    //         instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }
}
