using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public GM s_GM;
    int CurrentScene;
    private void Start()
    {
        CurrentScene = SceneManager.GetActiveScene().buildIndex;    
    }
    public void MainMenu_Button()
    {
        SceneManager.LoadScene(0);
    }
    public void Option_Button()
    {

    }
    public void Exit_Button()
    {
        Application.Quit();
    }
    public void StageSelect()
    {
        SceneManager.LoadScene(1);
    }
    public void StageSelect_Stage1()
    {
        SceneManager.LoadScene(2);
    }
    public void StageSelect_Endless()
    {
        SceneManager.LoadScene(3);
    }
    public void ResumeButton()
    {
        Time.timeScale = 1f;
        s_GM.b_isEsc = false;
    }
    public void RetryButton()
    {
        SceneManager.LoadSceneAsync(CurrentScene);
    }
}
