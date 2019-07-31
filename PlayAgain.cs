using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
       public void btnPA_OnClick()
        {
           SceneManager.LoadScene("StartScene");
        }
    public void btnPAlvl2_OnClick()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void btnPAlvl3_OnClick()
    {
        SceneManager.LoadScene("Level 3");
    }
}