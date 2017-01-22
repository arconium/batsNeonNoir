using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 // [RequireComponent(typeof(AudioSource))]


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
		if(pickedUp == true)
        {
            gameObject.SetActive(false);
        }

	}
}
