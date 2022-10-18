using Firebase.Auth;
using System;
using UnityEngine;
using Utils.Constants;
using Utils.SceneManagement.Manager;

public class MainSceneManager : MonoBehaviour
{
    private readonly string CREDENTIALS_SCENE_NAME = SceneName.CREDENTIALS_SCENE;
    private readonly string MAIN_CANVAS_OPTION_FORM = MainScene.MAIN_CANVAS_OPTION_FORM;
    private readonly string CRENDENTIALS_CHOOSEN_OPTION = SceneParameter.CRENDENTIALS_CHOOSEN_OPTION;

    private GameObject optionForm;

    private void Awake()
    {
        optionForm = GameObject.Find(MAIN_CANVAS_OPTION_FORM);
    }

    private void Start()
    {

        if( Manager<FirebaseUser>.getParam(SceneParameter.CURRENT_USER_STRING) != null) 
        {
            FirebaseUser user = Manager<FirebaseUser>.getParam(SceneParameter.CURRENT_USER_STRING);
            Debug.Log("User connecter " + user.Email);
            optionForm.SetActive(false);
        }
        else
        {
            optionForm.SetActive(true);
        }
    }
    public void selectCreateAccount()
    {
        Debug.Log("create account option choosen");
        Manager<string>.Load(CREDENTIALS_SCENE_NAME, CRENDENTIALS_CHOOSEN_OPTION, "1");    
    }

    public void selectLogin()
    {
        Debug.Log("logIn option choosen");
        Manager<string>.Load(CREDENTIALS_SCENE_NAME, CRENDENTIALS_CHOOSEN_OPTION, "0");   
    }

}
