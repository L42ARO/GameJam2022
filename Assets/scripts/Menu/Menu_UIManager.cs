using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu_UIManager : MonoBehaviour
{
    public static Menu_UIManager instance;
    public GameObject startButton;
    public void startGame(){
        print("start game");
        SceneManager.LoadScene("name of scene", LoadSceneMode.Single);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
