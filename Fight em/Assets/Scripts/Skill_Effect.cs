using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Effect : MonoBehaviour
{
    //if we hit a gameobject?

    public LayerMask ignorelayers;
    public GameObject skillPrefab;
    public float radius;

    private bool collided = false;

    private void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, ~ignorelayers);

        foreach (Collider hit in hits)
        {
            if (hit.isTrigger)
            {
                continue;
            }
            collided = true;
        }

        if (collided)
        {
            Instantiate(skillPrefab, transform.position, transform.rotation);
           Destroy(gameObject);
        }
    }
}
