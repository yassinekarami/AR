using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSMode : Mode
{

    public static GPSMode Instance { set; get; }

    public float latitude;
    public float longitude;

    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
    }

    public override void toString()
    {
        Debug.Log("GPS Mode");
    }

    public override void perform()
    {
        Debug.Log("Enabling GPS");
        StartCoroutine(StartLocationService());
    }

    private IEnumerator StartLocationService()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("User has not enabled GPS");
            yield break;
        }
        Input.location.Start();
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;

        }
        if (maxWait <= 0)
        {
            Debug.Log("Time out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unabled to determin device location");
            yield break;
        }

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        yield break;
    }




}
