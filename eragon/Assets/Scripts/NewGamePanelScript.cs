using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;



namespace testing
{

    public class NewGamePanelScript : MonoBehaviour
    {

        String GameFileName = "test*.json";
        String GameFilePath = @"C:\Users\Edward\Downloads\Music\";

        private static String GenerateFileName(String path, String filename)
        {
            List<String> files = ReadFiles(path, filename);
            if (files.Any())
            { //if files already exist 
                String lastItem = files[files.Count - 1];
                String _temp = filename.Replace("*", "");
                String[] subs = _temp.Split('.');
                int count = int.Parse(lastItem.Replace(subs[0], "").Replace(subs[1], "").Replace(".", "")) + 1;  ////////TODO: CHANGE THIS - <<<<<<  take lastest count from file... eg: file1.json will return 1.... 
                String outputFileName = filename.Replace("*", count.ToString());
                return outputFileName;
            }
            else
            {
                String outputFileName = filename.Replace("*", "0");
                return outputFileName;
            }
        }


        private static List<string> ReadFiles(String path, String fileName)
        { //file name should contain * for indicator eg..... test*.json if looking for test.json files
            List<string> data = new List<string>();
            foreach (string file in Directory.GetFiles(path, fileName))
            {
                String FileName = file.Replace(path, "");
                data.Add(FileName);
            }
            return data;
        }









        void Start()
        {


            String fileName = GenerateFileName(GameFilePath, GameFileName);
            Dictionary<String, String> data = new Dictionary<String, String>();
            data.Add("testing", "isAdded");
            JsonCrud.CreateJSON(data, GameFilePath, fileName);

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
 




}
