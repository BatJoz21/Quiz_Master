using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] QuestionSO questionSO;
    [SerializeField] TextMeshProUGUI questionText;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    private int correctAnswIndex;
    private bool hasAnswerdEarly;

    [Header("Button Colors")]
    [SerializeField] private Sprite defaultAnswSprite;
    [SerializeField] private Sprite correctAnswSprite;

    [Header("Timer")]
    [SerializeField] private Image timerImage;
    Timer timer;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        //DisplayQuestion();
        GetNextQuestion();
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            hasAnswerdEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if (!hasAnswerdEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnswerdEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
    }

    private void DisplayAnswer(int index)
    {
        Image buttonImage;
        if (index == questionSO.GetCorrectAnswerIndex())
        {
            questionText.text = questionText.text + "\n You're Answer is Correct";
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswSprite;
        }
        else
        {
            questionText.text = questionText.text + "\n You're Answer is Wrong, Here is the Correct Answer";
            buttonImage = answerButtons[questionSO.GetCorrectAnswerIndex()].GetComponent<Image>();
            buttonImage.sprite = correctAnswSprite;
        }
    }

    private void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprite();
        DisplayQuestion();
    }

    private void DisplayQuestion()
    {
        questionText.text = questionSO.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = questionSO.GetAnswer(i);
        }
    }

    void SetButtonState(bool state)
    {
        for (int i=0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultButtonSprite()
    {
        for (int i=0; i < answerButtons.Length; i++)
        {
            Image buttonSprite = answerButtons[i].GetComponent<Image>();
            buttonSprite.sprite = defaultAnswSprite;
        }
    }
}
