using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro;
    int minutes;
    int seconds;
    float timer = 0.0f;

    void Start()
    {
        minutes = 0;
        seconds = 0;
    }
    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int) timer % 60;
        if(seconds == 60)
        {
            minutes++;
            seconds = 0;
        }
        string secondsString;
        if (seconds < 10)
        {
            secondsString = "0" + seconds;
        }
        else
        {
            secondsString = seconds.ToString();
        }
        string time = minutes + ":" + secondsString;
        textMeshPro.text = time;
    }

}
