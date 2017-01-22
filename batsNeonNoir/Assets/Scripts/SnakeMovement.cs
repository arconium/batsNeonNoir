using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SnakeMovement : MonoBehaviour {


	public Vector3[] points;
	private int current = 0;
	public float speed = 1.0f;


	void Start () {

	}

	void Update () {
		if ((transform.position - points[current]).magnitude < 0.05f) {
			current = (current + 1) % points.Length;
		}
		transform.position = Vector3.MoveTowards(transform.position, points[current], speed * Time.deltaTime);
	}
}