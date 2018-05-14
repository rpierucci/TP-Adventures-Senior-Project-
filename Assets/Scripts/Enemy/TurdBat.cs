using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurdBat : MonoBehaviour {

	Vector2 startpos, currentpos;
	public float yOffset;
	public float xOffset;
	public float moveDistance;
	public int score = 100;

	// Use this for initialization
	void Start () {
		startpos.x = transform.position.x;
		startpos.y = transform.position.y;
		currentpos.x = transform.position.x;
		currentpos.y = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 newPosition = transform.position;
		newPosition.y -= yOffset;
		newPosition.x -= xOffset;
		transform.position = newPosition;
		currentpos.y = transform.position.y;
		currentpos.x = transform.position.x;
		if (startpos.y - currentpos.y > moveDistance) {
			yOffset = -yOffset;
		} else if (startpos.y == currentpos.y) {
			yOffset = -yOffset;
		}
		if (startpos.x - currentpos.x > moveDistance) {
			xOffset = -xOffset;
		} else if (currentpos.x - startpos.x > moveDistance) {
			xOffset = -xOffset;
		}
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Player") {
			GameObject.Find("Score").GetComponent<points>().totalScore += 100;;
			Destroy(this.gameObject);
		}
		
	}
}
