using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour {

	public Canvas menu;
	public Button retryButton;
	public Button exitButton;
	public Button creditsButton;

	// Use this for initialization
	void Start () {
		menu = menu.GetComponent<Canvas> ();
		retryButton = retryButton.GetComponent<Button> ();
		exitButton = exitButton.GetComponent<Button> ();
		creditsButton = creditsButton.GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RetryPressed () {
		GUIController.colorIndex = 0;
		GUIController.health = 3;
		GUIController.score = 0;
		Application.LoadLevel ("MainScene");
	}

	public void CreditsPressed () {
		Application.LoadLevel ("Credits");
	}

	public void ExitPressed () {
		Application.Quit ();
	}


}
