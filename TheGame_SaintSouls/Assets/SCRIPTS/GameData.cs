using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public int PlayersLastLevel = 1;

    private static GameData instance;
    public static GameData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameData();
            }

            return instance;
        }
    }
}
