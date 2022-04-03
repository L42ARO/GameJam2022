using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool mascotSet=false;
    public int gameState;
    bool setUp=false;
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
    }
    void Start()
    {
        
    }
    
    void Update()
    {
        if(instance.gameState>0 && instance.setUp){
            // print("runing");
        }
        
    }
    public void setUpReady(bool c){
        instance.setUp=true;
        instance.mascotSet=c;
        print("Mascot: "+instance.mascotSet);
        if (!c) print((GameObject.Find("Mascot")!=null) ? "Found Mascot" : "Mascot Not Found");
        else print((GameObject.Find("Player_FPV")!=null) ? "Found Player" : "Player Not Found");
    }
}