using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgainBtn :MonoBehaviour
{
    [SerializeField] string gameSceneName;
    public void TryAgain()
    {
        Debug.Log("btnPress");
        SceneManager.LoadScene(gameSceneName);
    }
}
