using CustomEvent.IsOverEventArgument;
using System;
using UnityEngine;

namespace SceneManagement.QuizzSceneManager
{
    public class QuizzSceneManager : MonoBehaviour
    {
        public static QuizzSceneManager quizzSceneManager;
        public static GameObject gameProgessPanel;
        public static GameObject gameOverPanel;

        QuestionManager qm;

        private void Awake()
        {
            quizzSceneManager = getInstance();
            gameProgessPanel = GameObject.Find("GameProgressPanel");
            gameOverPanel = GameObject.Find("GameOver");
        }

        private void Start()
        {
            qm = gameProgessPanel.GetComponent<QuestionManager>();
            qm.onIsGameOverChanged += onIsOverChanged;
        }



        public static QuizzSceneManager getInstance()
        {
            // crée une instance
            if (quizzSceneManager == null)
            {
                return new QuizzSceneManager();
            }
            else // retourne l'instance actuelle
            {
                return quizzSceneManager;
            }

        }

        public void onIsOverChanged(object sender, IsOverEventArgument e)
        {
            Debug.Log("fin de partie");
            bool isGameOver = e.isGameOver;
            gameOverPanel.SetActive(isGameOver);
            gameProgessPanel.SetActive(!isGameOver);
        }

    }

}

