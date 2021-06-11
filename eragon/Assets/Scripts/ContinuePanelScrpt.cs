using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ContinuePanelScrpt : MonoBehaviour
{


    String GameFileName = "SaveFile*.json";
    String GameFilePath = Directory.GetCurrentDirectory() + "/UserFileTest/";
    public GameObject buttonPrefab;
    public GameObject ContinuePanel;


    private void CreateButton(string buttonName, int y)
    {

        //Start with 499 - 50 on each button .... 
        int x = 325; //TODO: CHANGE THIS  -<< X Y POSITIONING  
        int z = 0;

        GameObject button = (GameObject)Instantiate(buttonPrefab);
        button.transform.SetParent(ContinuePanel.transform);
        button.transform.position = new Vector3(x, y, z);
        button.GetComponent<Button>().onClick.AddListener(delegate () {
            //print(buttonName); // TODO: change this 
        });
        button.transform.GetChild(0).GetComponent<Text>().text = buttonName;
    }

    private List<string> ReadFiles(String path, String fileName)
    { //file name should contain * for indicator eg..... test*.json if looking for test.json files
        List<string> data = new List<string>();
        foreach (string file in Directory.GetFiles(path, fileName))
        {
            String FileName = file.Replace(path, "");
            data.Add(FileName);
        }
        return data;
    }

    private void CreateButtons(List<string> buttonNames)
    {
        int y = 499;
        for (int i = 0; i <= buttonNames.Count - 1; i++)
        {
            CreateButton(buttonNames[i], y);
            y -= 50;
        }
    }




    void Start()
    {
        List<string> data = ReadFiles(GameFilePath, GameFileName);
        CreateButtons(data);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
