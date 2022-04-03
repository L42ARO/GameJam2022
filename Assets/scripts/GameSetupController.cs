using Photon.Pun;
using Photon.Realtime;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameSetupController : MonoBehaviourPunCallbacks
{
    // ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    public int randNum = -1;
    public bool mascotSet = false;
    public GameObject spawnPointGroup;
    public GameObject exitSpawnPointGroup;
    public GameManager instance;
    public GameObject goal;
    void Start()
    {
        PhotonNetwork.SendRate = 40;
        PhotonNetwork.SerializationRate = 40;
        PhotonNetwork.AutomaticallySyncScene = true;
        instance=GameObject.Find("GameManager").GetComponent<GameManager>();
        positionGoalAndPlayer();
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
    void positionGoalAndPlayer(){
        if(PhotonNetwork.IsMasterClient){
            Transform[] exitSpawnPoints=exitSpawnPointGroup.GetComponentsInChildren<Transform>();
            System.Random rnd = new System.Random();
            int spawnpointindex = rnd.Next(1, exitSpawnPoints.Length);
            goal.transform.position = new Vector3 (exitSpawnPoints[spawnpointindex].position.x, goal.transform.position.y, exitSpawnPoints[spawnpointindex].position.z);
            Transform[] spawnPoints=spawnPointGroup.GetComponentsInChildren<Transform>();
            float[] distToMascot=new float[spawnPoints.Length];
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                distToMascot[i]=Vector3.Distance(spawnPoints[i].position,goal.transform.position);
            }
            int minDistIndex = distToMascot.ToList().IndexOf(distToMascot.Min());
            Vector3 newMascotPos= new Vector3(spawnPoints[minDistIndex].position.x, 7, spawnPoints[minDistIndex].position.z);
            PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Mascot"), newMascotPos, Quaternion.identity);
                mascotSet=true;
        }
        else if(!PhotonNetwork.IsMasterClient){
            Transform[] spawnPoints=spawnPointGroup.GetComponentsInChildren<Transform>();
            float[] distToPlayer=new float[spawnPoints.Length];
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                distToPlayer[i]=Vector3.Distance(spawnPoints[i].position,goal.transform.position);
            }
            int minDistIndex = distToPlayer.ToList().IndexOf(distToPlayer.Min());
            Vector3 newMascotPos= new Vector3(spawnPoints[minDistIndex].position.x, 7, spawnPoints[minDistIndex].position.z);
            PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Mascot"), newMascotPos, Quaternion.identity);
                mascotSet=true;
        }

    }

}