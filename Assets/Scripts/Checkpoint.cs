using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
	
	public LevelManager levelManager;
	
	private Player player;
	
	public GameObject respawnParticle;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.name == "Player") 
		{
			if (levelManager.currentCheckpoint != gameObject) {
				levelManager.currentCheckpoint = gameObject;
				Instantiate(respawnParticle, player.transform.position, player.transform.rotation);
				Debug.Log("Activated Checkpoint " + transform.position);
			}
		}
	}
}
