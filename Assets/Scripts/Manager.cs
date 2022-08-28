using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Manager  : MonoBehaviour
{

    public static void loadScene(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }
}
