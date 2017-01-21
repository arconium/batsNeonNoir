using System.Collections;

using UnityEngine;

public class SonarWave : MonoBehaviour {

	public GameObject Wave_Source;
	public GameObject Sonar_Prefab;
	public float Wave_Forward_Force;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			GameObject Temporary_Particle_Handler;
			Temporary_Particle_Handler = Instantiate(Sonar_Prefab, Wave_Source.transform.position, Wave_Source.transform.rotation) as GameObject;

			Rigidbody2D Temporary_RigidBody;
			Temporary_RigidBody = Temporary_Particle_Handler.GetComponent<Rigidbody2D> ();

			Temporary_RigidBody.AddForce(transform.right * Wave_Forward_Force);

			Destroy(Temporary_Particle_Handler, 10.0f);
		}
		
	}
}