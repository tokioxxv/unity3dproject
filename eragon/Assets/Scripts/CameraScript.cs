using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.IO;
using System;
using Newtonsoft.Json.Linq;

public class CameraScript : MonoBehaviour
{
    public String SettingsFilePath = Directory.GetCurrentDirectory() + "/UserFileTest/";
    public String SettingsFileName = "userSettings.json";
    public String CameraName = "ThirdPersonCamera";





    private void setCameraParamter(string cameraName, float xSpeed, float ySpeed, bool isInverted)
    {
        GameObject camera = GameObject.Find("ThirdPersonCamera");
        CinemachineFreeLook cinemachineFreeLook = camera.GetComponent<CinemachineFreeLook>();
        cinemachineFreeLook.m_XAxis.m_MaxSpeed = xSpeed;
        cinemachineFreeLook.m_YAxis.m_MaxSpeed = ySpeed;
        cinemachineFreeLook.m_YAxis.m_InvertInput = isInverted; 
    }

    




    // Start is called before the first frame update
    void Start()
    {

        String ySpeedKey = "ySpeed";
        String xSpeedKey = "xSpeed";
        String InvertedToggleKey = "isInverted";
        JObject data = JsonCrud.ReadJson(SettingsFilePath + SettingsFileName);

        float xSpeed = (float)data[xSpeedKey];
        float ySpeed = (float)data[ySpeedKey];
        bool invert = (bool)data[InvertedToggleKey];




        setCameraParamter("ThirdPersonCamera", xSpeed, ySpeed, invert);




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
