using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Datalogging : MonoBehaviour
{
    public string filepath = "data.txt";

    // Start is called before the first frame update
    void Start()
    {
        CreateFile();
        WriteFile("You've opened the game!");
    }

    private void OnApplicationQuit()
    {
        WriteFile("You've closed the game!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            WriteFile("You've pressed the spacebar");
        }
    }

    private void CreateFile()
    {
        if (!File.Exists(filepath))
        {
            File.Create(filepath).Close();
        }
    }

    public void WriteFile(string text)
    {
        using (StreamWriter streamWriter = new StreamWriter(filepath, true))
        {
            streamWriter.WriteLine(DateTime.Now + text);
        }
    }

}