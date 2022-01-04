using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//KURSTA BU DOSYANIN ÝSMÝ PLAYERMOVEMENTMOTOR
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
        //forcemode impulse kullanýrsan karakterin aðýrlýðýný da iþin içine katar. acceleration katmýyor.
        Vector3 facedirection = direction;

        if(facedirection == Vector3.zero)
        {
            rb.angularVelocity = Vector3.zero;
        }
        else
        {
            float rotationAngle = AngleAroundAxis(transform.forward, facedirection, Vector3.up);
            //transform forward = z axisi demek. zde ne tarafa ilerlersek kafa oraya dönsün diyee.
            //Vector3.up == 0,1,0 demek. bizim axisimiz de y axisi olduðu için onu verdik.

            rb.angularVelocity = (Vector3.up * rotationAngle * smoothnessfactor);
        }

        float AngleAroundAxis(Vector3 dirA, Vector3 dirB, Vector3 axis)
        {
            dirA = dirA - Vector3.Project(dirA, axis); //project = dirA nýn bitiþ noktasýnýn axis in hizasýndaki en yakýn noktasýný alýr
            dirB = dirB - Vector3.Project(dirB, axis);

            float angle = Vector3.Angle(dirA, dirB); // dira ve dirb nin arasýndaki açý, derece cinsinden
            return angle * (Vector3.Dot(axis, Vector3.Cross(dirA, dirB)) < 0 ? -1 : 1);
            // is this condition true ? yes : no
            //yani bizim durumumuzda bu deðer 0dan küçük mü? evetse -1 döndür. hayýrsa 1 döndür ve angle ile çarp

            //vector3 cross = dirA ve dirB vektörlerini çapraz çarpar.
            //vector3 dot = axis ve çapraz çarpýmýn nokta çarpýmýný alýr.
            // bi þekilde dereceyi bulduk ama bakalým. projede ilerleyince buraya daha detaylý açýklama girerim.
        }
    }
}
