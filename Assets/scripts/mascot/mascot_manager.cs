using UnityEngine;

public class mascot_manager : MonoBehaviour
{   
    public playerMoverment movement;
   void OnControllerColliderHit(ControllerColliderHit collisionInfo)
   {
       if(collisionInfo.gameObject.GetComponent<Collider>().name == "Player")
       {
           
           collisionInfo.gameObject.GetComponent<statsController>().game();
           FindObjectOfType<GameManager>();
            
       }
   }

    
}
