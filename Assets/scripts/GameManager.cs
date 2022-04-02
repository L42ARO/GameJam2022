using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // public static event  Action<GameState> OnGameStateChanged; 
    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
    //    updateGameState(GameState.MainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // public void updateGameState(GameState newState)
    // {
    //     State = newState;
    //     switch(newState){
    //         case GameState.MainMenu:
    //             break;
    //         case GameState.Game:
    //             break;
    //         case GameState.Pause:
    //             break;
    //         case GameState.GameOver:
    //             break;
    //         default:
    //             throw new ArgumentOutOfRangeException(nameof(gameState),newState,null);
    //     }
    //     OnGameStateChanged?.invoke(newState);
    // }
}

public enum GameState
{
    Menu,
    Playing,
    Paused,
    GameOver
}