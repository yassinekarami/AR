using System;
using UnityEngine;

public class QuizzManager : MonoBehaviour
{
    public static QuizzManager quizzManager;
    public static GameObject gameProgessPanel;
    public static GameObject gameOverPanel;

    public EventHandler<IsOverEventArgument> isOverChangeEvent;
    private void Awake()
    {
        quizzManager = getInstance();
        gameProgessPanel = GameObject.Find("GameProgressPanel");
        gameOverPanel = GameObject.Find("GameOver");
    }
   

    public static QuizzManager getInstance()
    {
        // crée une instance
        if (quizzManager == null )
        {
            return new QuizzManager();
        }
        else // retourne l'instance actuelle
        {
            return QuizzManager.quizzManager;
        }

    }

    public void onIsOverChange(bool  isOver)
    {
        IsOverEventArgument isOverEventArgument = new IsOverEventArgument();
        isOverEventArgument.isOver = isOver;

        gameOverPanel.SetActive(!isOver);
        gameProgessPanel.SetActive(isOver);

        isOverChangeEvent.Invoke(this, isOverEventArgument);

    }

    public class IsOverEventArgument : EventArgs
    {
        public bool isOver { get; set; }
    }


}
