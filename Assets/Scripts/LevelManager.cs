using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;
	public int lives = 3;
	private Player player;
	
	public GameObject deathParticle;
	public GameObject respawnParticle;
	public GameObject Record;
	
	public float respawnDelay;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player>();
		Record = GameObject.Find("Record");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void RespawnPlayer() 
	{
		StartCoroutine("RespawnPlayerCo");
	}
	
	public IEnumerator RespawnPlayerCo()
	{
		Instantiate(deathParticle, player.transform.position, player.transform.rotation);
		player.enabled = false;
		player.GetComponent<Renderer>().enabled = false;
		player.GetComponent<CircleCollider2D>().enabled = false;
		player.GetComponent<Player>().hasPoo = false;
		Debug.Log("Player Respawn");
		yield return new WaitForSeconds(respawnDelay);
		lives--;
		if (lives != 0) {
			player.transform.position = currentCheckpoint.transform.position;
			player.enabled = true;
			player.GetComponent<Renderer>().enabled = true;
			player.GetComponent<CircleCollider2D>().enabled = true;
			Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
		} else {
			SceneManager.LoadScene ("menu");
			//menu code here
		}
	}
	
}
