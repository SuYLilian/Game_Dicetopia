using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillJudgment : MonoBehaviour
{
    public float PlayerHealth = 100, BossHealth = 300;

    public GameObject Arrow;
    float ArrowPos;

    public int DiceNum;

    public int _SkillNum;
    public int BossSkillNum;

    public int Round = 1;

    public bool isCurse = false;
    public bool isDef_boss = false;

    SkillFunction SF_1 = new SkillFunction(0.1f, 5f, 5);
    SkillFunction_Boss SFB_1 = new SkillFunction_Boss(100, 20, 50, 20);

    public Image PlayerSkillImage;
    public Sprite[] PlayerSkillSprite = new Sprite[5];
    //public GameObject PSI;

    /*public GameObject LoseImage;
    public GameObject Operation;
    public Text OperationText;*/

    //public GameObject CloseUpPanel;

    public Animator  ani_Player, ani_Boss, ani_Dice, ani_PlayerTurn, ani_BossTurn, ani_Camera;
    public GameObject BossFire, BossHeal, BossCurse;

    public GameObject Dice;
    public GameObject CurseIcon, playerDefIcon;
    public GameObject BossDefIcon;

    public GameObject FailPanel, WinPanel;

    public Image HealthBar_Boss, HealthBar_Player;

    public Button StopButton;

    //int Audio_r;

    public GameObject[] Blurborder = new GameObject[3];

    public Image Image_ATK, Image_Def, Image_Heal;
    public Sprite[] SkillMenuSprite = new Sprite[3];

    public GameObject BossShadow;

    public SpriteRenderer spriteRenderer_target;
    public Sprite sprite_target, sprite_target_glow;

    public string skillArrayName;
    public string skillArrayNum;

    public Animator ani_attackArray,ani_DefArray,ani_HealArray;

    public GameObject attackArray, playerShadow, DefArray,healArray;

    public TextMeshProUGUI playerHealthText;
    private void Start()
    {
        StartCoroutine(CloseUp_Player());
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.W))
        {
            BossHealth = 0;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerHealth = 0;
        }
    }

    public void PressSpace()
    {
        FindObjectOfType<IndexManergy>().Speed = 0;
        FindObjectOfType<IndexManergy>().Speed = 0;
        StopButton.interactable = false;
        FindObjectOfType<SkillMenu>().ATK_Button.interactable = false;
        FindObjectOfType<SkillMenu>().Def_Button.interactable = false;
        FindObjectOfType<SkillMenu>().Heal_Button.interactable = false;
        FindObjectOfType<SkillMenu>().StopButtonImage.sprite = FindObjectOfType<SkillMenu>().StopButtonSprite[1];
        ArrowPos = Arrow.transform.position.x;
        FindObjectOfType<SkillMenu>().canClickSkillMenu = false;

        if (ArrowPos <= -1.93)
        {
            DiceNum = 1;
            skillArrayNum = "1";
            _SkillNum = FindObjectOfType<GenerateSkill>().PosArray[0];
            /*PlayerSkillImage.sprite = PlayerSkillSprite[_SkillNum];
            PSI.SetActive(true);*/
        }

        else if (ArrowPos > -1.93 && ArrowPos <= -0.49)
        {
            DiceNum = 2;
            skillArrayNum = "2";

            _SkillNum = FindObjectOfType<GenerateSkill>().PosArray[1];
            /* PlayerSkillImage.sprite = PlayerSkillSprite[_SkillNum];
             PSI.SetActive(true);*/
        }

        else if (ArrowPos > -0.49 && ArrowPos <= 0.792)
        {
            DiceNum = 3;
            skillArrayNum = "3";

            _SkillNum = FindObjectOfType<GenerateSkill>().PosArray[2];
            /* PlayerSkillImage.sprite = PlayerSkillSprite[_SkillNum];
             PSI.SetActive(true);*/
        }

        else if (ArrowPos > 0.792 && ArrowPos <= 1.806)
        {
            DiceNum = 4;
            skillArrayNum = "4";

            _SkillNum = FindObjectOfType<GenerateSkill>().PosArray[3];
            /* PlayerSkillImage.sprite = PlayerSkillSprite[_SkillNum];
             PSI.SetActive(true);*/
        }

        else if (ArrowPos > 1.806 && ArrowPos <= 2.646)
        {
            DiceNum = 5;
            skillArrayNum = "5";

            _SkillNum = FindObjectOfType<GenerateSkill>().PosArray[4];
            /* PlayerSkillImage.sprite = PlayerSkillSprite[_SkillNum];
             PSI.SetActive(true);*/
        }

        else if (ArrowPos > 2.646)
        {
            DiceNum = 6;
            skillArrayNum = "6";

            _SkillNum = FindObjectOfType<GenerateSkill>().PosArray[5];
            /*PlayerSkillImage.sprite = PlayerSkillSprite[_SkillNum];
            PSI.SetActive(true);*/
        }

        BossSkillNum = FindObjectOfType<GenerateBossSkill>().RoundArray[Round - 1];

        Operation_Player();


    }

    public void Operation_Player()
    {
        if (_SkillNum == FindObjectOfType<SkillMenu>().SkillOption && _SkillNum == 2)
        {
            spriteRenderer_target.sprite = sprite_target_glow;
            FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[13]);
            skillArrayName = "DefArray_";
            /*OperationText.text = SF_1.Skill_DEF(DiceNum).ToString();
            Operation.SetActive(true);*/
            Debug.Log("Player is DEF");
            isCurse = false;
            isDef_boss = false;
            StartCoroutine(Def_Player());

        }

        else if (_SkillNum == FindObjectOfType<SkillMenu>().SkillOption && _SkillNum == 1 && isCurse == false)
        {
            /*OperationText.text = SF_1.Skill_ATK(DiceNum).ToString();
            Operation.SetActive(true);*/
            spriteRenderer_target.sprite = sprite_target_glow;
            FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[13]);
            skillArrayName = "AttackArray_";

            if (isDef_boss == true)
            {
                if (SF_1.Skill_ATK(DiceNum) > SFB_1.DEF_Boss)
                {
                    BossHealth -= SF_1.Skill_ATK(DiceNum) - SFB_1.DEF_Boss;
                    if (BossHealth <= 0)
                    {
                        BossHealth = 0;
                    }
                    else
                    {
                        Debug.Log("no");
                    }
                }

                else
                {
                    Debug.Log("Boss's health -0");
                }
            }
            else
            {
                BossHealth -= SF_1.Skill_ATK(DiceNum);
                if (BossHealth <= 0)
                {
                    BossHealth = 0;
                }
                else
                {
                    Debug.Log("no");
                }
            }
            isCurse = false;
            isDef_boss = false;
            StartCoroutine(ATK_Player());
        }

        else if (_SkillNum == FindObjectOfType<SkillMenu>().SkillOption && _SkillNum == 1 && isCurse == true)
        {
            /*OperationText.text = SF_1.Skill_ATK(DiceNum).ToString();
            Operation.SetActive(true);*/
            spriteRenderer_target.sprite = sprite_target_glow;
            FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[13]);
            skillArrayName = "AttackArray_";

            if (BossSkillNum == 3)
            {
                if ((int)(SF_1.Skill_ATK(DiceNum) / 2) > SFB_1.DEF_Boss)
                {
                    BossHealth -= (int)(SF_1.Skill_ATK(DiceNum) / 2) - SFB_1.DEF_Boss;
                    if (BossHealth <= 0)
                    {
                        BossHealth = 0;
                    }
                    else
                    {
                        Debug.Log("no");
                    }
                }

                else
                {
                    Debug.Log("Boss's health -0");
                }
            }
            else
            {
                BossHealth -= (int)(SF_1.Skill_ATK(DiceNum) / 2);
                if (BossHealth <= 0)
                {
                    BossHealth = 0;
                }
                else
                {
                    Debug.Log("no");
                }
            }

            isCurse = false;
            isDef_boss = false;
            StartCoroutine(ATK_Player());

        }

        else if (_SkillNum == FindObjectOfType<SkillMenu>().SkillOption && _SkillNum == 0)
        {
            /* OperationText.text = SF_1.Skill_HEAL(DiceNum).ToString();
             Operation.SetActive(true);*/
            spriteRenderer_target.sprite = sprite_target_glow;
            FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[13]);

            skillArrayName = "HealArray_";

            PlayerHealth += SF_1.Skill_HEAL(DiceNum);
            if (PlayerHealth > 100)
            {
                PlayerHealth = 100;
            }
            isCurse = false;
            isDef_boss = false;
            StartCoroutine(Heal_Player());
        }

        /*else if (_SkillNum != FindObjectOfType<SkillMenu>().SkillOption && _SkillNum == 1)
        {
            LoseImage.SetActive(true);

            PlayerHealth -= 3 * DiceNum;
            if (PlayerHealth <= 0)
            {
                PlayerHealth = 0;
            }
            else
            {
                Debug.Log("no");
            }
            isCurse = false;
            isDef_boss = false;
            StartCoroutine(Injuried_Player());

        }

        else if (_SkillNum != FindObjectOfType<SkillMenu>().SkillOption && _SkillNum == 0)
        {
            LoseImage.SetActive(true);

            isCurse = true;
            isDef_boss = false;
            StartCoroutine(Curse());

        }*/

        else
        {
            //LoseImage.SetActive(true);
            spriteRenderer_target.sprite = sprite_target;
            FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[14]);

            isCurse = false;
            isDef_boss = false;
            StartCoroutine(NoAction());
            Debug.Log("Player can't use skill");
        }
    }

    public void Operation_Boss()
    {
        if (BossSkillNum == 3)
        {
            isDef_boss = true;
        }

        else if (BossSkillNum == 0)
        {
            if (_SkillNum == FindObjectOfType<SkillMenu>().SkillOption && _SkillNum == 2)
            {
                PlayerHealth -= SFB_1.ATK_Boss_Low * SF_1.Skill_DEF(DiceNum);
            }

            else
            {
                PlayerHealth -= SFB_1.ATK_Boss_Low;
                if (PlayerHealth <= 0)
                {
                    PlayerHealth = 0;
                }
                else
                {
                    Debug.Log("no");
                }
            }
        }

        else if (BossSkillNum == 1)
        {
            if (_SkillNum == FindObjectOfType<SkillMenu>().SkillOption && _SkillNum == 2)
            {
                PlayerHealth -= SFB_1.ATK_Boss_Heigh * SF_1.Skill_DEF(DiceNum);
            }

            else
            {
                PlayerHealth -= SFB_1.ATK_Boss_Heigh;
                if (PlayerHealth <= 0)
                {
                    PlayerHealth = 0;
                }
                else
                {
                    Debug.Log("no");
                }
            }
        }

        else if (BossSkillNum == 2)
        {
            BossHealth += SFB_1.HEAL_Boss;
            if (BossHealth > 220)
            {
                BossHealth = 220;
            }
        }

        else if (BossSkillNum == 4)
        {
            isCurse = true;
        }

        else if (BossSkillNum == 5)
        {
            Debug.Log("Charge");
        }
    }

    IEnumerator CloseUp_Player()
    {
        yield return new WaitForSeconds(1.5f);
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[18]);
        ani_PlayerTurn.Play("PlayerTurn_Show");
        yield return new WaitForSeconds(0.5f);
        Image_Heal.sprite = SkillMenuSprite[0];
        Image_ATK.sprite = SkillMenuSprite[1];
        Image_Def.sprite = SkillMenuSprite[2];
        FindObjectOfType<SkillMenu>().ATK_Button.interactable = true;
        FindObjectOfType<SkillMenu>().Def_Button.interactable = true;
        FindObjectOfType<SkillMenu>().Heal_Button.interactable = true;
        FindObjectOfType<SkillMenu>().canClickSkillMenu = true;

    }

    IEnumerator Def_Player()
    {
        yield return new WaitForSeconds(1f);
        DefArray.SetActive(true);
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[6]);
        ani_DefArray.Play(skillArrayName + skillArrayNum);
        ani_Player.Play("Playre_Def");
        playerShadow.SetActive(false);
        yield return new WaitForSeconds(2);
        CurseIcon.SetActive(false);
        playerDefIcon.SetActive(true);
        yield return new WaitForSeconds(2);
        BossDefIcon.SetActive(false);
        DefArray.SetActive(false);
        playerShadow.SetActive(true);
        if (BossHealth <= 0 || PlayerHealth <= 0)
        {
            if (BossHealth <= 0)
            {
                ani_Boss.Play("Boss1_dead");
                BossFire.SetActive(false);
                BossShadow.SetActive(false);
                yield return new WaitForSeconds(1.5f);
            }
            else if (PlayerHealth <= 0)
            {
                ani_Player.Play("PlayerDead");
                yield return new WaitForSeconds(2.5f);
            }
            FailWin();
        }
        else
        {
            Operation_Boss();
            FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[18]);
            ani_BossTurn.Play("BossTurn_Show");
            ani_PlayerTurn.Play("PlayerTurn_Back");
            yield return new WaitForSeconds(1.5f);
            if (BossSkillNum == 0 || BossSkillNum == 1)
            {
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[15]);
                ani_Boss.Play("Boss1_attack");
                yield return new WaitForSeconds(1f);
                if(BossSkillNum==1)
                {
                    BossFire.SetActive(false);
                }
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[11]);
                ani_Player.Play("PlayerInjuried");
                ani_Camera.SetTrigger("Shake");
                HealthBar_Player.fillAmount = PlayerHealth / 100;
                playerHealthText.text = PlayerHealth.ToString();
                yield return new WaitForSeconds(2f);
            }
            else if (BossSkillNum == 2)
            {
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[7]);
                BossHeal.SetActive(true);
                yield return new WaitForSeconds(2f);
                BossHeal.SetActive(false);
                HealthBar_Boss.fillAmount = BossHealth / 220;
                yield return new WaitForSeconds(2f);
            }
            else if (BossSkillNum == 3)
            {
                BossDefIcon.SetActive(true);
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[4]);
                yield return new WaitForSeconds(2f);
            }
            else if (BossSkillNum == 4)
            {
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[17]);
                playerDefIcon.SetActive(false);
                BossCurse.SetActive(true);
                yield return new WaitForSeconds(4f);
                BossCurse.SetActive(false);
                CurseIcon.SetActive(true);
            }
            else if (BossSkillNum == 5)
            {
                BossFire.SetActive(true);
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[0]);
                yield return new WaitForSeconds(2f);
            }

            yield return new WaitForSeconds(0.5f);

            if (BossHealth <= 0 || PlayerHealth <= 0)
            {
                if (PlayerHealth <= 0)
                {
                    ani_Player.Play("PlayerDead");
                    yield return new WaitForSeconds(2.5f);
                }
                else if (BossHealth <= 0)
                {
                    ani_Boss.Play("Boss1_dead");
                    BossFire.SetActive(false);
                    BossShadow.SetActive(false);
                    yield return new WaitForSeconds(1.5f);
                }
                FailWin();
            }

            else
            {
                Round++;
                //RoundNumImage.sprite = RoundNumSprite[Round - 1];
                /*Operation.SetActive(false);
                LoseImage.SetActive(false);*/
                //PSI.SetActive(false);
                FindObjectOfType<GenerateBossSkill>().ImportBoskillImage();
                FindObjectOfType<GenerateSkill>().randomRailSKill();


                for (int i = 0; i < 3; i++)
                {
                    Blurborder[i].SetActive(false);
                }
                FindObjectOfType<SkillMenu>().ATK_Button.interactable = true;
                FindObjectOfType<SkillMenu>().Def_Button.interactable = true;
                FindObjectOfType<SkillMenu>().Heal_Button.interactable = true;

                //FindObjectOfType<IndexManergy>().Speed = FindObjectOfType<IndexManergy>().SpeedNum;
                FindObjectOfType<SkillMenu>().canClickSkillMenu = true;
                FindObjectOfType<SkillMenu>().haveSelected = false;
                for(int i=0;i<6;i++)
                {
                    FindObjectOfType<SkillMenu>().PosPanel[i].SetActive(true);
                }
                playerDefIcon.SetActive(false);
                spriteRenderer_target.sprite = sprite_target;
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[18]);
                ani_PlayerTurn.Play("PlayerTurn_Show");
                ani_BossTurn.Play("BossTurn_Back");
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    IEnumerator ATK_Player()
    {
        yield return new WaitForSeconds(1f);
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[5]);
        attackArray.SetActive(true);
        playerShadow.SetActive(false);
        ani_attackArray.Play(skillArrayName + skillArrayNum);
        ani_Player.Play("Player_attack");
        yield return new WaitForSeconds(1f);
        Dice.SetActive(true);
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[3]);
        ani_Dice.Play("RullDice");
        yield return new WaitForSeconds(1.32f);
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[1]);
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[16]);
        ani_Boss.Play("Boss1_injuried");
        ani_Camera.SetTrigger("Shake");
        HealthBar_Boss.fillAmount = BossHealth / 220;
        Dice.SetActive(false);
        CurseIcon.SetActive(false);
        BossDefIcon.SetActive(false);
        yield return new WaitForSeconds(2f);
        attackArray.SetActive(false);
        playerShadow.SetActive(true);

        if (BossHealth <= 0 || PlayerHealth <= 0)
        {
            if (BossHealth <= 0)
            {
                ani_Boss.Play("Boss1_dead");
                BossFire.SetActive(false);
                BossShadow.SetActive(false);
                yield return new WaitForSeconds(1.5f);
            }
            else if (PlayerHealth <= 0)
            {
                ani_Player.Play("PlayerDead");
                yield return new WaitForSeconds(2.5f);
            }
            FailWin();
        }
        else
        {
            Operation_Boss();
            FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[18]);
            ani_BossTurn.Play("BossTurn_Show");
            ani_PlayerTurn.Play("PlayerTurn_Back");
            yield return new WaitForSeconds(1.5f);
            if (BossSkillNum == 0 || BossSkillNum == 1)
            {
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[15]);
                ani_Boss.Play("Boss1_attack");
                yield return new WaitForSeconds(1f);
                if (BossSkillNum == 1)
                {
                    BossFire.SetActive(false);
                }
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[11]);
                ani_Player.Play("PlayerInjuried");
                ani_Camera.SetTrigger("Shake");
                HealthBar_Player.fillAmount = PlayerHealth / 100;
                playerHealthText.text = PlayerHealth.ToString();
                yield return new WaitForSeconds(2f);
            }
            else if (BossSkillNum == 2)
            {
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[7]);
                BossHeal.SetActive(true);
                yield return new WaitForSeconds(2f);
                BossHeal.SetActive(false);
                HealthBar_Boss.fillAmount = BossHealth / 220;
                yield return new WaitForSeconds(2f);
            }
            else if (BossSkillNum == 3)
            {
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[4]);
                BossDefIcon.SetActive(true);
                yield return new WaitForSeconds(2f);
            }
            else if (BossSkillNum == 4)
            {
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[17]);
                playerDefIcon.SetActive(false);
                BossCurse.SetActive(true);
                yield return new WaitForSeconds(4f);
                BossCurse.SetActive(false);
                CurseIcon.SetActive(true);
            }
            else if (BossSkillNum == 5)
            {
                BossFire.SetActive(true);
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[0]);
                yield return new WaitForSeconds(2f);
            }

            yield return new WaitForSeconds(0.5f);

            if (BossHealth <= 0 || PlayerHealth <= 0)
            {
                if (PlayerHealth <= 0)
                {
                    ani_Player.Play("PlayerDead");
                    yield return new WaitForSeconds(2.5f);
                }
                else if (BossHealth <= 0)
                {
                    ani_Boss.Play("Boss1_dead");
                    BossFire.SetActive(false);
                    BossShadow.SetActive(false);
                    yield return new WaitForSeconds(1.5f);
                }
                FailWin();
            }

            else
            {
                Round++;
                //RoundNumImage.sprite = RoundNumSprite[Round - 1];
                /*Operation.SetActive(false);
                LoseImage.SetActive(false);*/
                //PSI.SetActive(false);
                FindObjectOfType<GenerateBossSkill>().ImportBoskillImage();
                FindObjectOfType<GenerateSkill>().randomRailSKill();

                for (int i = 0; i < 3; i++)
                {
                    Blurborder[i].SetActive(false);
                }
                FindObjectOfType<SkillMenu>().ATK_Button.interactable = true;
                FindObjectOfType<SkillMenu>().Def_Button.interactable = true;
                FindObjectOfType<SkillMenu>().Heal_Button.interactable = true;

                //FindObjectOfType<IndexManergy>().Speed = FindObjectOfType<IndexManergy>().SpeedNum;
                FindObjectOfType<SkillMenu>().canClickSkillMenu = true;
                FindObjectOfType<SkillMenu>().haveSelected = false;

                for (int i = 0; i < 6; i++)
                {
                    FindObjectOfType<SkillMenu>().PosPanel[i].SetActive(true);
                }
                spriteRenderer_target.sprite = sprite_target;
                playerDefIcon.SetActive(false);
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[18]);
                ani_PlayerTurn.Play("PlayerTurn_Show");
                ani_BossTurn.Play("BossTurn_Back");
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    IEnumerator Heal_Player()
    {
        yield return new WaitForSeconds(1f);
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[8]);
        healArray.SetActive(true);
        playerShadow.SetActive(false);
        ani_HealArray.Play(skillArrayName + skillArrayNum);
        ani_Player.Play("Playre_Def");
        yield return new WaitForSeconds(2f);
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[7]);
        HealthBar_Player.fillAmount = PlayerHealth / 100;
        playerHealthText.text = PlayerHealth.ToString();
        CurseIcon.SetActive(false);
        BossDefIcon.SetActive(false);
        yield return new WaitForSeconds(2f);
        playerShadow.SetActive(true);
        healArray.SetActive(false);
        if (BossHealth <= 0 || PlayerHealth <= 0)
        {
            if (BossHealth <= 0)
            {
                ani_Boss.Play("Boss1_dead");
                BossFire.SetActive(false);
                BossShadow.SetActive(false);
                yield return new WaitForSeconds(1.5f);
            }
            else if (PlayerHealth <= 0)
            {
                ani_Player.Play("PlayerDead");
                yield return new WaitForSeconds(2.5f);
            }
            FailWin();
        }
        else
        {
            Operation_Boss();
            FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[18]);
            ani_BossTurn.Play("BossTurn_Show");
            ani_PlayerTurn.Play("PlayerTurn_Back");
            yield return new WaitForSeconds(1.5f);
            if (BossSkillNum == 0 || BossSkillNum == 1)
            {
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[15]);
                ani_Boss.Play("Boss1_attack");
                yield return new WaitForSeconds(1f);
                if (BossSkillNum == 1)
                {
                    BossFire.SetActive(false);
                }
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[11]);
                ani_Player.Play("PlayerInjuried");
                ani_Camera.SetTrigger("Shake");
                HealthBar_Player.fillAmount = PlayerHealth / 100;
                playerHealthText.text = PlayerHealth.ToString();
                yield return new WaitForSeconds(2f);
            }
            else if (BossSkillNum == 2)
            {
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[7]);
                BossHeal.SetActive(true);
                yield return new WaitForSeconds(2f);
                BossHeal.SetActive(false);
                HealthBar_Boss.fillAmount = BossHealth / 220;
                yield return new WaitForSeconds(2f);
            }
            else if (BossSkillNum == 3)
            {
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[4]);
                BossDefIcon.SetActive(true);
                yield return new WaitForSeconds(2f);
            }
            else if (BossSkillNum == 4)
            {
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[17]);
                playerDefIcon.SetActive(false);
                BossCurse.SetActive(true);
                yield return new WaitForSeconds(4f);
                BossCurse.SetActive(false);
                CurseIcon.SetActive(true);

            }
            else if (BossSkillNum == 5)
            {
                BossFire.SetActive(true);
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[0]);
                yield return new WaitForSeconds(2f);
            }
            yield return new WaitForSeconds(0.5f);

            if (BossHealth <= 0 || PlayerHealth <= 0)
            {
                if (PlayerHealth <= 0)
                {
                    ani_Player.Play("PlayerDead");
                    yield return new WaitForSeconds(2.5f);
                }
                else if (BossHealth <= 0)
                {
                    ani_Boss.Play("Boss1_dead");
                    BossFire.SetActive(false);
                    BossShadow.SetActive(false);
                    yield return new WaitForSeconds(1.5f);
                }
                FailWin();
            }

            else
            {
                Round++;
                //RoundNumImage.sprite = RoundNumSprite[Round - 1];
                /*Operation.SetActive(false);
                LoseImage.SetActive(false);*/
               // PSI.SetActive(false);
                FindObjectOfType<GenerateBossSkill>().ImportBoskillImage();
                FindObjectOfType<GenerateSkill>().randomRailSKill();

                for (int i = 0; i < 3; i++)
                {
                    Blurborder[i].SetActive(false);
                }
                FindObjectOfType<SkillMenu>().ATK_Button.interactable = true;
                FindObjectOfType<SkillMenu>().Def_Button.interactable = true;
                FindObjectOfType<SkillMenu>().Heal_Button.interactable = true;

                //FindObjectOfType<IndexManergy>().Speed = FindObjectOfType<IndexManergy>().SpeedNum;
                FindObjectOfType<SkillMenu>().canClickSkillMenu = true;
                FindObjectOfType<SkillMenu>().haveSelected = false;

                for (int i = 0; i < 6; i++)
                {
                    FindObjectOfType<SkillMenu>().PosPanel[i].SetActive(true);
                }
                spriteRenderer_target.sprite = sprite_target;
                playerDefIcon.SetActive(false);
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[18]);
                ani_PlayerTurn.Play("PlayerTurn_Show");
                ani_BossTurn.Play("BossTurn_Back");
                yield return new WaitForSeconds(0.5f);
            }
        }
    }


    IEnumerator NoAction()
    {
        yield return new WaitForSeconds(1f);
        CurseIcon.SetActive(false);
        BossDefIcon.SetActive(false);
        if (BossHealth <= 0 || PlayerHealth <= 0)
        {
            if (BossHealth <= 0)
            {
                ani_Boss.Play("Boss1_dead");
                BossFire.SetActive(false);
                BossShadow.SetActive(false);
                yield return new WaitForSeconds(1.5f);
            }
            else if (PlayerHealth <= 0)
            {
                ani_Player.Play("PlayerDead");
                yield return new WaitForSeconds(2.5f);
            }
            FailWin();
        }
        else
        {
            Operation_Boss();
            FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[18]);
            ani_BossTurn.Play("BossTurn_Show");
            ani_PlayerTurn.Play("PlayerTurn_Back");
            yield return new WaitForSeconds(1.5f);
            if (BossSkillNum == 0 || BossSkillNum == 1)
            {
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[15]);
                ani_Boss.Play("Boss1_attack");
                yield return new WaitForSeconds(1f);
                if (BossSkillNum == 1)
                {
                    BossFire.SetActive(false);
                }
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[11]);
                ani_Player.Play("PlayerInjuried");
                ani_Camera.SetTrigger("Shake");              
                HealthBar_Player.fillAmount = PlayerHealth / 100;
                playerHealthText.text = PlayerHealth.ToString();
                yield return new WaitForSeconds(2f);
            }
            else if (BossSkillNum == 2)
            {
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[7]);
                BossHeal.SetActive(true);
                yield return new WaitForSeconds(2f);
                BossHeal.SetActive(false);
                HealthBar_Boss.fillAmount = BossHealth / 220;
                yield return new WaitForSeconds(2f);
            }
            else if (BossSkillNum == 3)
            {
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[4]);
                BossDefIcon.SetActive(true);
                yield return new WaitForSeconds(2f);
            }
            else if (BossSkillNum == 4)
            {
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[17]);
                playerDefIcon.SetActive(false);
                BossCurse.SetActive(true);
                yield return new WaitForSeconds(4f);
                BossCurse.SetActive(false);
                CurseIcon.SetActive(true);

            }
            else if (BossSkillNum == 5)
            {
                BossFire.SetActive(true);
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[0]);
                yield return new WaitForSeconds(2f);
            }

            yield return new WaitForSeconds(0.5f);

            if (BossHealth <= 0 || PlayerHealth <= 0)
            {
                if (PlayerHealth <= 0)
                {
                    ani_Player.Play("PlayerDead");
                    yield return new WaitForSeconds(2.5f);
                }
                else if (BossHealth <= 0)
                {
                    ani_Boss.Play("Boss1_dead");
                    BossFire.SetActive(false);
                    BossShadow.SetActive(false);
                    yield return new WaitForSeconds(1.5f);
                }
                FailWin();
            }

            else
            {
                Round++;
                //RoundNumImage.sprite = RoundNumSprite[Round - 1];
                /*Operation.SetActive(false);
                LoseImage.SetActive(false);*/
               // PSI.SetActive(false);
                FindObjectOfType<GenerateBossSkill>().ImportBoskillImage();
                FindObjectOfType<GenerateSkill>().randomRailSKill();

                for (int i = 0; i < 3; i++)
                {
                    Blurborder[i].SetActive(false);
                }
                FindObjectOfType<SkillMenu>().ATK_Button.interactable = true;
                FindObjectOfType<SkillMenu>().Def_Button.interactable = true;
                FindObjectOfType<SkillMenu>().Heal_Button.interactable = true;

                //FindObjectOfType<IndexManergy>().Speed = FindObjectOfType<IndexManergy>().SpeedNum;
                FindObjectOfType<SkillMenu>().canClickSkillMenu = true;
                FindObjectOfType<SkillMenu>().haveSelected = false;

                for (int i = 0; i < 6; i++)
                {
                    FindObjectOfType<SkillMenu>().PosPanel[i].SetActive(true);
                }
                spriteRenderer_target.sprite = sprite_target;
                playerDefIcon.SetActive(false);
                FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[18]);
                ani_PlayerTurn.Play("PlayerTurn_Show");
                ani_BossTurn.Play("BossTurn_Back");
                yield return new WaitForSeconds(0.5f);
            }
        }
    }


    public void FailWin()
    {

        if (PlayerHealth <= 0)
        {
            FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[10]);
            FailPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else if (BossHealth <= 0)
        {
            FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[12]);
            WinPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
