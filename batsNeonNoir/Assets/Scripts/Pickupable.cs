using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour {
    // Keep this here
    public int worthPoints = 100;
    public GameObject player;
   // bool pickedUp = false;

    void Start ()
    {
		
	}

    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player")) {//CHECK THAT IT IS A PLAYER GUYS. please...
            //pickedUp = true;
            GivePoints();
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    public void GivePoints()
    {
        //player.GetComponent<BatController>().score += worthPoints;
		//Debug.Log("Worth Points: " + worthPoints);
		GUIController.score += worthPoints;
    }


	void Update ()
    {
		
	}
}
