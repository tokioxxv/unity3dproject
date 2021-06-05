using System.Collections;
using System.Collections.Generic;
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
    public GameObject panelToAttachButtonsTo;
    void Start()
    {
        GameObject button = (GameObject)Instantiate(buttonPrefab);
        button.transform.SetParent(panelToAttachButtonsTo.transform);//Setting button parent
        button.GetComponent<Button>().onClick.AddListener(OnClick);
        //Next line assumes button has child with text as first gameobject like button created from GameObject->UI->Button
        button.transform.GetChild(0).GetComponent<Text>().text = "This is button text";//Changing text
        
    }

     void OnClick()
    {
        Debug.Log("clicked!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
