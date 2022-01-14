using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_RandomScale : MonoBehaviour
{

    public float minScale = 1f, maxScale = 2f;

    private void Start()
    {
       float randomNo = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(randomNo, randomNo, randomNo);
    }




}
