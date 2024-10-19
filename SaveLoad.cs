//READ ME:

//Created by Mae Bridgeman 2024

//To use, just attach this script to an object in the scene.
//Update SaveData and SettingsData to match the data you need to save.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//Notes:
//The default Unity path is: 
    //C:/Users/{USERNAME}/AppData/LocalLow/<COMPANYNAME>/<PROJECTNAME>/
        //Items in < > are defined in the project settings
        //Items in { } are dependant on the user

//Note: We can't store full Unity objects, so if you want to store a prefab, material, etc. 
//      you need to store it as a string, then check the string when loading

public class SaveLoad : MonoBehaviour
{
    public static SaveLoad instance;

    private string savePath = "";
    private string settingsPath = "";

    //Temporary versions of save data. When the game loads, these are set to the saved files from the user's computer.
    //Throughout the game, they are updated. When SaveGameData() or SaveSettingsData() are called, the changes are written to the disk
    private SaveData saveDataToSave;
    private SettingsData settingsDataToSave;

    public void Awake(){
        instance = this;

        //Set path equal to the default location unity saves data, and look for the filename of our save file
        savePath = Application.persistentDataPath + "/save.json";
        settingsPath = Application.persistentDataPath + "/settings.json";

        //Creates temporary copies of save data to edit before writing to disk
        saveDataToSave = GetSaveData();
        settingsDataToSave = GetSettingsData();
    }

#region Reading
    //Can be called from other places to get the current save data
    public SaveData GetSaveData(){
        if (File.Exists(savePath)){
            //Tell it to read the entire file at the designated path, save that info to saveJson and close the reader to free up resources.
            StreamReader saveReader = new StreamReader(savePath);
            string saveJson = saveReader.ReadToEnd();
            saveReader.Close();

            //Create an empty SaveData object in case the existing one is empty
            SaveData saveData = new SaveData();
            //Transfer JSON to the data object if the save file wasn't empty
            if (saveJson != "") saveData = JsonUtility.FromJson<SaveData>(saveJson);
            return saveData;
        }
        else{
            Debug.LogError("Error finding save file!");
            return null;
        }
        
    }

    //Can be called from other places to get the current settings data
    public SettingsData GetSettingsData(){
        //This is the same as GetSaveData, but for the settings info
        if (File.Exists(settingsPath)){
            StreamReader settingsReader = new StreamReader(settingsPath);
            string settingsJson = settingsReader.ReadToEnd();
            settingsReader.Close();

            //Create an empty SaveData object in case the existing one is empty
            SettingsData settingsData = new SettingsData();
            //Transfer JSON to the data object if the save file wasn't empty
            if (settingsJson != "") settingsData = JsonUtility.FromJson<SettingsData>(settingsJson);
            return settingsData;
        }
        else{
            Debug.LogError("Error finding settings file!");
            return null;
        }
    }
#endregion

#region Writing
    #region Save File
    //Writes changes to disk
    public void SaveGameData(){
        //Convert our data object into JSON format
        string json = JsonUtility.ToJson(saveDataToSave);

        //Prepare to write to the path
        StreamWriter writer = new StreamWriter(savePath);

        //Tell it to write our json to the path
        writer.Write(json);

        //Tell it we're done writing and free up resources dedicated to writing.
        writer.Close();
    }

    //Updates the temporary save data. THIS DOES NOT SAVE TO DISK.
    public void UpdateSaveInfo(string variableName, string newValue){
        saveDataToSave.UpdateVariable(variableName, newValue);
    }
    #endregion

    #region Settings
    //Writes changes to disk
    public void SaveSettingsData(){
        //Convert our data object into JSON format
        string json = JsonUtility.ToJson(settingsDataToSave);

        //Prepare to write to the path
        StreamWriter writer = new StreamWriter(settingsPath);

        //Tell it to write our json to the path
        writer.Write(json);

        //Tell it we're done writing and free up resources dedicated to writing.
        writer.Close();
    }

    //Updates the temporary settings data. THIS DOES NOT SAVE TO DISK.
    public void UpdateSettingsInfo(string variableName, string newValue){
        settingsDataToSave.UpdateVariable(variableName, newValue);
    }
    #endregion
#endregion
}
