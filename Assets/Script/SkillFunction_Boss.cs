using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillFunction_Boss 
{
    public float DEF_Boss, ATK_Boss_Low, ATK_Boss_Heigh, HEAL_Boss;

    public SkillFunction_Boss(float _DEF_Boss, float _ATK_Boss_Low, float _ATK_Boss_Heigh, float _HEAL_Boss)
    {
        DEF_Boss = _DEF_Boss;
        ATK_Boss_Low = _ATK_Boss_Low;
        ATK_Boss_Heigh = _ATK_Boss_Heigh;
        HEAL_Boss = _HEAL_Boss;
    }

    /*public int Skill_DEF_Boss()
    {
        return DEF_Boss;
    }

    public int Skill_ATK_Low()
    {
        return ATK_Boss_Low;
    }

    public int Skill_ATK_Heigh()
    {
        return ATK_Boss_Heigh;
    }

    public int Skill_HEAL_Boss()
    {
        return HEAL_Boss;
    }*/
}
