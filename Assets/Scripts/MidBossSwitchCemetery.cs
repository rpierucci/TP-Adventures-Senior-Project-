using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidBossSwitchCemetery : MonoBehaviour {

	private GameObject tombstone;
	private GameObject camera;
	public	GameObject midboss;
	private bool tombstoneErect;

	// Use this for initialization
	void Start () {
		tombstone = GameObject.Find("TombStoneMidBoss");
		camera = GameObject.Find("Main Camera");
		tombstoneErect = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player" && tombstoneErect == true) {
			StartCoroutine("midbossStart");
			tombstoneErect = false;
		}
		
		
	}
	
	public IEnumerator midbossStart() {
		camera.GetComponent<CameraFollow>().minCameraPos.x = 96.14f;
		camera.GetComponent<CameraFollow>().maxCameraPos.x = 96.14f;
		for (int i = 0; i < 5; i++) {
			tombstone.transform.position = new Vector2(tombstone.transform.position.x + 0.2f, tombstone.transform.position.y);
			yield return new WaitForSeconds(0.2f);
			tombstone.transform.position = new Vector2(tombstone.transform.position.x - 0.2f, tombstone.transform.position.y);
			yield return new WaitForSeconds(0.01f);
			tombstone.transform.position = new Vector2(tombstone.transform.position.x - 0.2f, tombstone.transform.position.y);
			yield return new WaitForSeconds(0.2f);
			tombstone.transform.position = new Vector2(tombstone.transform.position.x + 0.2f, tombstone.transform.position.y);
			yield return new WaitForSeconds(0.01f);
		}
		for (int i = 0; i < 5; i++) {
			tombstone.transform.position = new Vector2(tombstone.transform.position.x + 0.2f, tombstone.transform.position.y);
			yield return new WaitForSeconds(0.1f);
			tombstone.transform.position = new Vector2(tombstone.transform.position.x - 0.2f, tombstone.transform.position.y);
			yield return new WaitForSeconds(0.01f);
			tombstone.transform.position = new Vector2(tombstone.transform.position.x - 0.2f, tombstone.transform.position.y);
			yield return new WaitForSeconds(0.1f);
			tombstone.transform.position = new Vector2(tombstone.transform.position.x + 0.2f, tombstone.transform.position.y);
			yield return new WaitForSeconds(0.01f);
		}
		for (int i = 0; i < 5; i++) {
			tombstone.transform.position = new Vector2(tombstone.transform.position.x + 0.2f, tombstone.transform.position.y);
			yield return new WaitForSeconds(0.001f);
			tombstone.transform.position = new Vector2(tombstone.transform.position.x - 0.2f, tombstone.transform.position.y);
			yield return new WaitForSeconds(0.001f);
			tombstone.transform.position = new Vector2(tombstone.transform.position.x - 0.2f, tombstone.transform.position.y);
			yield return new WaitForSeconds(0.001f);
			tombstone.transform.position = new Vector2(tombstone.transform.position.x + 0.2f, tombstone.transform.position.y);
			yield return new WaitForSeconds(0.001f);
		}
		Instantiate(midboss, tombstone.transform.position, tombstone.transform.rotation);
		Destroy(tombstone);
	}
}
