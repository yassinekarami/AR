using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils.SceneManagement.Manager
{
    public static class Manager
    {


        private static System.Collections.Generic.Dictionary<string, string> parameters;

        public static void Load(string sceneName, System.Collections.Generic.Dictionary<string, string> parameters = null)
        {
            Manager.parameters = parameters;
            SceneManager.LoadScene(sceneName);
        }

        public static void Load(string sceneName, string paramKey, string paramValue)
        {
            Manager.parameters = new System.Collections.Generic.Dictionary<string, string>();
            Manager.parameters.Add(paramKey, paramValue);
            SceneManager.LoadScene(sceneName);
        }

        public static System.Collections.Generic.Dictionary<string, string> getSceneParameters()
        {
            return parameters;
        }

        public static string getParam(string paramKey)
        {
            if (parameters == null) return "";
            return parameters[paramKey];
        }

        public static void setParam(string paramKey, string paramValue)
        {
            if (parameters == null)
            {
                Manager.parameters = new System.Collections.Generic.Dictionary<string, string>();
            }
            Manager.parameters.Add(paramKey, paramValue);
        }
    }

}
