using System;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
using CustomEvent.UserAccountEvents; 
// invoke event 
public class CredentialsInputHandler : MonoBehaviour, IAccountStrategy
{
    public GameObject emailInput;
    public GameObject pwdInput;
    public GameObject pwdConfirmationInput;

    string email;
    string pwd;
    string confirmPwd;

    bool isEmailValid = false;
    bool isPwdValid = false;
    bool isPwdConfirmValid = false;


    public event EventHandler<CreateAccountArguments> onUserCreateAccount;

    public void emailValidation()
    {
        Debug.Log("CrendentialsInputHandler emailValidation "+ emailInput.GetInstanceID());
        
        Regex rx = new Regex("^\\S+@\\S+\\.\\S+$");
        email = emailInput.GetComponent<TMP_InputField>().text;
        MatchCollection matches = rx.Matches(email);
        if (matches.Count > 0)  {
            isEmailValid = true;
        }
    }

    /**
     * 
     * Has minimum 8 characters in length. Adjust it by modifying {8,}
     * At least one uppercase English letter. You can remove this condition by removing (?=.*?[A-Z])
     * At least one lowercase English letter.  You can remove this condition by removing (?=.*?[a-z])
     * At least one digit. You can remove this condition by removing (?=.*?[0-9])
     * At least one special character,  You can remove this condition by removing (?=.*?[#?!@$%^&*-])
     */
    public void passwordValidation()
    {
        Debug.Log("CrendentialsInputHandler passwordValidation "+pwdInput.GetInstanceID());
        Regex rx = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
        pwd = pwdInput.GetComponent<TMP_InputField>().text;
        MatchCollection matches = rx.Matches(pwd);
        if (matches.Count > 0)
        {
            isPwdValid = true; 
        }
        
    }

    public void confirmPasswordValidation()
    {
        Debug.Log("CrendentialsInputHandler confirmPasswordValidation "+ pwdConfirmationInput.GetInstanceID());
        confirmPwd = pwdConfirmationInput.GetComponent<TMP_InputField>().text;
        if(confirmPwd.Equals(pwd))
        {
            isPwdConfirmValid = true;
        }
    }



    /**
     * Verifie le formulaire 
     * 
     * Envoi un evenement pour déclancher la creation du compte
     */
    public void validateForm()
    {
        Debug.Log("CrendentialsInputHandler formValidation");
        if (isEmailValid && isPwdValid && isPwdConfirmValid)
        {
            Debug.Log("form is valid");
            onUserCreateAccount?.Invoke(this, new CreateAccountArguments { isUserSignedIn = true, email = email, password = pwd });
        }
        else
        {
            Debug.Log("form is invalid");
        }
    }

}
