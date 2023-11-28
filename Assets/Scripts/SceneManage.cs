using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneManage : MonoBehaviour
{
    public void LoadLevelOne()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("Delivery_Outside");
    }
    public void LoadLevelThree()
    {

    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadHandbook()
    {
        SceneManager.LoadScene("HandbookScene");
    }
    public void LoadCredit()
    {
        SceneManager.LoadScene("CreditsScene");
    }
}
