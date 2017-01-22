using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarParticleController : MonoBehaviour {
	public Vector3 velocity;
	public Color color;
	public Light light;
	public float timeToFade;
	public bool lingerLaying; // DO NOT TOUCH
	public float lingerInterval;
	float faderT;
	float lingerT;

	public bool lingering;
	public float lingerRate;

	public float intensity;

	//worst way EVER
	public GameObject lingeringParent;

	void Start() {
		lingerLaying = false;
		faderT = 0;
		lingerT = lingerInterval;
		light.color = color;
		light.intensity = intensity;
	}

	void Update() {
		//kill if faded to 0
		if (lingering) {
			if (faderT >= timeToFade )//* lingerRate)
				Destroy(gameObject);
		}
		else if (faderT >= timeToFade)
			Destroy(gameObject);
		
		//
		if (lingerLaying) {
			if (lingerT >= lingerInterval) {
				layALingerer();
				lingerT = 0;
			}
			lingerT += Time.deltaTime;
		}

		//fade
		light.color = Color.Lerp(color, Color.black, faderT/timeToFade);

		//update timing
		faderT += Time.deltaTime;
	}

	//move
	void FixedUpdate() {
		transform.position += velocity * Time.deltaTime;
	}

	//clone a particle that will fade but not move or linger
	public void layALingerer() {
		//Instantiate NON-triggerable particle
		GameObject lingerer = Instantiate(gameObject, transform.position, transform.rotation, lingeringParent.transform);
		
		//prevent feedback loop
		lingerer.GetComponent<Collider2D>().isTrigger = false;
		lingerer.GetComponent<Rigidbody2D>().simulated = false;//isKinematic?

		SonarParticleController pc = lingerer.GetComponent<SonarParticleController>();
		//everything else should be the same, e.g. faderT (the most important)
		pc.velocity = Vector3.zero;
		pc.lingerLaying = false;

		//this could use.... tweaking
		pc.timeToFade = (timeToFade - faderT) * lingerRate;
		pc.faderT = 0;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag("SonarParticle") && !other.CompareTag("Player")) {
			lingerLaying = true;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (!other.CompareTag("SonarParticle") && !other.CompareTag("Player")) {
			lingerLaying = false;
		}
	}
}
