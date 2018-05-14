using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPFling : MonoBehaviour {

	Rigidbody2D rBody;
	public float upSpeed;
	public float dirSpeed;
	public GameObject player;
	SpriteRenderer sprite;
	BoxCollider2D box;
	private GameObject struckEnemy;

	// Use this for initialization
	void Start () {
		rBody = GetComponent<Rigidbody2D>();
		sprite = GetComponent<SpriteRenderer>();
		box = GetComponent<BoxCollider2D>();
		player = GameObject.Find("Player");
		StartCoroutine("disappear");
		if (player.GetComponent<Player>().dir == 1) {
			rBody.velocity = transform.up * upSpeed + transform.right * dirSpeed;
		} else {
			rBody.velocity = transform.up * upSpeed + transform.right * -dirSpeed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public IEnumerator disappear() {
		yield return new WaitForSeconds(3.0f);
		for (int i = 0; i < 4; i++) {
			//fade out here
			yield return new WaitForSeconds(0.50f);
		}
		Destroy(this.gameObject);
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.gameObject.tag == "EnemyMid") {
			rBody.velocity = (transform.up * 0.0f) + (transform.right * 0.0f);
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play();
			col.gameObject.GetComponent<CityMidBossAnimation>().life--;
			Debug.Log("hitmid");
			struckEnemy = col.gameObject;
		    StartCoroutine("hitFlash");
		    StartCoroutine("death");
		    rBody.isKinematic = true;
			box.enabled = false;
			sprite.enabled = false;	
   
		}
		if (col.gameObject.tag == "EnemyGas") {
			rBody.velocity = (transform.up * 0.0f) + (transform.right * 0.0f);
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play();
			col.gameObject.GetComponent<GasBoss>().life--;
			Debug.Log("hitgas");
			struckEnemy = col.gameObject;
		    StartCoroutine("hitFlash");
		    StartCoroutine("death");
		    rBody.isKinematic = true;
			box.enabled = false;
			sprite.enabled = false;	
   
		}
	}
	
	public IEnumerator hitFlash() {
		struckEnemy.GetComponent<SpriteRenderer>().enabled = false;
		yield return new WaitForSeconds(0.10f);
		struckEnemy.GetComponent<SpriteRenderer>().enabled = true;
	}
	
	public IEnumerator death() {
		yield return new WaitForSeconds(0.20f);
		Destroy(this.gameObject);
	}
	
}
