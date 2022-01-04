using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//KURSTA BU DOSYANIN ÝSMÝ PLAYERMOVEKEYBOARD
public class PlayerController : MonoBehaviour
{

    private Animator anim;

    private MovementController movementcontroller;
    private Transform playertransform;

    private Quaternion screenMovementSpace;
    private Vector3 screenMovementForward;
    private Vector3 screenMovementRight;
    // sað ve ileri yetiyor çünkü -1 * forward = back, -1 * right = left

    private string X_AXIS = "Horizontal";
    private string Y_AXIS = "Vertical";

    private void Awake()
    {
        anim = GetComponent<Animator>();
        movementcontroller = GetComponent<MovementController>();
        playertransform = GetComponent<Transform>();
        movementcontroller.direction = Vector2.zero;
    }

    private void Start()
    {
        screenMovementSpace = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        screenMovementForward = screenMovementSpace * Vector3.forward;
        screenMovementRight = screenMovementSpace * Vector3.right;
    }
    private void Update()
    {
        movementcontroller.direction = Input.GetAxis(X_AXIS) * screenMovementRight + Input.GetAxis(Y_AXIS) * screenMovementForward;

        if(Input.GetAxis(X_AXIS) !=0 || Input.GetAxis(Y_AXIS) != 0)
        {
            anim.SetBool(AnimationStates.ANIM_RUN, true);
        }
        else
        {
            anim.SetBool(AnimationStates.ANIM_RUN, false);
        }

        if(movementcontroller.direction.sqrMagnitude > 1)
        {
            movementcontroller.direction.Normalize();
        }
    }
}
