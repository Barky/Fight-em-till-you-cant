using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPrefabController : MonoBehaviour
{
    public Text levelText;

    private void Start()
    {
        levelText.text = "Level = " + GameManager.instance.levelno.ToString();
    }
}
