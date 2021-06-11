using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using Newtonsoft.Json;
using System.IO;
using System.Linq; 
using Newtonsoft.Json.Linq;




    public class MainMenuScript : MonoBehaviour
    {

        
        
        //panels
        public GameObject MainMenuPanel; 
        public GameObject ContinuePanel;
        public GameObject NewGamePanel;
        public GameObject SettingsPanel;
        public GameObject ActivePanel = null;



        private void SwitchPanel(GameObject toBeActivated, GameObject toBeDisabled)
        {
            toBeDisabled.SetActive(false);
            toBeActivated.SetActive(true);
        }


        private void OnNewGameClicK()
        {
            ActivePanel = NewGamePanel;
            SwitchPanel(NewGamePanel, MainMenuPanel); 
            
        }

        private void OnContinueGameClick()
        {
            ActivePanel = ContinuePanel;
            SwitchPanel(ContinuePanel, MainMenuPanel);
        }

        private void OnExitClick()
        {  //Exit game
            Application.Quit();
            print("clicked");
        }

        private void OnSettingsClick()
        {
            ActivePanel = SettingsPanel; 
            SwitchPanel(SettingsPanel, MainMenuPanel);    
            
        }

        private void OnBackClick()
        {
        SwitchPanel(MainMenuPanel, ActivePanel);
        }
         

    


        void Start()
        {
            

            Button newButton = GameObject.Find("New").GetComponent<Button>(); //TODO: Cleanup 
            Button continueButton = GameObject.Find("Continue").GetComponent<Button>();
            Button settingsButton = GameObject.Find("Settings").GetComponent<Button>();
            Button exitButton = GameObject.Find("Exit").GetComponent<Button>();
            Button backButton = GameObject.Find("BackButton").GetComponent<Button>();






            newButton.onClick.AddListener(delegate () {
                OnNewGameClicK();
            });
            continueButton.onClick.AddListener(delegate () {
                OnContinueGameClick();
            });
            settingsButton.onClick.AddListener(delegate () {
                OnSettingsClick();
            });
            exitButton.onClick.AddListener(delegate () {
                OnExitClick();
            });
            backButton.onClick.AddListener(delegate ()
            {
                OnBackClick();

            });
        
    
    
    
    }


        // Update is called once per frame
        void Update()
        {

        }


    }







