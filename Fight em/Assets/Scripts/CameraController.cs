using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform firstpos;
    private Transform player;
    private Vector3 offset = new Vector3(3f, 7.5f, -3f);

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }
    private void Start()
    {
        firstpos = transform;
    }

    private void Update()
    {
        if (player)
        {
            firstpos.position = player.position + offset;
            firstpos.LookAt(player.position, Vector3.up);
        }
    }
}
