using CustomEvent.IsOverEventArgument;
using UnityEngine;
using Assets.Scripts.QuizzScene;

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
            Debug.Log("QuizzSceneManager : awake");
            quizzSceneManager = getInstance();
            Debug.Log("GpsSceneManager instance " + quizzSceneManager.GetInstanceID());
            gameProgessPanel = GameObject.Find("GameProgressPanel");
            gameOverPanel = GameObject.Find("GameOver");
        }

        private void Start()
        {
            Debug.Log("QuizzSceneManager : Start");
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
            bool isGameOver = e.isGameOver;
            gameOverPanel.SetActive(isGameOver);
            gameProgessPanel.SetActive(!isGameOver);

            // launch Firebase
        }

    }

}

