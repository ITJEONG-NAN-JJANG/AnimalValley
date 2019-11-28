﻿using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings
{
    private static bool hasItemNamePairData = false;
    static List<KeyValuePair<string, string>> itemNamePair;

    public static bool HasItemNamePairData
    {
        get
        {
            return HasItemNamePairData;
        }
    }

    public static void RoadItemName()
    {
        itemNamePair = new List<KeyValuePair<string, string>>();

        try
        {
            string path = "Assets/Scripts/SystemSettings/CharacterSettings/item.data";
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(fileStream);

            string[] lines = streamReader.ReadToEnd().Trim('\n').Split('\n');

            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                itemNamePair.Add(new KeyValuePair<string, string>(data[0], data[1]));
            }

        }
        catch (Exception exception)
        {
            Debug.Log(exception.Message);
            Debug.Log("FAILED: ");
        }


        hasItemNamePairData = true;

    }
    public static string GetItemName(string itemCode)
    {
        string name = "";
        if (!hasItemNamePairData)
        {
            Debug.Log("아이템 정보를 불러오지 않았음");
            return null;
        }

        if (itemNamePair.Count > 1)
            foreach (KeyValuePair<string, string> itemNameValue in itemNamePair)
            {
                if (itemNameValue.Key.Equals(itemCode))
                    return itemNameValue.Value;
            }

        return name;
    }
}