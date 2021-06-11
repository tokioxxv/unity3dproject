using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanelScript : MonoBehaviour
{
    public String SettingsFilePath = Directory.GetCurrentDirectory() + "/UserFileTest/";
    public String SettingsFileName = "userSettings.json"; 
    

    private void WriteUserSettings(Dictionary<String, String> data)
    {
        try
        {
            JsonCrud.WriteJSON(SettingsFilePath + SettingsFileName, data); 
        }catch(FileNotFoundException e)
        {
            JsonCrud.CreateJSON(SettingsFilePath, SettingsFileName);
            JsonCrud.WriteJSON(SettingsFilePath + SettingsFileName, data); 
        }
    }



    void Start()
    {
        Scrollbar ySpeed = GameObject.Find("YSpeedScrollbar").GetComponent<Scrollbar>();
        Scrollbar xSpeed= GameObject.Find("XSpeedScrollbar").GetComponent<Scrollbar>();
        Toggle invertedToggle = GameObject.Find("InvertedToggle").GetComponent<Toggle>();
        Button saveButton = GameObject.Find("SaveButton").GetComponent<Button>();

        String ySpeedKey = "ySpeed";
        String xSpeedKey = "xSpeed";
        String InvertedToggleKey = "isInverted";


     
        saveButton.onClick.AddListener(delegate ()
        {
            float ySenivisity = ySpeed.value * 1000;
            float xSenivisity = xSpeed.value * 1000;
            bool isInverted = invertedToggle.isOn;

            Dictionary<String, String> data = new Dictionary<string, string>();
            data.Add(ySpeedKey, ySenivisity.ToString());
            data.Add(xSpeedKey, xSenivisity.ToString());
            data.Add(InvertedToggleKey, isInverted.ToString());
            WriteUserSettings(data);
            print(data.ToString()); 
        });

        

        




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
