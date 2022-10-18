/*using Firebase.Auth;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils.SceneManagement.Manager
{
    public class Manager 
    {

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

        public static Dictionary<string, string> getSceneParameters()
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
*/

using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Utils.SceneManagement.Manager
{
    public static class Manager<T>
    {

        public static Dictionary<string, T> parameters;


        public static void Load(string sceneName, Dictionary<string, T> parameter = null)
        {
            parameters = parameter;
            SceneManager.LoadScene(sceneName);
        }



        public static void Load(string sceneName, string paramKey, T paramValue)
        {
            parameters = new Dictionary<string, T>();

            parameters.Add(paramKey, paramValue);
            SceneManager.LoadScene(sceneName);
        }

        public static Dictionary<string, T> getSceneParameters()
        {
            return parameters;
        }

        public static T getParam(string paramKey)
        {
            if (parameters == null) return default(T);
            return parameters[paramKey];
        }

        public static void setParam(string paramKey, T paramValue)
        {
            if (parameters == null)
            {
                parameters = new Dictionary<string, T>();
            }
            parameters.Add(paramKey, paramValue);
        }
    }

}
