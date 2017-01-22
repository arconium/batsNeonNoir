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
    public List<ColorOpt> colorOpts;
    [System.SerializableAttribute]
    public class ColorOpt {
        public Color color;
        public float speed;
        public float timeToFadeOut;
        public float spotlightAngle;
        public int particleResolution;
        public float angularWaveWidth;
        public ColorOpt(Color _color, float _speed, float _timeToFadeOut, float _spotlightAngle, int _particleResolution, float _angularWaveWidth) {
            color = _color;
            speed = _speed;
            timeToFadeOut = _timeToFadeOut;
            spotlightAngle = _spotlightAngle;
            particleResolution = _particleResolution;
            angularWaveWidth = _angularWaveWidth;
        }
    }
    bool forward = true;

    public int playerHealth = 3;
    public int score = 0;

    // public AudioClip batAudioClip;
    void Start () {
        
        //these are just guesses/defaults for a wave settings
        /*colorOpts.Add(new ColorOpt(
            new Color(1,0,0,1),
            1,
            2,
            60,
            60,
            60
        ));
        colorOpts.Add(new ColorOpt(
            new Color(0,1,0,1),
            2,
            2,
            60,
            60,
            60
        ));
        colorOpts.Add(new ColorOpt(
            new Color(0,0,1,1),
            3,
            2,
            60,
            60,
            60
        ));*/
	}    

    void Update() {
        if (Input.GetMouseButtonDown(0)) {

            // Play bat chirp SFX
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();

			//copy paste ;_;
			Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 pos = transform.position;
			Vector3 batToMouse = mouse - pos;
			batToMouse.z = transform.position.z;

			SpawnSonar(colorOpts[GUIController.colorIndex].speed, 
				batToMouse, 
				colorOpts[GUIController.colorIndex].angularWaveWidth, 
				colorOpts[GUIController.colorIndex].particleResolution, 
				colorOpts[GUIController.colorIndex].timeToFadeOut, 
				colorOpts[GUIController.colorIndex].spotlightAngle, 
				colorOpts[GUIController.colorIndex].color
			);

        }
        if (Input.GetMouseButtonDown(1)) {
			GUIController.colorIndex = (GUIController.colorIndex + 1) % colorOpts.Count;
        }
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
            Debug.Log(Mathf.Atan2(batToMouse.y, batToMouse.x));
            wc.startAngle = Mathf.Atan2(batToMouse.y, batToMouse.x)*180f/Mathf.PI - angularWaveWidth/2;
            wc.endAngle = Mathf.Atan2(batToMouse.y, batToMouse.x)*180f/Mathf.PI  + angularWaveWidth/2;
            wc.speed = speed;
            wc.timeToFadeOut = timeToFadeOut;
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
