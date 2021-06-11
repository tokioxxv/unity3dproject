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



        private void SwitchPanel(GameObject toBeActivated, GameObject toBeDisabled)
        {
            toBeDisabled.SetActive(false);
            toBeActivated.SetActive(true);
        }


        private void OnNewGameClicK()
        {
            SwitchPanel(NewGamePanel, MainMenuPanel); 
        }

        private void OnContinueGameClick()
        { 
            SwitchPanel(ContinuePanel, MainMenuPanel);
        }

        private void OnExitClick()
        {  //Exit game
            Application.Quit();
            print("clicked");
        }

        private void OnSettingsClick()
        {
            SwitchPanel(SettingsPanel, MainMenuPanel);    
            
        }
         

    


        void Start()
        {

            Button newButton = GameObject.Find("New").GetComponent<Button>(); //TODO: Cleanup 
            Button continueButton = GameObject.Find("Continue").GetComponent<Button>();
            Button settingsButton = GameObject.Find("Settings").GetComponent<Button>();
            Button exitButton = GameObject.Find("Exit").GetComponent<Button>();

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

        }


        // Update is called once per frame
        void Update()
        {

        }


    }







