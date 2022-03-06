using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    private bool isLoading = false;

    void Start()
    {
        //Runs when LoadScreen loaded
        isLoading = true;

        //start loading game data
        DataManager.LoadGameDataBaseCo();
    }

    void Update()
    {
        if (isLoading)
        {
            if (!DataManager.CheckLoading())
            {
                //If game data finished loading, set game loaded to true
                Game.SetIsLoaded(true);

                //End loading and start game
                SceneManager.LoadScene("Main");
            }
        }
    }
}
