using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour {

    public float vx;
    public float vy;
    public float friction = 0.1f;
    public float amplitude = 0.5f;
    public float frequency = 8;
    public float thing = 0.2f;
    public float speed = 0.7f;
    
	void Start () {

	}

    void FixedUpdate() {
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        float sineValue = Mathf.Sin(frequency * Time.time);
        float amplitudeScale = Mathf.Abs(Mathf.Cos(Mathf.Atan2(vy, vx))) * (1 - thing) + thing;
        if (horiz == 0 && vert == 0)
        {
            amplitudeScale = 1;
        }
        float oscillation = amplitude * amplitudeScale * sineValue;

        vx += horiz * speed;
        vy += vert * speed;
        vx *= (1 - friction);
        vy *= (1 - friction);
        vy += oscillation;
        gameObject.transform.position += new Vector3(vx * Time.deltaTime, vy * Time.deltaTime, 0);
    }
}
