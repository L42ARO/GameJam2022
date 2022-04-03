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
  GameObject[] mascots= GameObject.FindGameObjectsWithTag("Mascot");
  if(mascots != null)
  {
    // print(mascots[0]);
    print("Mascot found");
    PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Player_FPV"), new Vector3 (0,1,0), Quaternion.identity);
    
  }
  else{
    print("Mascot not found");
	  PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Mascot"), new Vector3 (0,1,0), Quaternion.identity);
  }
}
}