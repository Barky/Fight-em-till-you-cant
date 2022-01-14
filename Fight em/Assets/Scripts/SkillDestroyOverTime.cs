using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDestroyOverTime : MonoBehaviour
{
    public float timer = 2f;

    private void Start()
    {
        Destroy(gameObject, timer);
    }
}
