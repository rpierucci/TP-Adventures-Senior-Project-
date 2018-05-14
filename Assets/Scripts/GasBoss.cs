using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasBoss : MonoBehaviour {

	private Rigidbody2D rb2d;
	private bool init;
	private bool step2;
	private bool fight;
	private Vector3 startPos;
	private SpriteRenderer sprite;
	private SpriteRenderer[] eyes;
	private bool timeStart;
	private bool enemySpawned;
	private float startTime;
	public int life;

	public GameObject enemy;


	public float speed = 100000;
	public float xScale = 10;
	public float yScale = 1;

	void Start () {
		timeStart = false;
		enemySpawned = false;
		life = 3;
		eyes = GetComponentsInChildren<SpriteRenderer>();
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		rb2d.AddForce(transform.up * 1000.0f);
		init = step2 = false;
		sprite = gameObject.GetComponent<SpriteRenderer>();
	}
	
	void Update () {
		if (transform.position.y >= 16.0f && init == false) {
			init = true;
			transform.position = new Vector2(96.0f, 16.0f);
			rb2d.velocity = Vector2.zero;
			rb2d.AddForce(transform.up * -300.0f);
			step2 = true;
		}
		if (step2 == true) {
			if (transform.position.y <= 8.0f) {
				rb2d.velocity = Vector2.zero;
				step2 = false;
				StartCoroutine("fadeOut");
				startPos = transform.position;
			}
		}
		if (fight == true) {
			if (timeStart == false) {
				startTime = Time.time;
				timeStart = true;
			}
			if (Time.time - startTime >= 3.0f) {
				StartCoroutine("Attack");
				StartCoroutine("fadeOut");
			} else {	
				transform.position = startPos + (Vector3.right * Mathf.Sin(Time.timeSinceLevelLoad/2*speed)*xScale - Vector3.up * Mathf.Sin(Time.timeSinceLevelLoad * speed)*yScale);
				enemySpawned = false;
			}
		}
		if (life == 0) {
			Destroy(this.gameObject);
		}
	}

	public void OnDestroy() {
		GameObject.Find("Main Camera").GetComponent<CameraFollow>().maxCameraPos[0] = 134.5f;
	}

	public IEnumerator Attack() {
		if (enemySpawned == false) {
			 if(GameObject.FindGameObjectsWithTag("BasicEnemy").Length > 0) {
			 } else {
				Instantiate(enemy, transform.position, transform.rotation);
				enemySpawned = true;
			}
		}
		yield return new WaitForSeconds(2.0f);
		timeStart = false;
	}
	
	public IEnumerator fadeOut() {
		foreach (SpriteRenderer eye in eyes) {
			eye.color = new Color(1f, 1f, 1f, 0.8f);
		}
		sprite.color = new Color(1f, 1f, 1f, 0.8f);
		yield return new WaitForSeconds(0.2f);
		foreach (SpriteRenderer eye in eyes) {
			eye.color = new Color(1f, 1f, 1f, 0.6f);
		}
		sprite.color = new Color(1f, 1f, 1f, 0.6f);
		yield return new WaitForSeconds(0.2f);
		foreach (SpriteRenderer eye in eyes) {
			eye.color = new Color(1f, 1f, 1f, 0.4f);
		}
		sprite.color = new Color(1f, 1f, 1f, 0.4f);
		yield return new WaitForSeconds(0.2f);
		foreach (SpriteRenderer eye in eyes) {
			eye.color = new Color(1f, 1f, 1f, 0.2f);
		}
		sprite.color = new Color(1f, 1f, 1f, 0.2f);
		yield return new WaitForSeconds(0.2f);
		foreach (SpriteRenderer eye in eyes) {
			eye.color = new Color(1f, 1f, 1f, 0.0f);
		}
		sprite.color = new Color(1f, 1f, 1f, 0.0f);
		fight = true;
		yield return new WaitForSeconds(1.5f);
		StartCoroutine("fadeIn");
	}
	
	public IEnumerator fadeIn() {
		foreach (SpriteRenderer eye in eyes) {
			eye.color = new Color(1f, 1f, 1f, 0.2f);
		}
		sprite.color = new Color(1f, 1f, 1f, 0.2f);
		yield return new WaitForSeconds(0.2f);
		foreach (SpriteRenderer eye in eyes) {
			eye.color = new Color(1f, 1f, 1f, 0.4f);
		}
		sprite.color = new Color(1f, 1f, 1f, 0.4f);
		yield return new WaitForSeconds(0.2f);
		foreach (SpriteRenderer eye in eyes) {
			eye.color = new Color(1f, 1f, 1f, 0.6f);
		}
		sprite.color = new Color(1f, 1f, 1f, 0.6f);
		yield return new WaitForSeconds(0.2f);
		foreach (SpriteRenderer eye in eyes) {
			eye.color = new Color(1f, 1f, 1f, 0.8f);
		}
		sprite.color = new Color(1f, 1f, 1f, 0.8f);
		yield return new WaitForSeconds(0.2f);
		foreach (SpriteRenderer eye in eyes) {
			eye.color = new Color(1f, 1f, 1f, 1.0f);
		}
		sprite.color = new Color(1f, 1f, 1f, 1.0f);
		yield return new WaitForSeconds(0.2f);

	}
	
}
