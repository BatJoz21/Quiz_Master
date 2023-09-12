using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timerValue;

    [SerializeField] private float timeToAnswer = 30f;
    [SerializeField] private float timeToShowAnswer = 10f;

    public bool isAnsweringQuestion = false;

    void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (isAnsweringQuestion)
        {
            if (timerValue <= 0)
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowAnswer;
            }
        }
        else
        {
            if (timerValue <= 0)
            {
                isAnsweringQuestion = true;
                timerValue = timeToAnswer;
            }
        }

        Debug.Log(isAnsweringQuestion);
        Debug.Log(timerValue);
    }
}
