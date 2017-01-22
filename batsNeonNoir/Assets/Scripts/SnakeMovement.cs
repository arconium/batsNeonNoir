using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SnakeMovement : MonoBehaviour {


	public Vector3[] points;
	private int current = 0;
	public float speed = 1.0f;
    public bool horizontal;
    public bool pos;

	void Start () {

	}

	void Update () {
		if ((transform.position - points[current]).magnitude < 0.05f) {
			current = (current + 1) % points.Length;
            if (horizontal && (pos && points[current].x < transform.position.x || !pos && points[current].x > transform.position.x))
            {
                pos = !pos;
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
            if (!horizontal && (pos && points[current].y < transform.position.y || !pos && points[current].y > transform.position.y))
            {
                pos = !pos;
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
        }
		transform.position = Vector3.MoveTowards(transform.position, points[current], speed * Time.deltaTime);
		
	}
}