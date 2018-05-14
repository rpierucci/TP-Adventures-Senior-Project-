using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidBossSwitch : MonoBehaviour {
	
	GameObject block;
	GameObject cameraScript;
	public bool bossdead;
	
	// Use this for initialization
	void Start () {
		bossdead = false;
		block = GameObject.Find("EnemyHider");
		cameraScript = GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		if (bossdead == true) {
			Debug.Log("foolisdead");
			cameraScript.GetComponent<CameraFollow>().minCameraPos.x = 0.4f;
			cameraScript.GetComponent<CameraFollow>().maxCameraPos.x = 134.4f;
		}
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		if (col.name == "Player" && bossdead == false) {
			Destroy(block);
			cameraScript.GetComponent<CameraFollow>().minCameraPos.x = cameraScript.GetComponent<CameraFollow>().maxCameraPos.x = 59.75f;
		}
	}
}
