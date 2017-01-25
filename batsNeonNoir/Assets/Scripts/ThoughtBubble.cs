using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThoughtBubble : MonoBehaviour {

	public GameObject triggerCollider;
	public int secondsToDisplay = 5;

	// Update is called once per frame
	void Update () {
		transform.localPosition = new Vector3(0, 10, 0);
		transform.rotation = Quaternion.Euler (0, 0, 0);
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject == triggerCollider) {
			gameObject.GetComponent<SpriteRenderer> ().enabled = true;
			Destroy (this.gameObject, secondsToDisplay);
			Destroy (other.gameObject);
		}
		if (other.gameObject != triggerCollider && other.gameObject.tag == "Tutorial Prompt") {
			Destroy (this.gameObject);
		}
	}
}
