using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityMidBossAnimation : MonoBehaviour {
	
	private Animator anim;
	GameObject player;
	public GameObject bulletDown;
	public GameObject bulletLeft;
	public GameObject bulletRight;
	bool wait;
	public int life;
	

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y < this.transform.position.y && this.transform.position.y < 6.0f && wait == false) {
			if (player.transform.position.x < this.transform.position.x + 1.0f && player.transform.position.x > this.transform.position.x - 1.0f) {
				StartCoroutine("shootDown");
				anim.Play("CityTurdMidBossShootDown");
			} else if (player.transform.position.x > this.transform.position.x - 6.0f && player.transform.position.x < this.transform.position.x -1.0f) {
				StartCoroutine("shootLeft");
				anim.Play("CityTurdMidBossShootDown");
			} else if (player.transform.position.x > this.transform.position.x + 1.0f && player.transform.position.x < this.transform.position.x + 6.0f) {
				StartCoroutine("shootRight");
				anim.Play("CityTurdMidBossShootDown");
			} else {
				anim.Play("CityTurdMidAnim");
			}
		} 
		if (life == 0) {
			Destroy(this.gameObject);
		}
	}
	
	public IEnumerator shootDown() {		
		Instantiate(bulletDown, new Vector3(transform.position.x, transform.position.y +1.0f, transform.position.z), transform.rotation);
		wait = true;
		yield return new WaitForSeconds(3.00f);
		wait = false;
	}
	
	public IEnumerator shootLeft() {		
		Instantiate(bulletLeft, new Vector3(transform.position.x, transform.position.y +1.0f, transform.position.z), transform.rotation);
		wait = true;
		yield return new WaitForSeconds(3.00f);
		wait = false;
	}
	
	public IEnumerator shootRight() {		
		Instantiate(bulletRight, new Vector3(transform.position.x, transform.position.y +1.0f, transform.position.z), transform.rotation);
		wait = true;
		yield return new WaitForSeconds(3.00f);
		wait = false;
	}
	
	public void OnDestroy() {
		GameObject.Find("Score").GetComponent<points>().totalScore += 500;
		GameObject.Find("MidBossSwitch").GetComponent<MidBossSwitch>().bossdead = true;
	}
	
	
}
