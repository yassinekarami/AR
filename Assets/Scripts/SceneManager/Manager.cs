using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneManagement.Manager
{
    public class Manager : MonoBehaviour
    {

        public static void loadScene(string name)
        {
            SceneManager.LoadScene(name, LoadSceneMode.Single);
        }
    }

}
