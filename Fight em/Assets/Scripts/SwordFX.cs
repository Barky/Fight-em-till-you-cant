using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFX : MonoBehaviour
{

    private MeleeWeaponTrail weaponTrail;

    public Transform sword;

    public GameObject hitPoint;
    public GameObject slashThreeEffectprefab;
    public Transform thirdSlashPoint;

    private AudioSource audioSource;

    //public AudioClip sword1; geri kalaný da altýna eklerik

    private void Awake()
    {
        
        weaponTrail = sword.GetComponent<MeleeWeaponTrail>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }



    void FirstSlashTrailStart(bool show)
    {
        if (show)
        {
            weaponTrail.Emit = true;
            hitPoint.SetActive(true);
            Debug.LogError("hitpoint active skill 1");

            // audiosource.play sound1
        }
    }
    void FirstSlashTrailEnd(bool end)
    {
        if (end)
        {
            weaponTrail.Emit = false;
            hitPoint.SetActive(false);

        }
    }

    void SecondSlashTrailStart(bool show)
    {
        if (show)
        {
            weaponTrail.Emit = true;
            hitPoint.SetActive(true);

            // audiosource.play sound2
        }
    }
    void SecondSlashTrailEnd(bool end)
    {
        if (end)
        {
            weaponTrail.Emit = false;
            hitPoint.SetActive(false);

        }
    }
    void ThirdSlashTrailStart(bool show)
    {
        if (show)
        {
            weaponTrail.Emit = true;
            hitPoint.SetActive(true);

            // audiosource.play sound3
        }
    }
    void ThirdSlashTrailEnd(bool end)
    {
        if (end)
        {
            weaponTrail.Emit = false;
            hitPoint.SetActive(false);
        }
    }
    void ThirdSlashEffect(bool show)
    {
        if (show)
        {
            Instantiate(slashThreeEffectprefab, thirdSlashPoint.position, thirdSlashPoint.rotation);
            // play this sound now. pick sounds later on.
        }
    }
}
