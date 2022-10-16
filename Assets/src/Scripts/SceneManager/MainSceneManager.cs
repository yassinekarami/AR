using System;
using UnityEngine;
using Utils.SceneManagement.Manager;
public class MainSceneManager : MonoBehaviour
{
    string crendentialsSceneName = "CredentialsScene";
    public void selectCreateAccount()
    {
        Debug.Log("create account option choosen");
        Manager.Load(crendentialsSceneName, "option", "1");    }

    public void selectLogin()
    {
        Debug.Log("logIn option choosen");
        Manager.Load(crendentialsSceneName, "option", "0");    }
}
