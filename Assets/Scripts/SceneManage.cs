using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneManage : MonoBehaviour
{
    public void LoadLevelOne()
    {
        //load scene 3 in build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // 3
    }
    public void LoadLevelTwo()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); // 4

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
