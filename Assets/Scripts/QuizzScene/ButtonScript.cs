using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using Utils;
using CustomEvent.SelectedChoixEventArgument;
public class ButtonScript : MonoBehaviour
{
    public Choix choix;
    Button button;
    Color normalColor;

    public EventHandler<SelectedChoixEventArgument> selectedChoixEvent;
    void Awake()
    {
        button = gameObject.GetComponent<Button>();
        normalColor = button.GetComponent<Image>().color;
    }
    public void Init(Choix choix)
    {
        gameObject.GetComponentInChildren<Text>().text = choix.libelle;
        button.GetComponent<Image>().color = normalColor;
        this.choix = choix;  
    }

    private void changeColor()
    {
        if (choix.isCorrect)
        {
            button.GetComponent<Image>().color = Color.green;
        }
        else
        {
            button.GetComponent<Image>().color = Color.red;
        }
    }

    public void checkAnswer()
    {
        changeColor();
//        QuestionManager.questionmanager.getAnswer(choix);
    }

    public void onSelectedChoix()
    {
        SelectedChoixEventArgument selectedChoixEventArgument = new SelectedChoixEventArgument();
        selectedChoixEventArgument.choix = choix;

        selectedChoixEvent.Invoke(this, selectedChoixEventArgument);

    }
   

}
