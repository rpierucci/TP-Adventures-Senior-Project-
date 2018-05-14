using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditCrawl : MonoBehaviour {
	
	
	public float yOffset;
	public float xOffset;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector2 position = transform.position;
		position.y -= yOffset;
		position.x -= xOffset;
		transform.position = position;
	}
}
