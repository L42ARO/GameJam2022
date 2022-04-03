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
	PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Player_FPV"), Vector3.zero, Quaternion.identity);
}
}