using UnityEngine;
using Utils.SceneManagement.Manager;
using Utils.Constants;
public class CredentialsSceneManager : MonoBehaviour
{
    public GameObject credentialsInputHandler;
    public GameObject logInInputHandler;

    private void Awake()
    {
  
    }
    private void Start()
    {
       Debug.Log("option : " + Manager<string>.getParam(SceneParameter.CRENDENTIALS_CHOOSEN_OPTION));
       // mainSceneManager.onCredentialsScenehoosen += credentialsOption;
       if(Manager<string>.getParam(SceneParameter.CRENDENTIALS_CHOOSEN_OPTION).Equals("1"))
       {
            credentialsInputHandler.SetActive(true);
            logInInputHandler.SetActive(false);
       } 
       else if (Manager<string>.getParam(SceneParameter.CRENDENTIALS_CHOOSEN_OPTION).Equals("0"))
       {
            credentialsInputHandler.SetActive(false);
            logInInputHandler.SetActive(true);
       }
    }
}
