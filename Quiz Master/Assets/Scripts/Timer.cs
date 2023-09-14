using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeToAnswer = 30f;
    [SerializeField] private float timeToShowAnswer = 10f;

    private float timerValue;
    public bool loadNextQuestion;
    public bool isAnsweringQuestion;
    public float fillFraction;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    private void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (isAnsweringQuestion)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToAnswer;
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowAnswer;
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToShowAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = timeToAnswer;
                loadNextQuestion = true;
            }
        }

        Debug.Log(isAnsweringQuestion + ":" + timerValue + "=" + fillFraction);
    }
}
