using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    public GameObject player;
    public GameObject goal;
    public GameObject mascot;
    public GameObject ExitSpawn;
    public GameObject spawn;
    public bool PlayerMode=false;

    void Awake()
    {
        positionGoalAndPlayers();
        setPlayerOrMascot();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void positionGoalAndPlayers()
    {
        Transform[] exitSpawnPoints=ExitSpawn.GetComponentsInChildren<Transform>();
        int spawnpointindex = Random.Range(1, exitSpawnPoints.Length);
        goal.transform.position = new Vector3 (exitSpawnPoints[spawnpointindex].position.x, goal.transform.position.y, exitSpawnPoints[spawnpointindex].position.z);
        Transform[] spawnPoints=spawn.GetComponentsInChildren<Transform>();
        spawnPoints=spawnPoints.Skip(1).ToArray();
        float[] distToSpwn=new float[spawnPoints.Length];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            distToSpwn[i]=Vector3.Distance(spawnPoints[i].position,goal.transform.position);
        }
        int maxDistIndex = distToSpwn.ToList().IndexOf(distToSpwn.Max());
        player.transform.position = new Vector3(spawnPoints[maxDistIndex].position.x, player.transform.position.y, spawnPoints[maxDistIndex].position.z);
        float[] distToPlayer=new float[spawnPoints.Length];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            distToPlayer[i]=Vector3.Distance(spawnPoints[i].position,player.transform.position);
        }
        int maxDistIndex2 = distToPlayer.ToList().IndexOf(distToPlayer.Max());
        mascot.transform.position = new Vector3(spawnPoints[maxDistIndex2].position.x, mascot.transform.position.y, spawnPoints[maxDistIndex2].position.z);
    }
    void setPlayerOrMascot(){
        GameObject playerCam= player.transform.Find("Camera").gameObject;
        GameObject mascotCam= mascot.transform.Find("Camera").gameObject;
        if (PlayerMode)
        {
            player.GetComponent<playerMoverment_script>().enabled=true;
            mascot.GetComponent<playerMoverment_script>().enabled=false;
            playerCam.SetActive(true);
            mascotCam.SetActive(false);
        }else
        {
            player.GetComponent<playerMoverment_script>().enabled=false;
            mascot.GetComponent<playerMoverment_script>().enabled=true;
            playerCam.SetActive(false);
            mascotCam.SetActive(true);
        }
    }
}
