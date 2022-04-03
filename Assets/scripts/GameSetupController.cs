using Photon.Pun;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupController : MonoBehaviour{
    void Start()
    {
      CreatePlayer();
    }
  private void CreatePlayer()
{
	print("Creating Player");
  GameObject[] mascots= GameObject.FindGameObjectsWithTag("Enemy");
  if(mascots == null || mascots.Length == 0)
  {
    
    print("Mascot not found");
	  PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Mascot"), new Vector3 (5,5,5), Quaternion.identity);
  }
  else{
    print("Mascot found");
    PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Player_FPV"), new Vector3 (5,5,5), Quaternion.identity);
  }
}
}