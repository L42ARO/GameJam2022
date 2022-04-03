/* using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    private Button startServerButton;

    private Button startHostButton;

    private Button startClientButton;
    // Start is called before the first frame update

    private void Awake()
    {
        Cursor.visible = true;
    
    }

    private void Update()
    {
       // playersInGameText.text=
    }
    void Start()
    {
        startHostButton.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.StartHost())
            {

            }
        });
    }

    // Update is called once per frame
   // void Update()
  //  {
        
  //  }
}
  */