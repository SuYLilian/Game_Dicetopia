using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFunction 
{
    public float DEF, ATK, HEAL;
    public float DEF_Boss, ATK_Boss, HEAL_Boss;

    public SkillFunction(float _DEF, float _ATK, float _HEAL)
    {
        DEF = _DEF;
        ATK = _ATK;
        HEAL = _HEAL;
    }

    public float Skill_DEF(float DiceValue)
    {
        float DefValue = 1-(DEF * (DiceValue+2));
        return DefValue;
    }
    public float Skill_ATK(float DiceValue)
    {
        return (ATK * DiceValue)+5;
    }

    public float Skill_HEAL(float DiceValue)
    {
        return (HEAL * DiceValue)+5;
    }

}
