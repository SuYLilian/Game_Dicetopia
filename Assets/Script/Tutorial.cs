using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public int tutorial = 0;
    public float ArrowPos_t;
    public GameObject Arrow_t;
    public Button StopButton_t, ATK_Button_t;
    public GameObject Blurborder_ATK_t;
    public float ATK_value;
    public RectTransform Transform_ATK_t;
    public GameObject[] PosPanel_t = new GameObject[2];
    public Image StopButton_Image_t;
    public Sprite[] StopButton_Sprite_t = new Sprite[2];
    public float PlayerHealth_t, BossHealth_t;

    public Image ATK_image_t, Def_image_t, Heal_image_t;
    public Sprite ATK_sprite_t, Def_sprite_t, Heal_sprite_t;

    public GameObject DialogPanel;

    public TextMeshProUGUI DialogText;
    public string[] sentences = new string[6];
    public float typingSpeed;

    public Animator ani_PlayerTurn_t, ani_BossTurn_t;

    public GameObject skillMenu_tutorial, enegeryBar_tutorial;

    public GameObject dialogContinueButton;

    public GameObject attackArray_t, playerShadow_t, Dice_t;

    public Animator ani_attackArray_t, ani_Player_t, ani_Dice_t, ani_Boss_t, ani_Camera_t;

    string skillArrayName_t, skillArrayNum_t;

    public Image HealthBar_Boss_t,HealthBar_Player_t;

    public Canvas bossHealthCanvas, playerHealthCanvas;
    public SpriteRenderer bossSpriteRender, playerHealthFrameSpriteRender_R2, playerHealthFrameSpriteRender_R1;

    public TextMeshProUGUI playerHealthText_t;

    private void Start()
    {
        StartCoroutine(Type());
    }
    public void clickStop()
    {
        FindObjectOfType<IndexManergy>().Speed = 0;
        FindObjectOfType<IndexManergy>().Speed = 0;
        StopButton_Image_t.sprite = StopButton_Sprite_t[1];
        StopButton_t.interactable = false;
        ArrowPos_t = Arrow_t.transform.position.x;
        PosPanel_t[0].SetActive(true);
        PosPanel_t[1].SetActive(true);

        if (ArrowPos_t <= -1.93)
        {
            FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[8]);
            BossHealth_t -= (ATK_value * 1) + 5;
            skillArrayName_t = "AttackArray";
            skillArrayNum_t = "1";
            StartCoroutine(ATK_Player_t());
            //_SkillNum = FindObjectOfType<GenerateSkill>().PosArray[0];

        }

        else if (ArrowPos_t > -1.93 && ArrowPos_t <= -0.49)
        {
            FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[9]);
            DialogPanel.SetActive(true);
            tutorial = 9;
            StartCoroutine(Type());
            //_SkillNum = FindObjectOfType<GenerateSkill>().PosArray[1];

        }

        else if (ArrowPos_t > -0.49 && ArrowPos_t <= 0.792)
        {
            FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[8]);
            BossHealth_t -= (ATK_value * 3) + 5;
            skillArrayName_t = "AttackArray";
            skillArrayNum_t = "3";
            StartCoroutine(ATK_Player_t());
            //_SkillNum = FindObjectOfType<GenerateSkill>().PosArray[2];

        }

        else if (ArrowPos_t > 0.792 && ArrowPos_t <= 1.806)
        {
            FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[9]);
            DialogPanel.SetActive(true);
            tutorial = 9;
            StartCoroutine(Type());
            //_SkillNum = FindObjectOfType<GenerateSkill>().PosArray[3];

        }

        else if (ArrowPos_t > 1.806 && ArrowPos_t <= 2.646)
        {
            FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[9]);
            DialogPanel.SetActive(true);
            tutorial = 9;
            StartCoroutine(Type());
            //_SkillNum = FindObjectOfType<GenerateSkill>().PosArray[4];

        }

        else if (ArrowPos_t > 2.646)
        {
            FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[9]);
            DialogPanel.SetActive(true);
            tutorial = 9;
            StartCoroutine(Type());
            //_SkillNum = FindObjectOfType<GenerateSkill>().PosArray[5];

        }
    }

    public void Click_ATK()
    {
        Transform_ATK_t.position = new Vector2(-866, -434);
        Blurborder_ATK_t.SetActive(true);
        PosPanel_t[0].SetActive(false);
        PosPanel_t[1].SetActive(false);
        StopButton_Image_t.sprite = StopButton_Sprite_t[0];
        ATK_Button_t.interactable = false;
        StartCoroutine(AfterSelectSkill());
    }

    IEnumerator Type()
    {
        dialogContinueButton.SetActive(false);
        foreach (char letter in sentences[tutorial].ToCharArray())
        {
            DialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        tutorial++;
        dialogContinueButton.SetActive(true);

    }

    public void click_Continue()
    {
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[5]);
        dialogContinueButton.SetActive(false);
        if (tutorial == 1)
        {
            DialogText.text = "";
            DialogPanel.SetActive(false);
            StartCoroutine(Tutorial_1());
        }
        else if (tutorial == 2)
        {
            DialogText.text = "";
            StartCoroutine(Type());
        }
        else if (tutorial == 3)
        {
            Destroy(skillMenu_tutorial);
            DialogText.text = "";
            DialogPanel.SetActive(false);
            ATK_image_t.sprite = ATK_sprite_t;
            Def_image_t.sprite = Def_sprite_t;
            Heal_image_t.sprite = Heal_sprite_t;
            FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[7]);
            ani_PlayerTurn_t.Play("PlayerTurn_Show");
            ATK_Button_t.interactable = true;
        }
        else if (tutorial == 4)
        {
            DialogText.text = "";
            StartCoroutine(Type());
        }
        else if (tutorial == 5)
        {
            DialogText.text = "";
            Destroy(enegeryBar_tutorial);
            DialogPanel.SetActive(false);
            FindObjectOfType<IndexManergy>().Speed = FindObjectOfType<IndexManergy>().SpeedNum;
            PosPanel_t[0].SetActive(false);
            PosPanel_t[1].SetActive(false);
            StopButton_t.interactable = true;
        }
        else if(tutorial==6)
        {
            bossHealthCanvas.sortingLayerName = "UI";
            bossHealthCanvas.sortingOrder = 0;
            DialogText.text = "";
            DialogPanel.SetActive(false);
            StartCoroutine(ChangeTurn());
        }
        else if(tutorial==7)
        {
            DialogText.text = "";
            DialogPanel.SetActive(false);
            StartCoroutine(BossAttack_t());
        }
        else if(tutorial==8)
        {
            DialogText.text = "";
            playerHealthCanvas.sortingLayerName = "UI";
            playerHealthFrameSpriteRender_R2.sortingLayerName = "UI";
            playerHealthFrameSpriteRender_R1.sortingLayerName = "BG";
            playerHealthCanvas.sortingOrder = 3;
            playerHealthFrameSpriteRender_R2.sortingOrder = 3;
            playerHealthFrameSpriteRender_R1.sortingOrder = 1;
            StartCoroutine(Type());
        }
        else if(tutorial==9)
        {
            SceneManager.LoadScene(1);
        }
        else if(tutorial==10)
        {
            DialogText.text = "";
            DialogPanel.SetActive(false);
            FindObjectOfType<IndexManergy>().Speed = FindObjectOfType<IndexManergy>().SpeedNum;
            StopButton_Image_t.sprite = StopButton_Sprite_t[0];
            PosPanel_t[0].SetActive(false);
            PosPanel_t[1].SetActive(false);
            StopButton_t.interactable = true;
        }
    }

    IEnumerator Tutorial_1()
    {
        yield return new WaitForSeconds(2);
        DialogPanel.SetActive(true);
        skillMenu_tutorial.SetActive(true);
        StartCoroutine(Type());
    }

    IEnumerator AfterSelectSkill()
    {
        yield return new WaitForSeconds(1.5f);
        DialogPanel.SetActive(true);
        enegeryBar_tutorial.SetActive(true);
        StartCoroutine(Type());
    }

    IEnumerator ATK_Player_t()
    {
        yield return new WaitForSeconds(1f);
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[4]);
        attackArray_t.SetActive(true);
        playerShadow_t.SetActive(false);
        ani_attackArray_t.Play(skillArrayName_t + "_" + skillArrayNum_t);
        ani_Player_t.Play("Player_attack");
        yield return new WaitForSeconds(1f);
        Dice_t.SetActive(true);
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[3]);
        ani_Dice_t.Play("RullDice");
        yield return new WaitForSeconds(1.32f);
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[0]);
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[1]);
        ani_Boss_t.Play("Boss1_injuried");
        ani_Camera_t.SetTrigger("Shake");
        HealthBar_Boss_t.fillAmount = BossHealth_t / 220;
        Dice_t.SetActive(false);
        yield return new WaitForSeconds(2f);
        attackArray_t.SetActive(false);
        playerShadow_t.SetActive(true);
        DialogPanel.SetActive(true);
        tutorial = 5;
        bossHealthCanvas.sortingLayerName = "Tutorial";
        bossHealthCanvas.sortingOrder = 4;
        StartCoroutine(Type());
    }

    IEnumerator ChangeTurn()
    {
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[7]);
        ani_BossTurn_t.Play("BossTurn_Show");
        ani_PlayerTurn_t.Play("PlayerTurn_Back");
        yield return new WaitForSeconds(1.5f);
        DialogPanel.SetActive(true);
        StartCoroutine(Type());
    }

    IEnumerator BossAttack_t()
    {
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[10]);
        ani_Boss_t.Play("Boss1_attack");
        yield return new WaitForSeconds(1f);
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[6]);
        ani_Player_t.Play("PlayerInjuried");
        ani_Camera_t.SetTrigger("Shake");
        HealthBar_Player_t.fillAmount = (PlayerHealth_t-20) / 100;
        playerHealthText_t.text = 80.ToString();
        yield return new WaitForSeconds(1f);
        DialogPanel.SetActive(true);
        playerHealthCanvas.sortingLayerName="Tutorial";
        playerHealthFrameSpriteRender_R2.sortingLayerName = "Tutorial";
        playerHealthFrameSpriteRender_R1.sortingLayerName = "Tutorial";
        playerHealthCanvas.sortingOrder = 5;
        playerHealthFrameSpriteRender_R2.sortingOrder = 6;
        playerHealthFrameSpriteRender_R1.sortingOrder = 4;
        StartCoroutine(Type());
    }
}
