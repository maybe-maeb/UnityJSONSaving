using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

[System.Serializable]
public class SaveData
{
    //Variables to save
    public string material;
    public string TestValue;

    //Each variable needs to be included as an optional parameter here
    public SaveData(string mat = "", string testVal = ""){
        //Each variable needs to be set to that optional parameter here, so we can create save files with all of the required fields, 
        //but not require anything to be stored there yet.
        material = mat;
        TestValue = testVal;
    }

    //Called from SaveLoad. It finds the variable matching the varName parameter and sets its value to newVal
    public void UpdateVariable(string varName, string newVal){
        FieldInfo field = typeof(SaveData).GetField(varName);
        field.SetValue(this, newVal);
    }
}
