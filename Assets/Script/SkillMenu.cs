using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillMenu : MonoBehaviour
{
    
    public int SkillOption;

    //public Sprite[] SkillMenuSprite = new Sprite[3];
    //public Image SkillMenuImage;
    //public GameObject SMI;
    public bool canClickSkillMenu=false;

    public Button ATK_Button,Def_Button, Heal_Button;

    public GameObject Blurborder_ATK, Blurborder_Def, Blurborder_Heal;

    public GameObject[] PosPanel = new GameObject[6];

    public Image StopButtonImage;
    public Sprite[] StopButtonSprite=new Sprite[2];

    public RectTransform Transform_ATK, Transform_Def, Transform_Heal;

    public bool haveSelected=false;

    public void Select_ATK()
    {
        if (canClickSkillMenu == true && haveSelected == false)
        {
            Blurborder_ATK.SetActive(true);
            Blurborder_Def.SetActive(false);
            Blurborder_Heal.SetActive(false);
            
            Def_Button.interactable = true;
            Heal_Button.interactable = true;
            ATK_Button.interactable = false;

            Transform_ATK.position = new Vector2(-866,-434);


            SkillOption = 1;

            FindObjectOfType<SkillJudgment>().StopButton.interactable = true;
            StopButtonImage.sprite = StopButtonSprite[0];
            FindObjectOfType<IndexManergy>().Speed = FindObjectOfType<IndexManergy>().SpeedNum;
            for(int i=0;i<6;i++)
            {
                if(FindObjectOfType<GenerateSkill>().PosArray[i]==SkillOption)
                {
                    PosPanel[i].SetActive(false);
                }
                
            }

            haveSelected = true;
        }

        else if(haveSelected==true && canClickSkillMenu==true)
        {
            Blurborder_ATK.SetActive(true);
            Blurborder_Def.SetActive(false);
            Blurborder_Heal.SetActive(false);

            Def_Button.interactable = true;
            Heal_Button.interactable = true;
            ATK_Button.interactable = false;

            Transform_ATK.position = new Vector2(-866,-434);


            SkillOption = 1;

            for (int i = 0; i < 6; i++)
            {
                if (FindObjectOfType<GenerateSkill>().PosArray[i] == SkillOption)
                {
                    PosPanel[i].SetActive(false);
                }
                else
                {
                    PosPanel[i].SetActive(true);
                }
            }

        }
    }

    public void Select_DEF()
    {
        if (canClickSkillMenu == true && haveSelected == false)
        {
            Blurborder_ATK.SetActive(false);
            Blurborder_Def.SetActive(true);
            Blurborder_Heal.SetActive(false);

            ATK_Button.interactable = true;
            Heal_Button.interactable = true;
            Def_Button.interactable = false;

            Transform_Def.position = new Vector2(-687, -434);

            SkillOption = 2;

            FindObjectOfType<SkillJudgment>().StopButton.interactable = true;
            StopButtonImage.sprite = StopButtonSprite[0];
            FindObjectOfType<IndexManergy>().Speed = FindObjectOfType<IndexManergy>().SpeedNum;
            for (int i = 0; i < 6; i++)
            {
                if (FindObjectOfType<GenerateSkill>().PosArray[i] == SkillOption)
                {
                    PosPanel[i].SetActive(false);
                }
            }

            haveSelected = true;

        }

        else if (haveSelected == true && canClickSkillMenu == true)
        {
            Blurborder_ATK.SetActive(false);
            Blurborder_Def.SetActive(true);
            Blurborder_Heal.SetActive(false);

            ATK_Button.interactable = true;
            Heal_Button.interactable = true;
            Def_Button.interactable = false;

            Transform_Def.position = new Vector2(-687, -434);

            SkillOption = 2;

            for (int i = 0; i < 6; i++)
            {
                if (FindObjectOfType<GenerateSkill>().PosArray[i] == SkillOption)
                {
                    PosPanel[i].SetActive(false);
                }
                else
                {
                    PosPanel[i].SetActive(true);
                }
            }
        }

    }

    public void Select_HEAL()
    {
        if (canClickSkillMenu == true && haveSelected==false)
        {
            Blurborder_ATK.SetActive(false);
            Blurborder_Def.SetActive(false);
            Blurborder_Heal.SetActive(true);

            ATK_Button.interactable = true;
            Def_Button.interactable = true;
            Heal_Button.interactable = false;

            Transform_Def.position = new Vector2(-509, -434);

            SkillOption = 0;

            FindObjectOfType<SkillJudgment>().StopButton.interactable = true;
            StopButtonImage.sprite = StopButtonSprite[0];
            FindObjectOfType<IndexManergy>().Speed = FindObjectOfType<IndexManergy>().SpeedNum;
            for (int i = 0; i < 6; i++)
            {
                if (FindObjectOfType<GenerateSkill>().PosArray[i] == SkillOption)
                {
                    PosPanel[i].SetActive(false);
                }
            }

            haveSelected = true;

        }

        else if (haveSelected == true && canClickSkillMenu == true)
        {
            Blurborder_ATK.SetActive(false);
            Blurborder_Def.SetActive(false);
            Blurborder_Heal.SetActive(true);

            ATK_Button.interactable = true;
            Def_Button.interactable = true;
            Heal_Button.interactable = false;

            Transform_Def.position = new Vector2(-509, -434);

            SkillOption = 0;

            for (int i = 0; i < 6; i++)
            {
                if (FindObjectOfType<GenerateSkill>().PosArray[i] == SkillOption)
                {
                    PosPanel[i].SetActive(false);
                }
                else
                {
                    PosPanel[i].SetActive(true);
                }
            }
        }
    }

}
