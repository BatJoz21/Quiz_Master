using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] QuestionSO questionSO;
    [SerializeField] TextMeshProUGUI questionText;

    void Start()
    {
        questionText.text = questionSO.GetQuestion();
    }
}
