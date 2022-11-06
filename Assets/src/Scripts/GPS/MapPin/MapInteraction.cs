using Microsoft.Geospatial;
using Microsoft.Maps.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInteraction : MonoBehaviour
{
    private MapPinLayer mapPinLayer;
    public GameObject smallMapPin;
    MapInteractionController mapInteractionController;
    // Start is called before the first frame update
    void Start()
    {
        mapPinLayer = gameObject.GetComponent<MapPinLayer>();
        mapInteractionController = GetComponent<MapInteractionController>();

        mapInteractionController.OnTapAndHold.AddListener(call =>
        {
            Debug.Log("update " + call.LatLon.LongitudeInDegrees);
            Debug.Log("update " + call.LatLon.LatitudeInDegrees);
            LatLon latLon = new LatLon(call.LatLon.LongitudeInDegrees, call.LatLon.LatitudeInDegrees);
        
            GameObject mapPin = Instantiate(smallMapPin);
       
            mapPin.GetComponent<MapPin>().Location = latLon;
            mapPin.GetComponent<MapPin>().Altitude = 0;

            mapPinLayer.MapPins.Add(mapPin.GetComponent<MapPin>());
         
          
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addMarkerPin()
    {
        Debug.Log("double tap");
  //      GameObject toInstantiate = Instantiate(smallMapPin);
       

    }
}
