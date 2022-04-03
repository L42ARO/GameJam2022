using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool mascotSet=false;
    public int gameState;
    public GameObject goal;
    Win_Lose_UI win_loss_UI;
    GameObject player;
    bool setUp=false;
    public bool win=false;
    public bool victory=false;
    string[] levelNames = new string[] { "Level1_AI", "Level2_AI", "Level3_AI", "Level4_AI"};
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

        instance.gameState = 0;
        instance.gameState=GameObject.Find("Level_docs").GetComponent<Level_docs>().sceneState;
        print(instance.gameState);
        if (instance.gameState > 0)
        {
            instance.win=false;
            instance.setUp=false;
            instance.win_loss_UI = GameObject.Find("WinLoseUI").GetComponent<Win_Lose_UI>();

        }
    }
    void Start()
    {
        
    }
    
    void Update()
    {
        if(instance.gameState>0 && instance.setUp){
        //     GoalController bolsonaro =  goal.GetComponent<GoalController>();
        //     if(instance.mascotSet==false){
        //         playerMoverment_script dilma = player.GetComponent<playerMoverment_script>();
        //         if (bolsonaro.trump_hair == true){
        //             print(bolsonaro.trump_hair+" YOU WIN!");
        //             dilma.enabled =false;
        //     }

        
        //     }
        }
        
    }
    public void setUpReady(bool c, GameObject newPlayer){
        instance.setUp=true;
        instance.mascotSet=c;
        instance.player=newPlayer;
        print("Mascot: "+instance.mascotSet);
        if (!c) print((GameObject.Find("Mascot")!=null) ? "Found Mascot" : "Mascot Not Found");
        else print((GameObject.Find("Player_FPV")!=null) ? "Found Player" : "Player Not Found");
    }
    public void LevelWon(){
        if(gameState<4){
            instance.win=true;
            instance.win_loss_UI.Win();
            SceneManager.LoadScene(levelNames[gameState]);
        }else{
            instance.victory=true;
        }
    }
}