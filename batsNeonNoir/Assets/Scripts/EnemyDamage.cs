using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    // Keep this here
    public int enemyDamage = 1;
    //public GameObject player;

    void Start () {
		
	}


    public void OnCollisionEnter2D(Collision2D collision)
    {
        BatController giveDamage = collision.collider.GetComponent<BatController>();
        //BatController giveDamage = player.GetComponent<BatController>();
        giveDamage.playerHealth -= enemyDamage;
        Debug.Log(giveDamage.playerHealth);
    }


    void FixedUpdate () {
	
        
        	
	}
}
