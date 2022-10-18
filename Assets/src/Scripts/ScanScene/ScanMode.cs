using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;
using TMPro;
using Utils.SceneManagement.Manager;
public class ScanMode : Mode
{

    [SerializeField]
    private RawImage rawImageBackground;
    [SerializeField]
    private AspectRatioFitter aspectRatioFiltter;
    [SerializeField]
    private TextMeshProUGUI textOut;
    [SerializeField]
    private RectTransform scanZone;

    private bool isCamAvailable;
    private WebCamTexture cameraTexture;
    public override void toString()
    {
        Debug.Log("Scan mode");
    }

    public void Update()
    {
        UpdatecameraRender();
    }
    public override void perform()
    {
        SetUpCamera();
    }

    private void SetUpCamera()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        if(devices.Length == 0)
        {
            isCamAvailable = false;
            return;
        }
        foreach(WebCamDevice device in  devices)
        {
            if(!device.isFrontFacing)
            {
                cameraTexture = new WebCamTexture(device.name, (int)scanZone.rect.width, (int)-scanZone.rect.height);
            }
        }
        cameraTexture.Play();
        rawImageBackground.texture = cameraTexture;
        isCamAvailable = true;
    }

    private void UpdatecameraRender()
    {
        if (isCamAvailable==false)
        {
            return;
        }
        float ratio = (float)cameraTexture.width / (float)cameraTexture.height;
        aspectRatioFiltter.aspectRatio = ratio;

        int orientation = -cameraTexture.videoRotationAngle;
        rawImageBackground.rectTransform.localEulerAngles = new Vector3(0, 0, orientation);
    }

    public void scan()
    {
        try
        {
            IBarcodeReader barcodeReader = new BarcodeReader();
            Result result = barcodeReader.Decode(cameraTexture.GetPixels32(), cameraTexture.width, cameraTexture.height) ;
            if(result != null)
            {
                Manager<string>.Load("sceneName");
            }
        } catch
        {
            textOut.text = "FAILED IN TRY";
        }
    }
}
