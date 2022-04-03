using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManagerPhoton : MonoBehaviour
{
    public static MenuManagerPhoton Instance;


    [SerializeField] MenuPhotn[] menus;

    void Awake()
    {
        Instance = this;
    }
    public void OpenMenu(string menuName)
    {
        for(int i = 0; i < menus.Length; i++)
        {
            if (menus[i].name == menuName)
            {
                OpenMenu(menus[i]);
            }
            else if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
    }

    public void OpenMenu(MenuPhotn menu)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
        menu.Open();
    }

    public void CloseMenu(MenuPhotn menu)
    {
        menu.Close();
    }
}
