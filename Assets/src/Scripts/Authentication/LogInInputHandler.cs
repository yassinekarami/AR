using System;
using UnityEngine;
using TMPro;
using CustomEvent.UserAccountEvents;
public class LogInInputHandler : MonoBehaviour, IAccountStrategy
{
    public GameObject emailInput;
    public GameObject pwdInput;

    bool isEmailValid = false;
    bool isPwdValid = false;


    string email;
    string pwd;

    public event EventHandler<LogInArguments> onUserLogIn;

    public void emailValidation()
    {
        email = emailInput.GetComponent<TMP_InputField>().text;
        Debug.Log("login in form email " + email);
        if (email != "")
        {
            isEmailValid = true;
        }
    }

    public void passwordValidation()
    {
        pwd = pwdInput.GetComponent<TMP_InputField>().text;
        Debug.Log("login in form pwd " + pwd);
        if (pwd != "")
        {
            isPwdValid = true;
        }
    }

    public void confirmPasswordValidation()
    {
        throw new System.NotImplementedException();
    }


    /**
      * Verifie le formulaire 
      * 
      * Envoi un evenement pour la declancher la connexion
      */
    public void validateForm()
    {
        Debug.Log("CrendentialsInputHandler formValidation");
        if (isEmailValid && isPwdValid)
        {
            Debug.Log("form is valid");
            onUserLogIn?.Invoke(this, new LogInArguments { isUserSignedIn = true, email = email, password = pwd });
        }
        else
        {
            Debug.Log("form is invalid");
        }
    }
}
