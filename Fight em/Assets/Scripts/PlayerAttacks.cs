using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    Animator anim;

    public GameObject SkillOne_EffectPrefab;
    public GameObject SkillOne_DamagePrefab;

    public Transform SkillOne_Point;

    public Transform SkillOnePoint_1;
    public Transform SkillOnePoint_2;
    public Transform SkillOnePoint_3;
    public Transform SkillOnePoint_4;
    public Transform SkillOnePoint_5;
    public Transform SkillOnePoint_6;
    public Transform SkillOnePoint_7;
    public Transform SkillOnePoint_8;

    public GameObject SkillTwo_EffectPrefab;
    public GameObject SkillTwo_DamagePrefab;

    public Transform SkillTwo_Point;

    public Transform SkillTwoPoint_1;
    public Transform SkillTwoPoint_2;
    public Transform SkillTwoPoint_3;
    public Transform SkillTwoPoint_4;
    public Transform SkillTwoPoint_5;
    public Transform SkillTwoPoint_6;

    public GameObject SkillThree_EffectPrefab;

    public Transform SkillThreePoint_1;
    public Transform SkillThreePoint_2;
    public Transform SkillThreePoint_3;
    public Transform SkillThreePoint_4;
    public Transform SkillThreePoint_5;

    private bool s1_notused, s2_notused, s3_notused;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        s1_notused = true;
        s2_notused = true;
        s3_notused = true;
    }
    private void Update()
    {
        GetButtons();
    }

    void GetButtons()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            anim.SetBool(AnimationStates.ANIM_ATTACK, true);
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            anim.SetBool(AnimationStates.ANIM_ATTACK, false);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (s1_notused)
            {
                s1_notused=false;
                anim.SetBool(AnimationStates.ANIM_SKILL_1, true);
                StartCoroutine(skillReset(1));
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (s2_notused)
            {
                s2_notused = false;
                anim.SetBool(AnimationStates.ANIM_SKILL_2, true);
                StartCoroutine(skillReset(2));
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (s3_notused)
            {
                s3_notused = false;
                anim.SetBool(AnimationStates.ANIM_SKILL_3, true);
                StartCoroutine(skillReset(3));
            }
        }
    }

    void skillOne(bool _skillone)
    {
        if (_skillone)
        {
            Instantiate(SkillOne_EffectPrefab, SkillOne_Point.position, SkillOne_Point.rotation);
            StartCoroutine(skillonecoroutine());
        }
        //play music
        
    }

    IEnumerator skillonecoroutine()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(SkillOne_DamagePrefab, SkillOnePoint_1.transform.position, SkillOnePoint_1.transform.rotation);
        Instantiate(SkillOne_DamagePrefab, SkillOnePoint_2.transform.position, SkillOnePoint_2.transform.rotation);
        Instantiate(SkillOne_DamagePrefab, SkillOnePoint_3.transform.position, SkillOnePoint_3.transform.rotation);
        Instantiate(SkillOne_DamagePrefab, SkillOnePoint_4.transform.position, SkillOnePoint_4.transform.rotation);
        Instantiate(SkillOne_DamagePrefab, SkillOnePoint_5.transform.position, SkillOnePoint_5.transform.rotation);
        Instantiate(SkillOne_DamagePrefab, SkillOnePoint_6.transform.position, SkillOnePoint_6.transform.rotation);
        Instantiate(SkillOne_DamagePrefab, SkillOnePoint_7.transform.position, SkillOnePoint_7.transform.rotation);
        Instantiate(SkillOne_DamagePrefab, SkillOnePoint_8.transform.position, SkillOnePoint_8.transform.rotation);

    }
    void skillOneEnd(bool _skillone)
    {
        if (_skillone)
        {
            anim.SetBool(AnimationStates.ANIM_SKILL_1, false);
        }
    }
    void skillTwo(bool _skilltwo)
    {
        if (_skilltwo)
        {
            Instantiate(SkillTwo_EffectPrefab, SkillTwo_Point.position, SkillTwo_Point.rotation);
            StartCoroutine(skilltwocoroutine());
        }
        //play music

    }

    IEnumerator skilltwocoroutine()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(SkillTwo_DamagePrefab, SkillTwoPoint_1.transform.position, SkillTwoPoint_1.transform.rotation);
        Instantiate(SkillTwo_DamagePrefab, SkillTwoPoint_2.transform.position, SkillTwoPoint_2.transform.rotation);
        Instantiate(SkillTwo_DamagePrefab, SkillTwoPoint_3.transform.position, SkillTwoPoint_3.transform.rotation);
        Instantiate(SkillTwo_DamagePrefab, SkillTwoPoint_4.transform.position, SkillTwoPoint_4.transform.rotation);
        Instantiate(SkillTwo_DamagePrefab, SkillTwoPoint_5.transform.position, SkillTwoPoint_5.transform.rotation);
        Instantiate(SkillTwo_DamagePrefab, SkillTwoPoint_6.transform.position, SkillTwoPoint_6.transform.rotation);

    }
    void skillTwoEnd(bool _skilltwo)
    {
        if (_skilltwo)
        {
            anim.SetBool(AnimationStates.ANIM_SKILL_2, false);
        }
    }
    void skillThree(bool _skillthree)
    {
        if (_skillthree)
        {
            Instantiate(SkillThree_EffectPrefab, SkillThreePoint_1.transform.position, SkillThreePoint_1.transform.rotation);
            Instantiate(SkillThree_EffectPrefab, SkillThreePoint_2.transform.position, SkillThreePoint_2.transform.rotation);
            Instantiate(SkillThree_EffectPrefab, SkillThreePoint_3.transform.position, SkillThreePoint_3.transform.rotation);
            Instantiate(SkillThree_EffectPrefab, SkillThreePoint_4.transform.position, SkillThreePoint_4.transform.rotation);
            Instantiate(SkillThree_EffectPrefab, SkillThreePoint_5.transform.position, SkillThreePoint_5.transform.rotation);
        }
    }
    void skillThreeEnd(bool _skillthree)
    {
        if (_skillthree)
        {
            anim.SetBool(AnimationStates.ANIM_SKILL_3, false);

        }
    }
    IEnumerator skillReset(int skill)
    {
        yield return new WaitForSeconds(3f);
        switch (skill)
        {
            case 1:
                s1_notused = true;
                break;
            case 2:
                s2_notused = true;
                break;
            case 3:
                s3_notused = true;
                break;
        }
    }

}
