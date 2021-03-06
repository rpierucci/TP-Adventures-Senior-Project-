using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float maxSpeed = 3;
	public float speed = 50f;
	public float jumpPower = 150f;
	public bool hasPoo;
	public GameObject tpfling;
	//0 = left, 1 = right;
	public int dir = 0;
	public GameObject points;

	public bool grounded;
	public bool rolling;
	public bool crouching;

	private Rigidbody2D rb2d;
	private GameObject wallprefab;
	private GameObject[] walls;
	private Animator anim;
	private SpriteRenderer sprite;
	private Color defaultColor;
	AudioSource jumpAudio;

	// Use this for initialization
	void Start () {
		points = GameObject.Find("Score");
		hasPoo = false;
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
		sprite = gameObject.GetComponent<SpriteRenderer>();
		defaultColor = sprite.color;
		if (walls == null)
			walls = GameObject.FindGameObjectsWithTag("EnemyWall");
		int i=0;
		foreach (GameObject wallprefab in walls){
			Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), walls[i].gameObject.GetComponent<Collider2D>(), true);
			i++;
		}
		jumpAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (hasPoo == true) {
			sprite.color = new Color32(89,48,1,255);
		} else {
			sprite.color = defaultColor;
		}
		anim.SetBool("Grounded", grounded);
		anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
		anim.SetBool ("isRolling", rolling);
		anim.SetBool ("isCrouching", crouching);

		if (Input.GetAxisRaw("Horizontal") < -0.1f) {
			if (Input.GetAxisRaw ("Vertical") < 0.0f) {
				dir = 0;
				crouching = true;
				rolling = true;
				transform.localScale = new Vector3 (-1, 1, 1);
			} else {
				dir = 0;
				crouching = false;
				transform.localScale = new Vector3 (-1, 1, 1);
				rolling = false;
			}
		}
		
		if (Input.GetAxisRaw("Horizontal") > 0.1f) {
			if (Input.GetAxisRaw("Vertical") < 0.0f) {
				dir = 1;
				crouching = true;
				rolling = true;
				transform.localScale = new Vector3(1,1,1);
			} else {
				dir = 1;
				crouching = false;
				rolling = false;
				transform.localScale = new Vector3(1, 1, 1);
			}
		}

		if (Input.GetAxisRaw ("Horizontal") == 0.0f) {
			if (Input.GetAxis ("Vertical") < 0.0f) {
				rolling = false;
				crouching = true;
			} else {
				crouching = false;
			}
		}

		if (Input.GetButtonDown("Jump") && grounded && rolling == false) {
			//space key
			rb2d.AddForce(Vector2.up * jumpPower);
			jumpAudio.Play();
		}
		
		if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("Fire3")) && !crouching && hasPoo) {
			Instantiate(tpfling, new Vector2(transform.position.x, transform.position.y + 0.5f), transform.rotation);
			hasPoo = false;
		}

	}

	void FixedUpdate() {

		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		rb2d.AddForce (Vector2.right * speed * h);

		if (rb2d.velocity.x > maxSpeed) {
			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		}

		if (rb2d.velocity.x < -maxSpeed) {
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		if(col.gameObject.tag == "EnemyWall") {
			Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), col.gameObject.GetComponent<Collider2D>(), true);
		}
		if(col.gameObject.tag == "HitPoint") {
			Debug.Log("hit");
		}
	}
	
	void OnCollisionStay2D (Collision2D col) {
		if(col.gameObject.tag == "EnemyWall") {
			Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), col.gameObject.GetComponent<Collider2D>(), true);
		}
		if(col.gameObject.tag == "HitPoint") {
			Debug.Log("hit");
		}
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if(col.gameObject.tag == "HitPoint") {
			Debug.Log("hit");
			rb2d.AddForce(Vector2.up * jumpPower);
			points.GetComponent<points>().totalScore += 100;
			Destroy(col.gameObject);
			Destroy(transform.parent.gameObject);  
			return;
		}
	}
}
