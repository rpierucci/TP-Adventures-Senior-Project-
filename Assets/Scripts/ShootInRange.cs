using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInRange : MonoBehaviour {
	public float playerRange;
	public GameObject enemypoop;
	public Player player;
	public Transform launchpoop;
	public float waittime;
	private float shotcount;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player>();
		shotcount = waittime;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine (new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), 
			new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));
		shotcount -= Time.deltaTime;
		if(player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + playerRange && shotcount < 0) {
			Instantiate (enemypoop, launchpoop.position, launchpoop.rotation);
			shotcount = waittime;
		}
		if( player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - playerRange && shotcount < 0) {
			Instantiate (enemypoop, launchpoop.position, launchpoop.rotation);
			shotcount = waittime;
		}
	}
}
