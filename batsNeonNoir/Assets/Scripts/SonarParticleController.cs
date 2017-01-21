using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarParticleController : MonoBehaviour {
	public Vector3 velocity;
	public Color color;
	public Light light;
	public float timeToFade;
	float t;

	void Start() {
		t = 0;
		light.color = color;
	}

	void Update() {
		light.color = Color.Lerp(color, Color.black, t/timeToFade);
		t += Time.deltaTime;
		if (t > timeToFade)
			Destroy(gameObject);
	}

	void FixedUpdate() {
		transform.position += velocity * Time.deltaTime;
	}
}
