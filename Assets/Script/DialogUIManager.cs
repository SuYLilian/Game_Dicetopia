using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DialogUIManager : MonoBehaviour
{
    public void AnewButton()
    {
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[5]);
        SceneManager.LoadScene(2);
    }

    public void SkipButton()
    {
        FindObjectOfType<Audio>().PlayClip(FindObjectOfType<Audio>().clips[5]);
        SceneManager.LoadScene(1);

    }
}
