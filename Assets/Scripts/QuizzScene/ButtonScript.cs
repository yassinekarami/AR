using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using Utils.Reponse;
public class ButtonScript : MonoBehaviour, IPointerClickHandler
{
    public Choix choix;
    Button button;
    Color normalColor;
 

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


    public void OnPointerClick(PointerEventData eventData)
    {
        changeColor();
        QuestionManager.questionmanager.getAnswer(choix);
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
}
