using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Lose_UI : MonoBehaviour
{
    public GameObject win_UI;
    public GameObject lose_UI;
    public GameObject victory_UI;
    public void Win()
    {
        win_UI.SetActive(true);
    }
    public void Lose()
    {
        lose_UI.SetActive(true);
    }
    public void victory()
    {
        victory_UI.SetActive(true);
    }
}
