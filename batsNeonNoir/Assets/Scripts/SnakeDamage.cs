using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeDamage : MonoBehaviour {

    // Keep this here
    public int enemyDamage = 1;
    //public GameObject player;


    void Start () {
		
	}


    public void OnTriggerEnter2D( Collider2D other2)
    {
		// Attack animation

        // Give damage
        BatController giveDamage = other2.gameObject.GetComponent<BatController>();
        //BatController giveDamage = player.GetComponent<BatController>();
		giveDamage.takedamage(enemyDamage);
        
    }


    void FixedUpdate () {
	
        
        	
	}
}
