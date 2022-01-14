using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_RotateObject : MonoBehaviour
{
    public float RotationSpeedX = 0f;
    public float RotationSpeedY = 0f;
    public float RotationSpeedZ = 0f;

    private void Update()
    {
        transform.Rotate(new Vector3(RotationSpeedX, RotationSpeedY, RotationSpeedZ) * Time.deltaTime);
    }
}
