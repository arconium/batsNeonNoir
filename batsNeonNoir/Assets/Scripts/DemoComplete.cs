using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoComplete : MonoBehaviour {

	public GameObject batPlayer;

	// Use this for initialization
	void Start () {
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject == batPlayer) {
			GUIController.colorIndex = 0;
			GUIController.health = 3;
			GUIController.score = 0;
			Application.LoadLevel ("MainScene");
		}
	}
		
	// Update is called once per frame
	void Update () {
		
	}
}
