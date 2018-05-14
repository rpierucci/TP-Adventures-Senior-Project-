using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour {

	public int totalScore;
	public GameObject player;


	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(totalScore);
	}
	
	
	
	
}
