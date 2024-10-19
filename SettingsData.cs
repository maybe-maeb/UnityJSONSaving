using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

[System.Serializable]
public class SettingsData
{
    //Variables to save
    public string headBobbingAmount;
    public string microphoneIndex;
    public string devConsoleEnabled;

    //Each variable needs to be included as an optional parameter here. If it is anything but a string, it needs a default value that matches the variable type
    public SettingsData(string headBobbing = "0", string micIndex = "0", string devEnabled = "0"){
        //Each variable needs to be set to that optional parameter here, so we can create save files with all of the required fields, 
        //but not require anything to be stored there yet.
        headBobbingAmount = headBobbing;
        microphoneIndex = micIndex;
        devConsoleEnabled = devEnabled;
    }

    //Called from SaveLoad. It finds the variable matching the varName parameter and sets its value to newVal
    public void UpdateVariable(string varName, string newVal){
        FieldInfo field = typeof(SettingsData).GetField(varName);
        field.SetValue(this, newVal);
    }
}
