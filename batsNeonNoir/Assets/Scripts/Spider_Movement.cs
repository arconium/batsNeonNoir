using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spider_Movement : MonoBehaviour {

	public Vector3[] points;
	public bool toWeb = false;
	private int current = 0;
	public float speed = 1.0f;
	public Transform goal;
	void Start () {

	}

	void Update () {
		Vector3 thing;
		if (toWeb) {
			thing = goal.position;
		} else {
			Vector3 difference = transform.position - points [current];
			difference.z = 0;
			if (difference.magnitude < 0.05f) {
				current = (current + 1) % points.Length;
			}
			thing = points [current];
		}
		thing.z = transform.position.z;
		transform.position = Vector3.MoveTowards(transform.position, thing, speed * Time.deltaTime);

	}
}
