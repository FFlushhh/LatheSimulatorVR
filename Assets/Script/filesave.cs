using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class filesave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FileSave("Lathe", "Hello,World!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private static DirectoryInfo SafeCreateDirectory(string path){
        if(Directory.Exists(path)){
            return null;
        }
        return Directory.CreateDirectory(path);
    }

    private void FileSave(string Directory_path, string date){
        SafeCreateDirectory(Application.persistentDataPath + "/" + Directory_path);
        string _path = Application.persistentDataPath + "/" + Directory_path + "/test.txt";
        File.WriteAllText(_path, date);
    }
}
