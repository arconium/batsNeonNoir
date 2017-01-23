using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour {
    // Keep this here
    public int worthPoints = 100;
    public GameObject player;
    bool pickedUp = false;


    void Start ()
    {
		
	}


    void OnTriggerEnter2D(Collider2D collider)
    {

        //CHECK THAT IT IS A PLAYER!
        if (collider.CompareTag("Player"))
        {
            AudioSource audio = GetComponent<AudioSource>();

            audio.Play();

            pickedUp = true;
            GivePoints();
            //gameObject.SetActive(false);

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 3);

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
