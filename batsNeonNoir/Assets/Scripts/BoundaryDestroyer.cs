﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDestroyer : MonoBehaviour {

	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);

    }

    void Update ()
    {
	    
        
        	
	}
}
