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
        GetComponent<AudioSource>().Play();
        MainMenu.gameObject.SetActive(false);
        tutorialMenu.gameObject.SetActive(true);
    }
    public void OnClickBack()
    {
        GetComponent<AudioSource>().Play();

        MainMenu.gameObject.SetActive(true);
        tutorialMenu.gameObject.SetActive(false);
    }
    public void OnClickQuit()
    {
        GetComponent<AudioSource>().Play();

        Application.Quit();
    }

    public void OnClickPlay()
    {
        StartCoroutine(ClickPlayTimer());
    }
    IEnumerator ClickPlayTimer()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(gameSceneName);

    }
}   
