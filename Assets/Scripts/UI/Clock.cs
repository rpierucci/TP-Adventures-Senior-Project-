using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour {

	public Text clockText;
	private float startTime;
	public float t;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		t = Time.time - startTime;

		string minutes = ((int) t / 60).ToString("00");
		string seconds = (t % 60).ToString("00");

		clockText.text = minutes + ":" + seconds;
	}
}
