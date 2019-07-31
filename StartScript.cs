using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{

    public void Lvl1_OnClick()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Lvl2_OnClick()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void Lvl3_OnClick()
    {
        SceneManager.LoadScene("Level 3");
    }
   
}
