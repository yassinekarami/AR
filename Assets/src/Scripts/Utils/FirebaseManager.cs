using UnityEngine;
using Firebase.Database;
using Newtonsoft.Json;
using Firebase.Auth;

public class FirebaseManager : MonoBehaviour
{
    DatabaseReference reference;
    public static FirebaseAuth auth;
    public static FirebaseUser currentUser;

    private void Awake()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        auth = FirebaseAuth.DefaultInstance;
    }

    public void saveResponse(Response responses)
    {
        string json = JsonConvert.SerializeObject(responses);
        reference.Child("reponse").SetRawJsonValueAsync(json);
    }

    public void getResponse()
    {
        reference.GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                //TODO: handle the error
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                //do something with snapshot
            }
        });
    }

    /**
     * permet de créer un compte
     */
     public static void createAccount(string email, string password)
     {
         auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
         {
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
     *  permet a l'utilisateur de se connecter
     */
    public static void logIn(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task =>
        {
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


    public static FirebaseUser getUserInformation()
    {
        /*Firebase.Auth.FirebaseUser user = auth.CurrentUser;
            if (user != null)
            {
                string name = user.DisplayName;
                string email = user.Email;
                System.Uri photo_url = user.PhotoUrl;
                // The user's Id, unique to the Firebase project.
                // Do NOT use this value to authenticate with your backend server, if you
                // have one; use User.TokenAsync() instead.
                string uid = user.UserId;
            }
        */
        return auth.CurrentUser;
    }


    /**
     * permet de se deconnecter
     */
    private void signOut()
    {
        FirebaseManager.auth.SignOut();
    }
}


