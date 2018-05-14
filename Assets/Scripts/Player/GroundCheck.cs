using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

	private Player player;
	
	void Start() {
		player = gameObject.GetComponentInParent<Player>();
	}
	
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag != "SideWall" && col.gameObject.tag != "Checkpoint" && col.gameObject.tag != "EnemyWall") {
			player.grounded = true;
		}
	}
	
 	void OnCollisionStay2D(Collision2D col) {
		if (col.gameObject.tag != "SideWall" && col.gameObject.tag != "Checkpoint" && col.gameObject.tag != "EnemyWall") {
			player.grounded = true;
		}
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag != "SideWall" && col.gameObject.tag != "Checkpoint" && col.gameObject.tag != "EnemyWall") {
			player.grounded = true;
		}
	}
	
 	void OnTriggerStay2D(Collider2D col) {
		if (col.gameObject.tag != "SideWall" && col.gameObject.tag != "Checkpoint" && col.gameObject.tag != "EnemyWall") {
			player.grounded = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D col) {
		player.grounded = false;
	}
	
}
