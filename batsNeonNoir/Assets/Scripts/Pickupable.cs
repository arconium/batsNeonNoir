using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour {

    // MOVE THIS TO GameManager ?
    public int currentPoints;
    
    // Keep this here
    public int worthPoints = 100;
    
   // bool pickedUp = false;


    void Start ()
    {
		
	}

    
    void OnTriggerEnter2D(Collider2D collider)
    {
      //  pickedUp = true;
        GivePoints();
       gameObject.SetActive(false);
    }

    public void GivePoints()
    {
        currentPoints += currentPoints + worthPoints;

        Debug.Log(currentPoints);
    }


	void Update ()
    {
		
	}
}
