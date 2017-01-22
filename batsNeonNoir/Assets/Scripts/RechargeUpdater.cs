using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeUpdater : MonoBehaviour {

	public GameObject rechargeRed;
	public GameObject rechargeGreen;
	public GameObject rechargeBlue;

	private Animator greenFlashAnimator;
	private Animator redFlashAnimator;
	private Animator blueFlashAnimator;

	// Use this for initialization
	void Start () {
		rechargeGreen.SetActive (true);
		rechargeRed.SetActive (true);
		rechargeBlue.SetActive (true);

		greenFlashAnimator = rechargeGreen.GetComponent<Animator> ();
		redFlashAnimator = rechargeRed.GetComponent<Animator> ();
		blueFlashAnimator = rechargeBlue.GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {

			if (GUIController.colorIndex == 0) { // Red
//				Debug.Log("Red: " + GUIController.colorIndex);
				redFlashAnimator.SetTrigger("RedClicked");
			}
			if (GUIController.colorIndex == 1) { // Green
//				Debug.Log("Green: " + GUIController.colorIndex);
				greenFlashAnimator.SetTrigger("GreenClicked");
			}
			if (GUIController.colorIndex == 2) { // Blue
//				Debug.Log("Blue: " + GUIController.colorIndex);
				blueFlashAnimator.SetTrigger("BlueClicked");
			}
		}
	}


		
}
