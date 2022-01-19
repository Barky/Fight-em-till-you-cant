using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Prefab_Generator : MonoBehaviour
{

    // FIREBALLBASE �N ALTINDA TRAIL A SM_Trail_fade attach etmen gerekiyo asla unutma ASLaaaaaa

    public GameObject[] skillPrefabs;

    private int randomNo;

    public int HowManyTime = 3;
    public float SpawnInterval = 3f;

    public float x_Width, y_Width, z_Width;

    public float x_RotMax, y_RotMax = 180f, z_RotMax;

    public bool AllUseSameRotation = false;
    private bool AllRotationDecided = false;

    private float x_Cur, y_Cur, z_Cur;
    private float x_RotCur, y_RotCur, z_RotCur;

    private float TimeCounter;
    private float EffectCounter;

    private float trigger;

    private void Start()
    {
        if(HowManyTime < 1)
        {
            HowManyTime = 1;
        }

        trigger = SpawnInterval / HowManyTime;
    }
    private void Update()
    {
        // b��ak atma scripti
        TimeCounter += Time.deltaTime;

        if(TimeCounter > trigger && EffectCounter <= HowManyTime)
        {
            randomNo = Random.Range(0, skillPrefabs.Length);
            x_Cur = transform.position.x + (Random.value * x_Width) - (x_Width * 0.5f);
            y_Cur = transform.position.y + (Random.value * y_Width) - (y_Width * 0.5f);
            z_Cur = transform.position.z + (Random.value * z_Width) - (z_Width * 0.5f);

            if(!AllUseSameRotation || !AllRotationDecided)
            {
                x_RotCur = transform.rotation.x + (Random.value * x_RotMax * 2) - x_RotMax;
                y_RotCur = transform.rotation.y + (Random.value * y_RotMax * 2) - y_RotMax;
                z_RotCur = transform.rotation.z + (Random.value * z_RotMax * 2) - z_RotMax;
                AllRotationDecided = true;
            }
            GameObject skill = Instantiate(skillPrefabs[randomNo], new Vector3(x_Cur, y_Cur, z_Cur), transform.rotation);
            skill.transform.Rotate(x_RotCur, y_RotCur, z_RotCur);

            TimeCounter -= trigger;
            EffectCounter += 1;
        }
    }
}
