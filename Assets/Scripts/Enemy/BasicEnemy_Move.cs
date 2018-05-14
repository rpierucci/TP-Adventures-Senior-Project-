using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy_Move : MonoBehaviour {

	public float speed;
	Rigidbody2D enemy;
	public float maxSpeed;
	Vector2 move = new Vector2(1,0);

	// Use this for initialization
	void Start () {
		enemy = GetComponent<Rigidbody2D>();
	}
	

	
	
	// Update is called once per frame
	void Update () {
		enemy.position += move * speed;
		enemy.velocity = (enemy.velocity.x > maxSpeed) ? new Vector2(maxSpeed, enemy.velocity.y) : enemy.velocity;
		enemy.velocity = (enemy.velocity.x < -maxSpeed) ? new Vector2(-maxSpeed, enemy.velocity.y) : enemy.velocity;
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "EnemyWall") {
			move.x *= -1;
			//enemy.transform.localScale *= -1;
		}
			
	}
	
	void OnCollisionStay2D(Collision2D col)
	{
		if (col.gameObject.tag == "EnemyWall") {
			move.x *= -1;
			//enemy.transform.localScale.x *= -1;

		}
		
	}
		
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag == "EnemyWall") {
			move.x *= -1;
			//enemy.transform.localScale.x *= -1;

		}
		if(col.tag == "Player") {
			GameObject.Find("Score").GetComponent<points>().totalScore += 100;;
			Destroy(this.gameObject);
		}
		
	}
}
