using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

[System.Serializable]
public class SaveData
{
    //Player
    public string stat_totaldeaths;

    //Resources gathered
    public string stat_lifetimegatheredresourcevalue;
    public string stat_lifetimegatheredweight;
    
    //Resources deposited
    public string stat_lifetimestoredresourcevalue;
    public string stat_lifetimestoredweight;

    //Shop
    public string stat_totalitemsboughtcount;

    //Objects
    public string stat_lifetimeobjectsbroken;

    //Contract history
    public string stat_totalsuccessfulcontractcount;
    public string stat_totalfailedcontractcount;

    //Active contract
    public string activecontract_status;
    public string activecontract_difficulty;

    //Currency 0, 4 and 5 are currently unused but were created in the event more are added
    public string currency_0;
    public string currency_1;
    public string currency_2;
    public string currency_3;
    public string currency_4;
    public string currency_5;

    //Belt items
    public string player_beltitems_0;
    public string player_beltitems_1;
    public string player_beltitems_2;
    public string player_beltitems_3;

    //Each variable needs to be included as an optional parameter here. If it is anything but a string, it needs a default value that matches the variable type
    public SaveData(
        string totaldeaths = "0",

        string lifetimegatheredresourcevalue = "0", 
        string lifetimegatheredweight = "0", 
        
        string lifetimestoredresourcevalue = "0", 
        string lifetimestoredweight = "0", 

        string lifetimeboughtitems = "0",

        string lifetimebrokenobjects = "0", 

        string lifetimesuccessfulcontracts = "0", 
        string lifetimefailedcontracts = "0", 
        string contractstatus = "",
        string contractdiff = "0",
        string cur0 = "0",
        string cur1 = "0",
        string cur2 = "0",
        string cur3 = "0",
        string cur4 = "0",
        string cur5 = "0",
        string belt0 = "null",
        string belt1 = "null",
        string belt2 = "null",
        string belt3 = "null"
        ){
        //Each variable needs to be set to that optional parameter here, so we can create save files with all of the required fields, 
        //but not require anything to be stored there yet.

        //Player
        stat_totaldeaths = totaldeaths;

        //Resources gathered
        stat_lifetimegatheredresourcevalue = lifetimegatheredresourcevalue;
        stat_lifetimegatheredweight = lifetimegatheredweight;

        //Resources stored
        stat_lifetimestoredresourcevalue = lifetimestoredresourcevalue;
        stat_lifetimestoredweight = lifetimestoredweight;

        //Shop
        stat_totalitemsboughtcount = lifetimeboughtitems;

        //Objects
        stat_lifetimeobjectsbroken = lifetimebrokenobjects;

        //Contract History
        stat_totalsuccessfulcontractcount = lifetimesuccessfulcontracts;
        stat_totalfailedcontractcount = lifetimefailedcontracts;

        //Active contract
        activecontract_status = contractstatus;
        activecontract_difficulty = contractdiff;

        //Currencies
        currency_0 = cur0;
        currency_1 = cur1;
        currency_2 = cur2;
        currency_3 = cur3;
        currency_4 = cur4;
        currency_5 = cur5;

        //Belt items
        player_beltitems_0 = belt0;
        player_beltitems_1 = belt1;
        player_beltitems_2 = belt2;
        player_beltitems_3 = belt3;
    }

    //Called from SaveLoad. It finds the variable matching the varName parameter and sets its value to newVal
    public void UpdateVariable(string varName, string newVal){
        FieldInfo field = typeof(SaveData).GetField(varName);
        field.SetValue(this, newVal);
    }
}
