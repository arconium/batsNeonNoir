using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeDamage : MonoBehaviour {

    // Keep this here
    public int enemyDamage = 1;
    //public GameObject player;


    void Start () {
		
	}


    public void OnTriggerEnter2D( Collider2D other)
    {
        if (other.CompareTag("Player")) { //dont want to attack particles please :)
            // Attack animation

            //Debug.Log(other);

            // Give damage
            BatController giveDamage = other.gameObject.GetComponent<BatController>();
            //BatController giveDamage = player.GetComponent<BatController>();


            giveDamage.takedamage(enemyDamage);
        }

    }


    void FixedUpdate () {
	
        
        	
	}
}
