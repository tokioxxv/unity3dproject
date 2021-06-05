using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using System.Json; 
using System.Text.Json.Serialization;


public class Testing : MonoBehaviour
{ 
    String GamefileName = ""; 
    String GamePath = ""; 


    private  void onNewGameClicK(){ //create New JSON game file 
        print("clicked");




    }

    private  void onContinueGameClick(){ //Read JSON game save file
        print("clicked");

    }

    private  void onExitClick(){  //Exit game
        Application.Quit(); 
        print("clicked");
    }

    private  void onSettingsClick(){
        print("clicked");
    }




    void Start()
    {
        Button newButton = GameObject.Find("New").GetComponent<Button>();
        Button continueButton = GameObject.Find("Continue").GetComponent<Button>();
        Button settingsButton = GameObject.Find("Settings").GetComponent<Button>();
        Button exitButton = GameObject.Find("Exit").GetComponent<Button>();
        

        newButton.onClick.AddListener(delegate(){
            onNewGameClicK();

        });
        continueButton.onClick.AddListener(delegate(){
            onContinueGameClick(); 

        });
        settingsButton.onClick.AddListener(delegate(){
            onSettingsClick();

        });
        exitButton.onClick.AddListener(delegate(){
            onExitClick();

        });






        // b.onClick.AddListener(delegate(){
        //     b.GetComponentInChildren<Text>().text = "testing;"; 
        
        // } ); 
    }







    // Update is called once per frame
    void Update()
    {
        
    }

    
}
