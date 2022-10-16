using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using CustomEvent.UserAccountEvents;

public class AccountHandler : MonoBehaviour
{
   FirebaseAuth auth;

    public CredentialsInputHandler credentialsInputHandler;
    public LogInInputHandler logInInputHandler;
    private void Awake()
    {
        auth = FirebaseAuth.DefaultInstance;
    }

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
        Debug.Log("signIn" + email + " " + password);
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }

    /**
     * permet de créer un compte
     */ 
    private void createAccount(string email, string password)
    {
        Debug.Log("create accounrd " + email + " " + password);
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }
    
    /**
     *  retourne l'utilisateur connecté
     */
    private FirebaseUser getUserInformation()
    {
        /*    Firebase.Auth.FirebaseUser user = auth.CurrentUser;
            if (user != null)
            {
                string name = user.DisplayName;
                string email = user.Email;
                System.Uri photo_url = user.PhotoUrl;
                // The user's Id, unique to the Firebase project.
                // Do NOT use this value to authenticate with your backend server, if you
                // have one; use User.TokenAsync() instead.
                string uid = user.UserId;
            }*/
        return auth.CurrentUser;
    }

    /**
     * permet de se deconnecter
     */
    private void signOut()
    {
        auth.SignOut();
    }
}
