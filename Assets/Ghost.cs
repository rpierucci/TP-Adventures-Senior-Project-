using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

	[SerializeField]float YSpeed;
	[SerializeField]bool upward;
	[SerializeField]float rate;
	[SerializeField]float moveRange;
	[SerializeField]float startY;
	[SerializeField]float currY;
	[SerializeField]Transform shot;

	void Start () {
		upward = true;
		startY = transform.position.y;

	}
	
	void Update () {
		if (upward == true) {
			transform.position = new Vector2(transform.position.x, transform.position.y + YSpeed);
			YSpeed += rate;
		} else {
			transform.position = new Vector2(transform.position.x, transform.position.y - YSpeed);
			YSpeed -= rate;
		}
		currY = transform.position.y;
		if (upward == true && currY >= startY + moveRange) {
			upward = false;
		} else if (upward == false && currY <= startY) {
			upward = true;
		}


	}
}
