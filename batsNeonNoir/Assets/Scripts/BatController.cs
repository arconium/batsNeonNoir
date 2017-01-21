using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour {

    public float batVelX;
    public float batVelY;
    public float friction = 0.1f;
    public float swoopAmplitude = 0.5f;
    public float swoopFrequency = 8;
    public float swoopMin = 0.2f;
    public float batSpeed = 0.7f;
    public GameObject sonarWavePrefab;
    bool forward = true;

    public int playerHealth = 3;

    void Start () {
        SpawnSonar(1, new Vector3(1,-1,0), 60, 60, 5, 45, new Color(1, 1, 1, 1));
        
	}    

    void SpawnSonar(
        float speed, 
        Vector3 batToMouse,
        float angularWaveWidth,
        int particleResolution,
        float timeToFadeOut,
        float particleSpotlightAngle,
        Color color) {
            GameObject newWave = Instantiate(sonarWavePrefab, gameObject.transform.position, Quaternion.identity) as GameObject;
			SonarWaveController wc = newWave.GetComponent<SonarWaveController>();
            wc.speed = speed;
            wc.startAngle = Vector3.Angle(Vector3.right, batToMouse) - angularWaveWidth/2;
            wc.endAngle = Vector3.Angle(Vector3.right, batToMouse) + angularWaveWidth/2;
            wc.speed = speed;
            wc.particleSpotlightAngle = particleSpotlightAngle;
            wc.particleResolution = particleResolution;
            wc.color = color;
    }

    void FixedUpdate() {

        // Bat Movement and "Swoop" oscillation
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        float sineValue = Mathf.Sin(swoopFrequency * Time.time);
        float amplitudeScale = Mathf.Abs(Mathf.Cos(Mathf.Atan2(batVelY, batVelX))) * (1 - swoopMin) + swoopMin;
        if (horiz == 0 && vert == 0)
        {
            amplitudeScale = 1;
        }
        float oscillation = swoopAmplitude * amplitudeScale * sineValue;

        batVelX += horiz * batSpeed;
        batVelX *= (1 - friction);
        batVelY += vert * batSpeed;
        batVelY *= (1 - friction);

        batVelY += oscillation;

        if (forward && batVelX < 0)
        {
            forward = false;
            gameObject.transform.forward *= -1;
        }
        else if (!forward && batVelX > 0)
        {
            forward = true;
            gameObject.transform.forward *= -1;
        }

        gameObject.transform.position += new Vector3(batVelX * Time.deltaTime, batVelY * Time.deltaTime, 0);
   }

    

}
