using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventTrigger_UI : MonoBehaviour
{
    public bool isEnableClick_Skill;

    public GameObject AtkButton, DefButton, HealButton;

    public Animator ani_ATK;

    public Button ATK_Button;
    
    private void Start()
    {
        

    }
  

    public void Enter_ATK()
    {
        ani_ATK.SetBool("Up", false);
    }

    public void Exit_ATK()
    {
        ani_ATK.SetBool("Down", false);
    }


}
