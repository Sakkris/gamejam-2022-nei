using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{

    public static GameOverHandler instance = null;

    [SerializeField] string menuSceneName;
    [SerializeField] string thisSceneName;
    [SerializeField] Canvas UI;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Image image;
    [SerializeField] Image image1;

    private void Awake()
    {
        instance = this;
    }
    public void OnClickRetry()
    {
        SceneManager.LoadScene(thisSceneName);
    }    
    public void OnClickQuit()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    public void OnDie()
    {
        UI.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(true);
        StartCoroutine(FadeImage(false));
       
    }
    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                image.color = new Color(1, 1, 1, i);
                image1.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                image.color = new Color(1, 1, 1, i);
                image1.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
