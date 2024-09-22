using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource audioSource;

    public void PlayClip(AudioClip _clip)
    {
        audioSource.PlayOneShot(_clip);
    }

    public void Card_Slip()
    {
        if(FindObjectOfType<SkillMenu>().canClickSkillMenu==true)
        {
            PlayClip(clips[2]);
        }
        else
        {
            Debug.Log("No audio");
        }
    }

    public void CardSlip_tutorial()
    {
        if(FindObjectOfType<Tutorial>().ATK_Button_t.interactable==true)
        {
            PlayClip(clips[2]);
        }
    }
}
