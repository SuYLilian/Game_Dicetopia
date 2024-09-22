using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateBossSkill : MonoBehaviour
{
    public Sprite[] BossSkillSprite = new Sprite[4];
    public int[] RoundArray = new int[20];
    int r;

    public Image BossSkillImage, NextBossSkillImage;

    public GameObject NBSI;

    private void Awake()
    {
        _GenerateBossSkill();
        ImportBoskillImage();
    }

    void _GenerateBossSkill()
    {
        RoundArray[0] = 10;
        while (RoundArray[0] == 10 || RoundArray[0] == 11)
        {
            for (int i = 0; i < RoundArray.Length; i++)
            {
                r = UnityEngine.Random.Range(0, 17);
                RoundArray[i] = r;
                if (RoundArray[0] == 10 || RoundArray[0] == 11)
                {
                    i = -1;
                }
                else
                {
                    for (int j = 0; j < i; j++)
                    {
                        while (RoundArray[j] == RoundArray[i])    //檢查是否與前面產生的數值發生重複，如果有就重新產生
                        {
                            j = 0;  //如有重複，將變數j設為0，再次檢查 (因為還是有重複的可能)
                            r = UnityEngine.Random.Range(0, 17);
                            RoundArray[i] = r;

                        }
                    }
                    if (r == 7 || r == 8 || r == 9)
                    {
                        RoundArray[i + 1] = 17;
                        i++;
                    }
                }
        
            }


        }

        for (int k = 0; k < RoundArray.Length; k++)
        {
            if (RoundArray[k] == 0 || RoundArray[k] == 1 || RoundArray[k] == 2 || RoundArray[k] == 3 || RoundArray[k] == 4 || RoundArray[k] == 5 || RoundArray[k] == 6)
            {
                RoundArray[k] = 0;
            }

            else if (RoundArray[k] == 17)
            {
                RoundArray[k] = 1;
            }

            else if (RoundArray[k] == 10 || RoundArray[k] == 11)
            {
                RoundArray[k] = 2;
            }

            else if (RoundArray[k] == 12 || RoundArray[k] == 13)
            {
                RoundArray[k] = 3;
            }
            else if (RoundArray[k] == 14 || RoundArray[k] == 15 || RoundArray[k] == 16)
            {
                RoundArray[k] = 4;
            }
            else if (RoundArray[k] == 7 || RoundArray[k] == 8 || RoundArray[k] == 9)
            {
                RoundArray[k] = 5;
            }
        }
    }

    public void ImportBoskillImage()
    {
        int round = FindObjectOfType<SkillJudgment>().Round;
        if (round != 21)
        {
            BossSkillImage.sprite = BossSkillSprite[RoundArray[round - 1]];
            /*NextBossSkillImage.sprite = BossSkillSprite[RoundArray[round]];
            NBSI.SetActive(true);*/
        }

        else if(round==21)
        {
            FindObjectOfType<SkillJudgment>().Round = 1;
            _GenerateBossSkill();
        }

        /* else
         {
             BossSkillImage.sprite = BossSkillSprite[RoundArray[round - 1]];
             NBSI.SetActive(false);
         }*/
    }
}
