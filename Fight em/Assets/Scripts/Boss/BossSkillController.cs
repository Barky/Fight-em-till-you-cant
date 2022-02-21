using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkillController : MonoBehaviour
{
    public GameObject skill1_effect;
    public GameObject skill2_effect;
    public GameObject skill3_effect;

    private AudioSource audioSource;
    public AudioClip skillSound;

    public GameObject skill1_Point_1;
    public GameObject skill1_Point_2;
    public GameObject skill1_Point_3;
    public GameObject skill1_Point_4;
    public GameObject skill1_Point_5;
    public GameObject skill1_Point_6;
    public GameObject skill1_Point_7;
    public GameObject skill1_Point_8;
    public GameObject skill1_Point_9;
    

    public GameObject skill2_Point;
    
    public GameObject skill3_Point;

    // public MeleeWeaponTrail MeleeWeaponTrail;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Skill1(bool skill1started)
    {
        if (skill1started)
        {
            Instantiate(skill1_effect, skill1_Point_1.transform.position, skill1_Point_1.transform.rotation);
            Instantiate(skill1_effect, skill1_Point_2.transform.position, skill1_Point_2.transform.rotation);
            Instantiate(skill1_effect, skill1_Point_3.transform.position, skill1_Point_3.transform.rotation);
            Instantiate(skill1_effect, skill1_Point_4.transform.position, skill1_Point_4.transform.rotation);
            Instantiate(skill1_effect, skill1_Point_5.transform.position, skill1_Point_5.transform.rotation);
            Instantiate(skill1_effect, skill1_Point_6.transform.position, skill1_Point_6.transform.rotation);
            Instantiate(skill1_effect, skill1_Point_7.transform.position, skill1_Point_7.transform.rotation);
            Instantiate(skill1_effect, skill1_Point_8.transform.position, skill1_Point_8.transform.rotation);
            Instantiate(skill1_effect, skill1_Point_9.transform.position, skill1_Point_9.transform.rotation);

            StartCoroutine(Skill1Execute());
            
        }
    }

    void Skill2(bool skill2started)
    {
        if (skill2started)
        {
            Instantiate(skill2_effect, skill2_Point.transform.position, skill2_Point.transform.rotation);

        }
    }

    void Skill3(bool skill3started)
    {
        if (skill3started)
        {
            Instantiate(skill3_effect, skill3_Point.transform.position, skill3_Point.transform.rotation);
            // audioSource.PlayOneShot(skillSound);

        }
    }
    
    // Collider'ýnýn etrafýnda gelince hit point açmayý yapýcan burda. sword emit kullanmadan yapmaya calýs yoksa sword ekle

    IEnumerator Skill1Execute()
    {
        yield return new WaitForSeconds((1f));
        Instantiate(skill1_effect, skill1_Point_1.transform.position, skill1_Point_1.transform.rotation);
        Instantiate(skill1_effect, skill1_Point_2.transform.position, skill1_Point_2.transform.rotation);
        Instantiate(skill1_effect, skill1_Point_3.transform.position, skill1_Point_3.transform.rotation);
        Instantiate(skill1_effect, skill1_Point_4.transform.position, skill1_Point_4.transform.rotation);
        Instantiate(skill1_effect, skill1_Point_5.transform.position, skill1_Point_5.transform.rotation);
        Instantiate(skill1_effect, skill1_Point_6.transform.position, skill1_Point_6.transform.rotation);
        Instantiate(skill1_effect, skill1_Point_7.transform.position, skill1_Point_7.transform.rotation);
        Instantiate(skill1_effect, skill1_Point_8.transform.position, skill1_Point_8.transform.rotation);

    }
}
