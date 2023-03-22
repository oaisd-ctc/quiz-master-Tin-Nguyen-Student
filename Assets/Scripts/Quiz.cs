using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI questionText;
    [SerializeField]Questionso question;
    [SerializeField]GameObject[] answerButtons;
    int correctAnswerIndex;
    [SerializeField]Sprite defaultAnswerSprite;
    [SerializeField]Sprite correctAnswerSprite;

    void Start()
    {
        GetNextQuestion();
        //DisplayQuestion();
    }
public void OnAnswerSelected(int index)
{
    Image buttonImage;

    if(index == question.GetCorrectAnswerIndex())
    {
        questionText.text = "Good job Rizzler";
        buttonImage = answerButtons[index].GetComponent<Image>();
        buttonImage.sprite = correctAnswerSprite;
    }
    else
    {
        correctAnswerIndex = question.GetCorrectAnswerIndex();
        string correctAnswer = question.GetAnswer(correctAnswerIndex);
        questionText.text = "Sorry, but you indeed have no rizz;\n" + correctAnswer;
        buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
        buttonImage.sprite = correctAnswerSprite;
    }

    SetButtonState(false);
}

public void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }
public void DisplayQuestion()
   {
    questionText.text = question.GetQuestion();

        for(int i = 0; i < answerButtons.Length; i++)
        {
        TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = question.GetAnswer(i);
        }
   }

public void SetButtonState(bool state)
   {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
   }
   public void SetDefaultButtonSprites()
   {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
   }
}
