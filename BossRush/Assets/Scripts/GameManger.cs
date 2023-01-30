using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    StartScreen,
    BossFight,
    Win,
    Loss,
    Loading,
}
public class GameManger : MonoBehaviour
{
    private GameState CurrentState;
    // Start is called before the first frame update
    void Start()
    {
        CurrentState = GameState.StartScreen;
    }

    // Update is called once per frame
    void Update()
    {
        switch(CurrentState)
        {
            case GameState.StartScreen:
                {

                    return;
                }
        }
            
            
        
    }
}
