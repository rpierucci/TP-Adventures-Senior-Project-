using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {
	public float speed;
	public Player player;
	public float rotatespeed;
	public int damagedone;
	private Rigidbody2D temp;
	public LevelManager levelManager;
	public GameObject impact;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		player = FindObjectOfType<Player>();
		temp = GetComponent<Rigidbody2D>();
		if (player.transform.position.x < transform.position.x) {
			speed = -speed;
			rotatespeed = -rotatespeed;
		}
	}

	// Update is called once per frame
	void Update () {
		temp.velocity = new Vector2 (speed, temp.velocity.y);
		temp.angularVelocity = rotatespeed;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "Player") {
			levelManager.RespawnPlayer();
			Instantiate (impact, transform.position, transform.rotation);
			Destroy (gameObject);
		}

	}
}
