using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game
{
    private static bool isLoaded;

    //Player
    private static Player player;

    //Game Data
    private static List<FacePart> partList;
    private static List<Character> characterList;

    public static bool CheckIsLoaded()
    {
        //Check if game data has been loaded
        return isLoaded;
    }

    public static void SetIsLoaded(bool aLoaded)
    {
        //Set whether game data has been loaded
        isLoaded = aLoaded;
    }

    public static Player GetPlayer()
    {
        if (player == null) player = new Player();

        return player;
    }

    public static void ClearGameData()
    {
        //Clears all game data lists by instantiating new lists
        partList = new List<FacePart>();
        characterList = new List<Character>();
    }

    #region Face Part

    public static List<FacePart> GetPartList()
    {
        return partList;
    }

    public static void SetPartList(List<FacePart> aList)
    {
        partList = aList;
    }

    public static void AddPart(FacePart aPart)
    {
        if (partList == null) partList = new List<FacePart>();

        partList.Add(aPart);
    }

    //TODO: Add any functions needed to get single parts, get part list by type, etc.

    #endregion Face Part

    #region Character

    public static List<Character> GetCharacterList()
    {
        return characterList;
    }

    public static Character GetPlayerCharacter()
    {
        return characterList.Find(x => x.GetRefId() == player.GetPlayerCharacter());
    }

    public static void SetCharacterList(List<Character> aList)
    {
        characterList = aList;
    }

    public static void AddCharacter(Character aCharacter)
    {
        if (characterList == null) characterList = new List<Character>();

        characterList.Add(aCharacter);
    }

    //TODO: Add any functions needed to get single characters, etc.

    #endregion Character

    //TODO: Add any functions for any other game data classes, etc.
}
