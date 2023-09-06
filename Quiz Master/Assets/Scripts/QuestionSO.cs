using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Questions", fileName = "New Question")] 
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] private string question = "Enter new question!";
    [SerializeField] private string[] answers = new string[4];
    [SerializeField] private int correctAnswerIndex;

    //public string GetQuestion { get => question; }
    //public int GetCorrectAnswerIndex { get => correctAnswerIndex; }
    public string GetQuestion() { return question; }
    public int GetCorrectAnswerIndex() { return correctAnswerIndex; }

    public string GetAnswer(int index) { return answers[index]; }
}
