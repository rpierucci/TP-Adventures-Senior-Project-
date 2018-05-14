using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidBossBulletRight : MonoBehaviour {

	private Animator anim;
	public float yOffset;
	public float xOffset;
	public Sprite hitGround;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		anim = GetComponent<Animator>();
		Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.Find("cityTurdMidBoss").GetComponent<Collider2D>(), true);
		Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), GameObject.Find("girder (3)").GetComponent<Collider2D>(), true);
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 position = transform.position;
		position.y -= yOffset;
		position.x += xOffset;
		transform.position = position;
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.name == "BulletStopR") {
			StartCoroutine("ground");
			StartCoroutine("checkPoo");
		}	
	}
	
	public IEnumerator ground() {
		anim.SetBool("HitGround", true);
		yOffset = 0;
		xOffset = 0;
		GetComponent<SpriteRenderer>().sprite = hitGround;
		yield return new WaitForSeconds(1.00f);
		anim.enabled = false;
		GetComponent<Collider2D>().enabled = false;
		Color temp = GetComponent<SpriteRenderer>().color;
		for (int i = 0; i < 5; i++) {
			temp.a -= 0.2f;
			GetComponent<SpriteRenderer>().color = temp;
			yield return new WaitForSeconds(0.25f);
			if (player.GetComponent<Player>().rolling == true && player.transform.position.x < transform.position.x + 1.0f && player.transform.position.x > transform.position.x - 1.0f) {
				Debug.Log("rolling on poo");
			}
		}
		Destroy(this.gameObject);
	}
	
	public IEnumerator checkPoo() {
		for (int i = 0; i < 25; i++) {
			if (player.GetComponent<Player>().rolling == true && player.transform.position.x < transform.position.x + 1.0f && player.transform.position.x > transform.position.x - 1.0f) {
				player.GetComponent<Player>().hasPoo = true;
			}
			yield return new WaitForSeconds(0.10f);
		}
	}
}
