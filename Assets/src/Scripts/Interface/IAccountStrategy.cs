using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAccountStrategy
{
    public void emailValidation();

    public void passwordValidation();
    public void confirmPasswordValidation();

    public void validateForm();

}
