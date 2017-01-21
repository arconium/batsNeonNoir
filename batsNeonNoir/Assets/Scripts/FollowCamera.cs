using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public float cameraMoveSpeed = 3.0f;
    public float deadZoneX = 3f;
    public float deadZoneY = 3f;
    public GameObject player;
    public Camera c;

    void Start () {
		
	}

	void Update () {
        /*Vector3 playerpos = c.WorldToScreenPoint(player.transform.position);
        Vector3 camerapos = c.WorldToScreenPoint(gameObject.transform.position);
        if (playerpos.x > camerapos.x + ((Screen.width / 2) * (1 - deadZoneX)))
        {
            //BatController bc = player.GetComponent<BatController>();
            gameObject.transform.position += new Vector3(-(gameObject.transform.position.x - player.transform.position.x) / 10, 0, 0);
        }
        else
        {
            //gameObject.transform.position = new Vector3(player.transform.position.x, 0, -10);
        }*/
        float dx = Mathf.Abs(player.transform.position.x - gameObject.transform.position.x);
        float dy = Mathf.Abs(player.transform.position.y - gameObject.transform.position.y);
        if (dx > deadZoneX || dy > deadZoneY)
        {
            Vector3 thing = player.transform.position;
            thing.z = -10;
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, thing, cameraMoveSpeed * Time.deltaTime);
        }
	}
}
