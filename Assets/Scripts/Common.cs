using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Common
{
    //Common class for game constants or reusable common functions

    public const bool showDebug = true;
    public const bool showDebugError = true;

    public static void DebugLog(string aText)
    {
        //Display text in console
        if (showDebug) Debug.Log(aText);
    }

    public static void DebugError(string aText)
    {
        //Display text in console as error
        if (showDebugError) Debug.LogError(aText);
    }

    public static T ParseEnum<T>(string value) where T : System.Enum
    {
        try
        {
            return (T)System.Enum.Parse(typeof(T), value);
        }
        catch
        {
            throw new System.Exception("Error Parsing Enum: " + value);
        }

    }

    public static Color HexToColor(string hex)
    {
        //Convert hex colour string into Color
        hex = hex.Replace("0x", "");//in case the string is formatted 0xFFFFFF
        hex = hex.Replace("#", "");//in case the string is formatted #FFFFFF

        byte a = 255;//assume fully visible unless specified in hex
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

        //Only use alpha if the string has enough characters
        if (hex.Length == 8)
        {
            a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
        }

        return new Color32(r, g, b, a);
    }

    public static List<int> GetRandomIntList(int listCount, int selectCount)
    {
        //Randomize list of integers from 0 to listCount - 1 (no repeats)
        List<int> selectList = new List<int>();
        List<int> randomList = new List<int>();

        //Ensure cannot pick more than available index list
        selectCount = Mathf.Min(listCount, selectCount);

        //Make list to randomize from
        for (int i = 0; i < listCount; i++)
        {
            randomList.Add(i);
        }

        //Loop for each number to select
        while (randomList.Count > 0 && selectCount > 0)
        {
            //Randomize number from list and add to selectList
            int randomIndex = Random.Range(0, randomList.Count);
            selectList.Add(randomList[randomIndex]);

            //Remove selected number
            randomList.RemoveAt(randomIndex);
            selectCount -= 1;
        }

        return selectList;
    }

    public static List<T> GetRandomList<T>(List<T> tList, int selectCount)
    {
        //Select list of items from full list using GetRandomIntList
        List<int> indexList = GetRandomIntList(tList.Count, selectCount);
        List<T> randomList = new List<T>();

        foreach(int i in indexList)
        {
            randomList.Add(tList[i]);
        }

        return randomList;
    }
}
