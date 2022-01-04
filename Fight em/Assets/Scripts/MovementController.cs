using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//KURSTA BU DOSYANIN �SM� PLAYERMOVEMENTMOTOR
public class MovementController : MonoBehaviour
{
    [HideInInspector]
    public Vector3 direction;
    Rigidbody rb;
    public float movementspeed = 5f;
    public float walkingSnapyness = 50f;
    public float smoothnessfactor = 0.3f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 targetvelocity = direction * movementspeed;
        Vector3 deltavelocity = targetvelocity - rb.velocity;

        if (rb.useGravity)
        {
            deltavelocity.y = 0f;
        }

        rb.AddForce(deltavelocity * walkingSnapyness, ForceMode.Acceleration);
        //forcemode impulse kullan�rsan karakterin a��rl���n� da i�in i�ine katar. acceleration katm�yor.
        Vector3 facedirection = direction;

        if(facedirection == Vector3.zero)
        {
            rb.angularVelocity = Vector3.zero;
        }
        else
        {
            float rotationAngle = AngleAroundAxis(transform.forward, facedirection, Vector3.up);
            //transform forward = z axisi demek. zde ne tarafa ilerlersek kafa oraya d�ns�n diyee.
            //Vector3.up == 0,1,0 demek. bizim axisimiz de y axisi oldu�u i�in onu verdik.

            rb.angularVelocity = (Vector3.up * rotationAngle * smoothnessfactor);
        }

        float AngleAroundAxis(Vector3 dirA, Vector3 dirB, Vector3 axis)
        {
            dirA = dirA - Vector3.Project(dirA, axis); //project = dirA n�n biti� noktas�n�n axis in hizas�ndaki en yak�n noktas�n� al�r
            dirB = dirB - Vector3.Project(dirB, axis);

            float angle = Vector3.Angle(dirA, dirB); // dira ve dirb nin aras�ndaki a��, derece cinsinden
            return angle * (Vector3.Dot(axis, Vector3.Cross(dirA, dirB)) < 0 ? -1 : 1);
            // is this condition true ? yes : no
            //yani bizim durumumuzda bu de�er 0dan k���k m�? evetse -1 d�nd�r. hay�rsa 1 d�nd�r ve angle ile �arp

            //vector3 cross = dirA ve dirB vekt�rlerini �apraz �arpar.
            //vector3 dot = axis ve �apraz �arp�m�n nokta �arp�m�n� al�r.
            // bi �ekilde dereceyi bulduk ama bakal�m. projede ilerleyince buraya daha detayl� a��klama girerim.
        }
    }
}
