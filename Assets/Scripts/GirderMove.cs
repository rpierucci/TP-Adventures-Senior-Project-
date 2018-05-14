using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirderMove : MonoBehaviour {

	float start;
	float yOffset;
	Vector2 startpos;
	bool up;

	// Use this for initialization
	void Start () {
		up = true;
		//startpos = transform.position;
		start = 0;
		yOffset = 0.01f;
	}
	
	// Update is called once per frame
	void Update () {
		float savedTime;
		savedTime = Time.time;
		if(Time.time - savedTime <= 2) {
			Debug.Log("up true");
			up = true;
		} else {
			up = false;
			Debug.Log("up false");
		}
		
		if (up == true) {
			Vector2 position = transform.position;
				position.y += yOffset;
				transform.position = position;
			} else {
				Vector2 position = transform.position;
				position.y -= yOffset;
				transform.position = position;
			}
	}
}
