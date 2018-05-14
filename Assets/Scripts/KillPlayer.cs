using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

	public LevelManager levelManager;
	public GameObject pooParticle;
	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if(other.name == "Player") 
		{
			if (this.gameObject.tag != "Pit") {
				if(other.transform.position.y > this.transform.position.y + 0.4f) {
					if (this.gameObject.tag == "Projectile") {
						return;
					}
					Instantiate(pooParticle, other.transform.position, other.transform.rotation);
					other.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300f);
					Destroy(this.gameObject);
					return;
				}
			}	
			levelManager.RespawnPlayer();
		}
	}
}
