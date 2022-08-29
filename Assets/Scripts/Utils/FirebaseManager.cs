using UnityEngine;
using Firebase.Database;
using Newtonsoft.Json;


public class FirebaseManager
{
    DatabaseReference reference;
    public FirebaseManager()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }


    public void saveResponse(Response responses)
    {
        string json = JsonConvert.SerializeObject(responses);
        reference.Child("reponse").SetRawJsonValueAsync(json);
    }

    public void getResponse()
    {
        reference.GetValueAsync().ContinueWith(task => {
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
}


