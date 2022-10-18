/*using System.Collections.Generic;
using UnityEngine.SceneManagement;

public static class Manager<T>
{

    public static Dictionary<string, T> parameters = new Dictionary<string, T>();




    public static void Load(string sceneName, Dictionary<string, T> parameter = null)
    {
        parameters = parameter;
        SceneManager.LoadScene(sceneName);
    }



    public static  void Load(string sceneName, string paramKey, T paramValue)
    {
       
        parameters.Add(paramKey, paramValue);
        SceneManager.LoadScene(sceneName);
    }

    public static Dictionary<string, T> getSceneParameters()
    {
        return parameters;
    }


}*/
