using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SceneManagement.GpsSceneManager
{
    public class GpsSceneManager : MonoBehaviour
    {

        public static GpsSceneManager gpsSceneManager;
        public GPSMode gpsMode;

        private void Awake()
        {
            Debug.Log("GpsSceneManager : awake");
            gpsSceneManager = getInstance();
            Debug.Log("GpsSceneManager instance " + gpsSceneManager.GetInstanceID());
        }
        void Start()
        {
            Debug.Log("GpsSceneManager : Start");

            // ON START LAUNCH GPS MODE
            gpsMode = GetComponent<GPSMode>();
            gpsMode.enabled = true;
            
            
        }

        // Update is called once per frame
        void Update()
        {

        }

        public static GpsSceneManager getInstance()
        {
            // crée une instance
            if (gpsSceneManager == null)
            {
                return new GpsSceneManager();
            }
            else // retourne l'instance actuelle
            {
                return gpsSceneManager;
            }

        }
    }
}

