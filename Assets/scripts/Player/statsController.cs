using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statsController : MonoBehaviour
{   public int health = 5;
    public int life = 0;
    public bool gameNotOver = true;


    public void game(){
        
        if (health == life){
        gameNotOver = false;
        print("GAME OVER");
    } else
    {
        health -= 1;
    }
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(GetComponent<mascot_manager>().gameObject);
    }
    void OnControllerColliderHit(ControllerColliderHit collisionInfo)
   {
       if(collisionInfo.gameObject.GetComponent<Collider>().name == "Mascit")
       {
           
           print("Collided with Mascot");
            game();
           //FindObjectOfType<GameManager>().EndGame();

       }

       
   }
}
