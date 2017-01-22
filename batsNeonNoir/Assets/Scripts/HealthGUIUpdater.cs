using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthGUIUpdater : MonoBehaviour {

	public GameObject healthZero;
	public GameObject healthOne;
	public GameObject healthTwo;

	// Use this for initialization
	void Start () {
		healthZero.SetActive (true);
		healthOne.SetActive (true);
		healthTwo.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {

//		Debug.Log ("GUI Controller.Health: " + GUIController.health);

		if (GUIController.health >= 3) {
			healthZero.SetActive (true);
			healthOne.SetActive (true);
			healthTwo.SetActive (true);
		}
		if (GUIController.health == 2) {
			healthZero.SetActive (true);
			healthOne.SetActive (true);
			healthTwo.SetActive (false);
		}
		if (GUIController.health == 1) {
			healthZero.SetActive (true);
			healthOne.SetActive (false);
			healthTwo.SetActive (false);
		}
		if (GUIController.health == 0) {
			healthZero.SetActive (false);
			healthOne.SetActive (false);
			healthTwo.SetActive (false);
		}
	}
}
