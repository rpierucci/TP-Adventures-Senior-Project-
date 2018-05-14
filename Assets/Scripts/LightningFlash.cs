using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningFlash : MonoBehaviour {

	bool flashBool;

	// Use this for initialization
	void Start () {
		flashBool = false;
		GetComponent<SpriteRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (flashBool == false) {
			flashBool = true;
			StartCoroutine("flash");
		}
	}
	
	public IEnumerator flash() {
		yield return new WaitForSeconds(Random.Range(4.0f, 7.0f));
		GetComponent<SpriteRenderer>().enabled = true;
		yield return new WaitForSeconds(0.1f);
		GetComponent<SpriteRenderer>().enabled = false;
		flashBool = false;
	}
}
