using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using Newtonsoft.Json;
using System.IO;
using System.Linq; 
using Newtonsoft.Json.Linq;





public class MainMenuUI : MonoBehaviour
{ 
    String GameFileName = "test*.json"; 
    String GameFilePath = @"C:\Users\Edward\Downloads\Music\"; 
    public GameObject buttonPrefab; 
    public GameObject ContinuePanel; 
    private void SwitchPanel(GameObject toBeActivated, GameObject toBeDisabled){
        toBeDisabled.SetActive(false); 
        toBeActivated.SetActive(true); 
    }





    private  void onNewGameClicK(){ //create New JSON game file 
       String fileName = generateFileName(GameFilePath, GameFileName); 
       Dictionary<String, String> data = new Dictionary<String, String>(); 
       data.Add("testing", "isAdded"); 
       CreateJSON(data, GameFilePath, fileName);
    }

    private  void onContinueGameClick(){ //Read JSON game save file
        GameObject mainPanel = GameObject.Find("MainMenuPanel"); 
        GameObject continuepanel = GameObject.Find("ContinuePanel"); 
        
        // SwitchPanel()
        SwitchPanel(ContinuePanel, mainPanel); 
        List<string> data  = ReadFiles(GameFilePath, GameFileName); 
        createButtons(data); 
        

    }

    private  void onExitClick(){  //Exit game
        Application.Quit(); 
        print("clicked");
    }

    private  void onSettingsClick(){
        GameObject panel = GameObject.Find("MainMenuPanel"); 
        panel.SetActive(false); 
        print("clicked");
    }

    private static void CreateJSON(Dictionary<String, String> data, String path, String name){                         
        using (StreamWriter file = File.CreateText(path + name))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, data);
        }
    }

     private void createButton(string buttonName, int y){ 
         //Start with 499 - 50 on each button .... 
        int x = 325; //TODO: CHANGE THIS  -<< X Y POSITIONING  
        int z = 0;  

        GameObject button = (GameObject)Instantiate(buttonPrefab);
        button.transform.SetParent(ContinuePanel.transform);
        button.transform.position = new Vector3(x,y,z); 
        button.GetComponent<Button>().onClick.AddListener(delegate(){ 
            print(buttonName); // TODO: change this 
        }); 
        button.transform.GetChild(0).GetComponent<Text>().text = buttonName;
    }


    private static String generateFileName(String path, String filename){ 
            List<String> files  = ReadFiles(path, filename); 
            if(files.Any()){ //if files already exist 
                String lastItem = files[files.Count - 1]; 
                String _temp = filename.Replace("*", ""); 
                String [] subs = _temp.Split('.'); 
                int count = int.Parse(lastItem.Replace(subs[0], "").Replace(subs[1], "").Replace(".", "")) + 1;  ////////TODO: CHANGE THIS - <<<<<<  take lastest count from file... eg: file1.json will return 1.... 
                String outputFileName = filename.Replace("*", count.ToString()); 
                return outputFileName;
            }else {
                String outputFileName = filename.Replace("*", "0"); 
                return outputFileName;
            }
        }


    private static List<string> ReadFiles(String path, String fileName){ //file name should contain * for indicator eg..... test*.json if looking for test.json files
            List<string> data = new List<string>(); 
            foreach(string file in Directory.GetFiles(path, fileName)){
            String FileName = file.Replace(path, "");
            data.Add(FileName);
        }
            return data; 
        }


    private JObject readJson(String path){ 
            using (StreamReader reader = File.OpenText(path))
            {
                JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader)); 
                return o;  
                
            }
        }



    private void writeJSON(String path, Dictionary<string, string> data){ 
        JObject oldData = readJson(path); 
          
        foreach(KeyValuePair<string, string> entry in data)
		{
 		    oldData[entry.Key] = entry.Value; 
	    }
        using (StreamWriter file = File.CreateText(@"C:\Users\Edward\Downloads\Music\a.json"))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, oldData);
        }
    }





    void OnGui(){
        if (GUI.Button(new Rect(10, 10, 150, 100), "I am a button"))
        {
            print("You clicked the button!");
        }
    }

    private void createButtons(List<string> buttonNames){ 
        int y = 499; 
        for (int i = 0; i <= buttonNames.Count - 1; i ++){ 
            createButton(buttonNames[i], y); 
            y -= 50; 
        }

    }

  



    void Start()
    {   
        Button newButton = GameObject.Find("New").GetComponent<Button>(); //TODO: Cleanup 
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

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    
}
