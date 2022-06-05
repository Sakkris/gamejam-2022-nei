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
    [SerializeField] Canvas backgroundCanvas;
    CanvasGroup canvasGroup;
    CanvasGroup canvasbackGroup;

    private void Awake()
    {
        instance = this;
        canvasGroup = gameOverCanvas.GetComponent<CanvasGroup>();
        canvasbackGroup = backgroundCanvas.GetComponent<CanvasGroup>();
    }
    public void OnClickRetry()
    {
        StartCoroutine(ClickRetry());

    }
    public void OnClickQuit()
    {
        StartCoroutine(ClickQuit());
    }

    public void OnDie()
    {
        UI.gameObject.SetActive(false);
        gameOverCanvas.gameObject.SetActive(true);
        backgroundCanvas.gameObject.SetActive(true);
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
                canvasGroup.alpha = i;
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
                if (i > 0.98)
                {
                    canvasbackGroup.alpha = 1;
                }
                else
                {
                    canvasbackGroup.alpha = i;
                }

            yield return null;
            }
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                if (i > 0.98)
                {
                    canvasGroup.alpha = 1;
                    yield break;
                }
                else
                {
                    canvasGroup.alpha = i;
                }
                
                yield return null;
            }
        }
    }

    IEnumerator ClickQuit()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(menuSceneName);

    }
    IEnumerator ClickRetry()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(thisSceneName);
    }
}
