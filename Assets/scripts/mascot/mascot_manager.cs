using UnityEngine;


public class mascot_manager : MonoBehaviour
{   
    public GameObject[] mascot_array = new GameObject[5];
    

    void Awake(){
        System.Random rnd = new System.Random();
        int Cosplay = rnd.Next(0,4);

        if (Cosplay == 0){
            mascot_array[0].SetActive(true);
            mascot_array[0].GetComponent<AudioSource>().enabled=true;
        } else if(Cosplay == 1){
            mascot_array[1].SetActive(true);
            mascot_array[1].GetComponent<AudioSource>().enabled=true;
        } else if(Cosplay == 2){
            mascot_array[2].SetActive(true);
            mascot_array[2].GetComponent<AudioSource>().enabled=true;
        } else if(Cosplay == 3){
            mascot_array[3].SetActive(true);
            mascot_array[3].GetComponent<AudioSource>().enabled=true;
        } else if(Cosplay == 4){
            mascot_array[4].SetActive(true);
            mascot_array[4].GetComponent<AudioSource>().enabled=true;
        }
    }

    //public playerMoverment movement;
   void OnControllerColliderHit(ControllerColliderHit collisionInfo)
   {
       if(collisionInfo.gameObject.GetComponent<Collider>().name == "Player")
       {
           
           collisionInfo.gameObject.GetComponent<statsController>().game();
           //FindObjectOfType<GameManager>().EndGame();

       }

       
   }

    
}
