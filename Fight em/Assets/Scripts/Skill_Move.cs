using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Move : MonoBehaviour
{
    public float x = 0f;
    public float y = 0f;
    public float z = 0f;

    public bool local = false;

    private void Update()
    {
        if (local)
        {
            transform.Translate(new Vector3 (x, y, z) * Time.deltaTime);
        }

        if (!local)
        {
            transform.Translate(new Vector3(x, y, z) * Time.deltaTime, Space.World);
        }
    }
}
