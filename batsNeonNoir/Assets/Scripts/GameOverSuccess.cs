using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSuccess : MonoBehaviour {


    void Start()
    {
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("You Fucking WON, bro!");
    }


    void Update ()
    {

    }	
	



}
