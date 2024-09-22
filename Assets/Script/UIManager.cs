using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject volumePanel;
    public Slider volumeSlider;

    public GameObject PauseImage;
    public GameObject PausePanel;
    public Button SettingButton;



    public bool oldState_Space, oldState_SkillMenu;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&&Time.timeScale==1)
        {
            SettingButton.interactable = false;
            oldState_SkillMenu = FindObjectOfType<SkillMenu>().canClickSkillMenu;
            oldState_Space = FindObjectOfType<SkillJudgment>().StopButton.interactable;
            FindObjectOfType<SkillMenu>().canClickSkillMenu = false;
            FindObjectOfType<SkillJudgment>().StopButton.interactable = false;
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            SettingButton.interactable = true;
            FindObjectOfType<SkillMenu>().canClickSkillMenu = oldState_SkillMenu;
            FindObjectOfType<SkillJudgment>().StopButton.interactable = oldState_Space;
            PausePanel.SetActive(false);
            volumePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void BackToMenu()
    {
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[9]);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void StartButton()
    {
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[0]);
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[0]);
        Application.Quit();
    }

    public void Option()
    {
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[0]);
        volumePanel.SetActive(true);
    }

    public void Option_Back()
    {
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[0]);
        volumePanel.SetActive(false);

    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    public void Option_Game()
    {
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[9]);
        PauseImage.SetActive(false);
        volumePanel.SetActive(true);
    }

    public void Option_Back_Game()
    {
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[9]);
        volumePanel.SetActive(false);
        PauseImage.SetActive(true);
    }

    public void Resume()
    {
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[9]);
        FindObjectOfType<SkillMenu>().canClickSkillMenu = oldState_SkillMenu;
        FindObjectOfType<SkillJudgment>().StopButton.interactable = oldState_Space;
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        SettingButton.interactable = true;
    }

    public void Setting()
    {
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[9]);
        oldState_SkillMenu = FindObjectOfType<SkillMenu>().canClickSkillMenu;
        oldState_Space = FindObjectOfType<SkillJudgment>().StopButton.interactable;
        FindObjectOfType<SkillMenu>().canClickSkillMenu = false;
        FindObjectOfType<SkillJudgment>().StopButton.interactable = false;
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        SettingButton.interactable = false;


    }

}
