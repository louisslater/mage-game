using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a single instance class to manage the game
public class GameMaster : MonoBehaviour
{

    private static GameMaster instance;
    public Vector2 lastCheckPointPos;
   
    void Awake()
    {
        lastCheckPointPos.Set(0f, -0.5f);
       if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
       else
        {
            Destroy(gameObject);
        }
    }
}
