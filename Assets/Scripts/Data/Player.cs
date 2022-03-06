using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    //For player data only
    private string playerCharacter;
    private int day;

    //TODO: add any player data that needs to be tracked

    public Player()
    {
        playerCharacter = "";
        day = 0;
    }

    public string GetPlayerCharacter()
    {
        return playerCharacter;
    }

    public void SetPlayerCharacter(string aCharacter)
    {
        playerCharacter = aCharacter;
    }

    public int GetDay()
    {
        return day;
    }

    public void SetDay(int aDay)
    {
        day = aDay;
    }

    public void AddDay(int aDay)
    {
        day += aDay;
    }

    //TODO: add functions for any player data added
}
