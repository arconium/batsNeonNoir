using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveIndicator : MonoBehaviour {

    public GameObject player;
	Color[] arr = { Color.red, Color.green, Color.blue };

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponentInChildren<SpriteRenderer> ().color = arr [GUIController.colorIndex];
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pos = player.transform.position;
        Vector3 thing = mouse - pos;
        gameObject.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(thing.y, thing.x) * 180 / 3.141f, Vector3.forward);
	}
}
