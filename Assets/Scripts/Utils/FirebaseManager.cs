using UnityEngine;
using Firebase.Database;
using Newtonsoft.Json;


    public class FirebaseManager : MonoBehaviour
    {
        public static FirebaseManager fireBaseManager;
        DatabaseReference reference;
        void Start()
        {
            fireBaseManager = getInstance();
            reference = FirebaseDatabase.DefaultInstance.RootReference;
        }

        // Update is called once per frame
        void Update()
        {

        }

        /**
         * setup singleton
         */
        public static FirebaseManager getInstance()
        {
            if (fireBaseManager != null)
            {
            return fireBaseManager;
            }
            else
            {
            return new FirebaseManager();
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


