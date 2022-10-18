using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using CustomEvent.UserAccountEvents;
using Utils.SceneManagement.Manager;
using Utils.Constants;
public class AccountHandler : MonoBehaviour
{

    public CredentialsInputHandler credentialsInputHandler;
    public LogInInputHandler logInInputHandler;

    private string CURRENT_USER_STRING = SceneParameter.CURRENT_USER_STRING;
    private string SCENE_MAIN_NAME = SceneName.SCENE_MAIN_NAME;
    private void Start()
    {
        credentialsInputHandler.onUserCreateAccount += createAccount;
        logInInputHandler.onUserLogIn += userLogIn;
    }

    /**
     * Evenement pour la creation d'un compte
     */
    public void createAccount(object sender, CreateAccountArguments e)
    {
        createAccount(e.email, e.password);
    }

    /**
     * Evenement pour la connexion de l'utilisateur
     */
    public void userLogIn(object sender, LogInArguments e)
    {
        logIn(e.email, e.password);
    }


    /**
     *  permet a l'utilisateur de se connecter
     */
    private void logIn(string email, string password)
    {
        Debug.Log("signIn " + email + " " + password);
        FirebaseManager.logIn(email, password);
        if(FirebaseManager.getUserInformation() != null)
        {
            Manager<FirebaseUser>.Load(SCENE_MAIN_NAME, CURRENT_USER_STRING, FirebaseManager.getUserInformation());
        }
    }

    /**
     * permet de créer un compte
     */ 
    private void createAccount(string email, string password)
    {
        Debug.Log("create accounrd " + email + " " + password);
      //  FirebaseManager.createAccount(email, password);
    }
}
