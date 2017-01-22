using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCollider : MonoBehaviour {

	public GameObject spider;

	// Use this for initialization
	void Start () {
		
	}

	public void OnTriggerEnter2D(Collider2D collision) {
		spider.GetComponent<Spider_Movement>().goal = collision.transform;
		spider.GetComponent<Spider_Movement> ().toWeb = true;
	}

	public void OnTriggerExit2D(Collider2D collision) {
		spider.GetComponent<Spider_Movement> ().toWeb = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Component thing = spider.GetComponent<Spider_Movement>()
	}
}
