using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Newtonsoft.Json;
public class FirebaseManager : MonoBehaviour
{
    public static FirebaseManager fireBaseManager;
    DatabaseReference reference;
    void Start()
    {
        getInstance();
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
     * setup singleton
     */
    void getInstance()
    {
        if (fireBaseManager != null && fireBaseManager != this)
        {
            Destroy(this);
        }
        else
        {
            fireBaseManager = this;
        }
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
