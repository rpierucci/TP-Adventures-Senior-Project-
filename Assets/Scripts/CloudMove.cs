using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 position = transform.position;
		if (position.x <= -14.0f) {
			position.x += 88.0f;
		}
		position.x -= 0.03f;
		transform.position = position;
	}
}
