using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using Newtonsoft.Json;
using System.IO;
using System.Linq; 



public class ButtonCreator : MonoBehaviour
{

    public GameObject buttonPrefab; 
    public GameObject ContinuePanel; 
    // Start is called before the first frame update
    void Start()
    {

        generateButton("testing", 499);




        // print("stareted"); 
        // GameObject button = (GameObject)Instantiate(buttonPrefab);
        // button.transform.SetParent(ContinuePanel.transform);
        // button.transform.position = new Vector3(0,0,0); 
    }


    private void generateButton(string buttonName, int y){ 
        int x = 325; 
        int z = 0; 

        GameObject button = (GameObject)Instantiate(buttonPrefab);
        button.transform.SetParent(ContinuePanel.transform);
        button.transform.position = new Vector3(x,y,z); 
        // button.GetComponent<Button>().OnClick.AddListener(delegate(){ 
        //     print("Button Clicked"); //change this
        // }); 
        button.transform.GetChild(0).GetComponent<Text>().text = buttonName;


    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
