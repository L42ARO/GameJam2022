using Photon.Pun;
using Photon.Realtime;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupController : MonoBehaviourPunCallbacks
{
    // ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    public int randNum = -1;
    public bool mascotSet = false;
    public GameManager instance;
    void Start()
    {
        PhotonNetwork.SendRate = 40;
        PhotonNetwork.SerializationRate = 40;
        PhotonNetwork.AutomaticallySyncScene = true;
        System.Random rnd = new System.Random();
        instance=GameObject.Find("GameManager").GetComponent<GameManager>();
        randNum = rnd.Next(0, 1);
        print(randNum);
        CreatePlayer();
        instance.setUpReady(mascotSet);
    }
    private void CreatePlayer()
    {
            if (!PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Player_FPV"), new Vector3(5, 5, 5), Quaternion.identity);
                mascotSet=false;
            }
            else
            {
                PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Mascot"), new Vector3(5, 5, 5), Quaternion.identity);
                mascotSet=true;
            }
        print("Creating Player");

    }
    /*public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting && PhotonNetwork.IsMasterClient)
        {
            stream.SendNext(randNum);
        }
        else if (stream.IsReading && !PhotonNetwork.IsMasterClient)
        {
          print((int)stream.ReceiveNext());
            if ((int)stream.ReceiveNext() != -1)
            {
                randNum = (int)stream.ReceiveNext();
                if(randNum==1) randNum=0;
                else randNum=1;
                CreatePlayer();
            }
        }
    }*/

    // public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    //     {
    //         if(targetPlayer!=PhotonNetwork.LocalPlayer && !PhotonNetwork.IsMasterClient){
    //             if(changedProps.ContainsKey("Characters")){
    //                 print(changedProps["Characters"]);
    //                 if ((int)targetPlayer.CustomProperties["Characters"]==0){
    //                     playerProperties["Characters"]=1;
    //                     PhotonNetwork.LocalPlayer.SetCustomProperties(playerProperties);
    //                 }else{
    //                     playerProperties["Characters"]=0;
    //                     PhotonNetwork.LocalPlayer.SetCustomProperties(playerProperties);
    //                 }
    //                 print((int)PhotonNetwork.LocalPlayer.CustomProperties["Characters"]);

    //                 }
    //             }
    //             else if (targetPlayer==PhotonNetwork.LocalPlayer){
    //                 if(changedProps.ContainsKey("Characters")){
    //                     playerProperties["Characters"]=(int)targetPlayer.CustomProperties["Characters"];
    //                 }
    //             }
    //         }
}