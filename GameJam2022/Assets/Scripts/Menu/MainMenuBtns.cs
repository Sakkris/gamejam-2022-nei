using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBtns : MonoBehaviour
{
    [SerializeField] Canvas MainMenu;
    [SerializeField] Canvas tutorialMenu;
    [SerializeField] string gameSceneName;



    public void OnClickTutorial()
    {
        MainMenu.gameObject.SetActive(false);
        tutorialMenu.gameObject.SetActive(true);
    }
    public void OnClickBack()
    {
        MainMenu.gameObject.SetActive(true);
        tutorialMenu.gameObject.SetActive(false);
    }
    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}   
