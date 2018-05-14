using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NameInput : MonoBehaviour {
	// Use this for initialization

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)) {
			GameObject.Find("Record").GetComponent<savedData>().playerName = GameObject.Find("Text").GetComponent<Text>().text;
		    GameObject.Find("Record").GetComponent<savedData>().setRecord();
		    Destroy(GameObject.Find("Record"));
			SceneManager.LoadScene("menu");
		}
		
	}
}
