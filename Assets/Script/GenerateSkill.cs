using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateSkill : MonoBehaviour
{

    public int[] PosArray = new int[6];

   // [SerializeField] private Skill[] skills;
    //public double accumulatedWeights;
    //public System.Random rand = new System.Random();

    public Image[] skillImagePos = new Image[6];
    //public Sprite[] skillSprite = new Sprite[5];

    int r;
    

    private void Awake()
    {
        randomRailSKill();

    }
    private void Start()
    {
       
    }

    public void randomRailSKill()
    {
        for(int i=0;i<PosArray.Length;i++)
        {
            r = UnityEngine.Random.Range(0, 6);
            PosArray[i] = r;
            for(int j=0;j<i;j++)
            {
                while(PosArray[i]==PosArray[j])
                {
                    j = 0;
                    r = UnityEngine.Random.Range(0, 6);
                    PosArray[i] = r;
                }
            }
        }

        for(int i=0;i<PosArray.Length;i++)
        {
            if(PosArray[i]==0|| PosArray[i] == 1)
            {
                PosArray[i] = 0;
                skillImagePos[i].color =new Color(0.3254902f, 0.4352942f, 0.2941177f);

            }
            else if(PosArray[i] == 2 || PosArray[i] == 3)
            {
                PosArray[i] = 1;
                skillImagePos[i].color = new Color(0.5333334f, 0.254902f, 0.2745098f);
            }
            else if (PosArray[i] == 4 || PosArray[i] == 5)
            {
                PosArray[i] = 2;
                skillImagePos[i].color = new Color(0.345098f, 0.3764706f, 0.3921569f);

            }

        }

    }

   /* public void randomRail()
    {
        for(int i=0;i<PosArray.Length;i++)
        {
            SpawnRandomSkill(i);
        }

        for(int i=0;i<PosArray.Length;i++)
        {
            skillImagePos[i].sprite = skillSprite[PosArray[i]];
        }*/

        /*for (int i = 0; i < 6; i++)
        {
            ranNum = animCurve.Evaluate(Random.value);
            PosArray[i] = (int)ranNum;

            for (int j = 0; j < i; j++)
            {
                while (PosArray[j] == PosArray[i])    //檢查是否與前面產生的數值發生重複，如果有就重新產生
                {
                    j = 0;  //如有重複，將變數j設為0，再次檢查 (因為還是有重複的可能)
                    ranNum = animCurve.Evaluate(Random.value);
                    PosArray[i] = (int)ranNum;
                }

            }
        }*/
    }

    /*void test()
    {
        for(int i=0;i<200;i++)
        {
            SpawnRandomSkill();
        }
    }*/

    /* for (int i = 0; i < 6; i++)
{
 pictureSpacing += 1.028f;
 Instantiate(Attributes_picture[rangeNum[i]], new Vector3(-6.67f, pictureSpacing), new Quaternion(0, 0, 0, 0));
}*/
    /*public void SpawnRandomSkill(int PosArrayNum)
    {
        Skill randomSkill = skills[GetRandomSkillIndex()];
        //Debug.Log(randomSkill.SkillNum);
        PosArray[PosArrayNum] = randomSkill.SkillNum;       
    }

    public int GetRandomSkillIndex()
    {
        double r = rand.NextDouble() * accumulatedWeights;

        for(int i=0;i<skills.Length;i++)
        {
            if(skills[i]._weight>=r)
            {
                return i;
            }
        }

        return 0;
    }

    public void CalculateWeights()
    {
        accumulatedWeights = 0f;
        foreach(Skill skill in skills)
        {
            accumulatedWeights += skill.Chance;
            skill._weight = accumulatedWeights;
        }
    }

    

}

[System.Serializable]
public class Skill
{
    public int SkillNum;
    [Range(0f, 100f)] public float Chance = 100f;
    [HideInInspector] public double _weight;
}*/
