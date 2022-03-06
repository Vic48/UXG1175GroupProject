using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEditor;

public static class DataManager
{
    private static string dataPath = "Assets/Data/{0}.txt";
    private static bool isLoading = false;

    private static RefData refData;

    #region Database

    public static void LoadGameDataBaseCo()
    {
        //Load game data from json text file
        string dataFileName = "RefData";

        isLoading = true;
        //Asynchronous load text file
        Addressables.LoadAssetAsync<TextAsset>(string.Format(dataPath, dataFileName)).Completed += (data) =>
        {
            //when text file has been loaded, process result
            string loadedText = data.Result.text;

            Common.DebugLog("LoadGameDataBaseCo " + string.Format(dataPath, dataFileName) + "\n" + loadedText);

            //Convert text to json and load into RefData object
            refData = JsonUtility.FromJson<RefData>(loadedText);

            //Convert RefData into game data
            ProcessRefData(refData);

            isLoading = false;
        };
    }

    public static bool CheckLoading()
    {
        return isLoading;
    }

    public static void ProcessRefData(RefData refData)
    {
        //Convert RefData into game data

        Game.ClearGameData();

        //Create Character objects
        foreach (RefCharacter refCharacter in refData.RefCharacter)
        {
            Game.AddCharacter(new Character(refCharacter.refId, refCharacter.name, Common.HexToColor(refCharacter.colour)));
        }

        //Create FacePart objects
        foreach (RefFacePart refPart in refData.RefFacePart)
        {
            PartType partType = Common.ParseEnum<PartType>(refPart.assetType);
            
            switch (partType)
            {
                case PartType.SHAPE:
                    Game.AddPart(new PartShape(refPart.refId, refPart.name, refPart.assetName) as FacePart);
                    break;
                case PartType.EYES:
                    Game.AddPart(new PartEyes(refPart.refId, refPart.name, refPart.assetName) as FacePart);
                    break;
                case PartType.NOSE:
                    Game.AddPart(new PartNose(refPart.refId, refPart.name, refPart.assetName) as FacePart);
                    break;
                case PartType.MOUTH:
                    Game.AddPart(new PartMouth(refPart.refId, refPart.name, refPart.assetName) as FacePart);
                    break;
            }

        }
    }

    #endregion Database
}
