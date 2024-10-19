using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

[System.Serializable]
public class SaveData
{
    //Variables to save
    public string stat_lifetimegatheredresourcevalue;
    public string stat_lifetimegatheredweight;

    //Each variable needs to be included as an optional parameter here. If it is anything but a string, it needs a default value that matches the variable type
    public SaveData(string lifetimegatheredresourcevalue = "0", string lifetimegatheredweight = "0"){
        //Each variable needs to be set to that optional parameter here, so we can create save files with all of the required fields, 
        //but not require anything to be stored there yet.
        stat_lifetimegatheredresourcevalue = lifetimegatheredresourcevalue;
        stat_lifetimegatheredweight = lifetimegatheredweight;
    }

    //Called from SaveLoad. It finds the variable matching the varName parameter and sets its value to newVal
    public void UpdateVariable(string varName, string newVal){
        FieldInfo field = typeof(SaveData).GetField(varName);
        field.SetValue(this, newVal);
    }
}
