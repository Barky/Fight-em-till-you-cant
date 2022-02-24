using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{
    private Transform player;

    public VariableJoystick joystick;

    private Animator anim;

    private void Awake()
    {
        player = this.transform;
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical !=0)
        {
            float angle = Mathf.Atan2(joystick.Vertical, joystick.Horizontal) * Mathf.Rad2Deg;
            player.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));
            anim.SetBool(AnimationStates.ANIM_RUN, true);
        }
        else
        {
            anim.SetBool(AnimationStates.ANIM_RUN, false);
        }
    }
}
