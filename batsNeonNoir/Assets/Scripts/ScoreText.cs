﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

	public Text scoreTextContainer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		Debug.Log ("Score = " + GUIController.score);
		scoreTextContainer.text = "Score: " + GUIController.score;
	}
}
