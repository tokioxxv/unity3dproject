using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;



public class CameraScript : MonoBehaviour
{
    

    private void setCameraParamter(string cameraName, float xSpeed, float ySpeed, bool isInverted)
    {
        GameObject camera = GameObject.Find("ThirdPersonCamera");
        CinemachineFreeLook cinemachineFreeLook = camera.GetComponent<CinemachineFreeLook>();
        cinemachineFreeLook.m_XAxis.m_MaxSpeed = xSpeed;
        cinemachineFreeLook.m_YAxis.m_MaxSpeed = ySpeed;
        cinemachineFreeLook.m_YAxis.m_InvertInput = isInverted; 
    }

    private void ParseCameraParamter(string path)
    {


    }



   
    // Start is called before the first frame update
    void Start()
    {


        setCameraParamter("ThirdPersonCamera", 100f, 200f, false);




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
