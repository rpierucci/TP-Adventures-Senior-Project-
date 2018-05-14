using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurdHopper : MonoBehaviour {

	Rigidbody2D rBody;
	Animator anim;
	public float upSpeed;
	public float playerRange;
	public float jumpRange;
	bool jumping;
	bool onground;
	bool done;
	public int score = 100;
	public Player player;
	public LevelManager levelManager;

	// Use this for initialization
	void Start () {		
		levelManager = FindObjectOfType<LevelManager>();
		player = FindObjectOfType<Player>();
		done = true;
		onground = true;
		jumping = false;
		rBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		anim.SetBool("onGround", onground);
		anim.SetBool("Jumping", jumping);
		
		if (jumping == false && onground == true && done == true) {
			StartCoroutine("jump");
			jumping = true;
		}
	}
	
	public IEnumerator jump() {
		done = false;
		onground = false;
		Debug.DrawLine (new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), 
			new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));
		if (player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + playerRange) {
			rBody.velocity = transform.up * upSpeed;
			yield return new WaitForSeconds (.35f);
			rBody.velocity = transform.right * jumpRange;
			yield return new WaitForSeconds (1.0f);
			jumping = false;
			onground = true;
			yield return new WaitForSeconds (1.5f);
			done = true;
		} else if (player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - playerRange) {
			rBody.velocity = transform.up * upSpeed;
			yield return new WaitForSeconds (.35f);
			rBody.velocity = transform.right * -jumpRange;
			yield return new WaitForSeconds (1.0f);
			jumping = false;
			onground = true;
			yield return new WaitForSeconds (1.5f);
			done = true;
		} else {
			rBody.velocity = transform.up * upSpeed;
			yield return new WaitForSeconds (1.0f);
			jumping = false;
			onground = true;
			yield return new WaitForSeconds (1.5f);
			done = true;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "EnemyWall") {
			rBody.velocity *= -1;
			//enemy.transform.localScale *= -1;
		}
		if (col.gameObject.tag == "Player") {
			levelManager.RespawnPlayer();
		}
	}
	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.tag == "EnemyWall") {
			rBody.velocity *= -1;
			//enemy.transform.localScale.x *= -1;
		}
		if (col.gameObject.tag == "Player") {
			levelManager.RespawnPlayer();
		}	
	}
}
