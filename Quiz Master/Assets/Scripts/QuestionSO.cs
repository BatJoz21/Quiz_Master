using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Questions", fileName = "New Question")] 
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] private string question = "Enter new question!";
}
