
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.SceneManagement.Manager;
public class CredentialsSceneManager : MonoBehaviour
{
    public GameObject credentialsInputHandler;
    public GameObject logInInputHandler;

    private void Awake()
    {
  
    }
    private void Start()
    {
       Debug.Log("option : " + Manager.getParam("option"));
       // mainSceneManager.onCredentialsScenehoosen += credentialsOption;
       if(Manager.getParam("option").Equals("1"))
       {
            credentialsInputHandler.SetActive(true);
            logInInputHandler.SetActive(false);
       } 
       else if (Manager.getParam("option").Equals("0"))
       {
            credentialsInputHandler.SetActive(false);
            logInInputHandler.SetActive(true);
       }
       
    }

}
