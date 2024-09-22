using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpriteGlow;

public class GlowEditor : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Sprite sprite,sprite_shadow;
    void Update()
    {
        if(FindObjectOfType<SkillMenu>().canClickSkillMenu == false)
        {
            if (transform.position.x <= -1.93&& FindObjectOfType<GenerateSkill>().PosArray[0]== FindObjectOfType<SkillMenu>().SkillOption)
            {
                spriteRenderer.sprite = sprite_shadow;
            }

            else if (transform.position.x > -1.93 && transform.position.x <= -0.49 && FindObjectOfType<GenerateSkill>().PosArray[1] == FindObjectOfType<SkillMenu>().SkillOption)
            {
                spriteRenderer.sprite = sprite_shadow;

            }

            else if (transform.position.x > -0.49 && transform.position.x <= 0.792 && FindObjectOfType<GenerateSkill>().PosArray[2] == FindObjectOfType<SkillMenu>().SkillOption)
            {
                spriteRenderer.sprite = sprite_shadow;

            }

            else if (transform.position.x > 0.792 && transform.position.x <= 1.806 && FindObjectOfType<GenerateSkill>().PosArray[3] == FindObjectOfType<SkillMenu>().SkillOption)
            {
                spriteRenderer.sprite = sprite_shadow;

            }

            else if (transform.position.x > 1.806 && transform.position.x <= 2.646 && FindObjectOfType<GenerateSkill>().PosArray[4] == FindObjectOfType<SkillMenu>().SkillOption)
            {
                spriteRenderer.sprite = sprite_shadow;

            }

            else if (transform.position.x > 2.646 && FindObjectOfType<GenerateSkill>().PosArray[5] == FindObjectOfType<SkillMenu>().SkillOption)
            {
                spriteRenderer.sprite = sprite_shadow;

            }

            else
            {
                spriteRenderer.sprite = sprite;
            }
        }

        else
        {
            spriteRenderer.sprite = sprite;
        }

    }
}
