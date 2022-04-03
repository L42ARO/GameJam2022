using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkController : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        if(!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
        
    }
public override void OnConnectedToMaster() 
{
    Debug.Log("Connected to the " +  PhotonNetwork.CloudRegion +  " server!");
    
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
