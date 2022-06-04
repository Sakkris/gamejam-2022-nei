using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro;
    int numbers = 10;

    void Update()
    {
        int score = Manager.instance.score;
        string scoreString = score.ToString();
        int missingN = numbers - scoreString.Length;
        for(int i = 0; i<missingN; i++)
        {
            scoreString = "0" + scoreString;
        }
        textMeshPro.text = scoreString;

    }
}
