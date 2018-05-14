using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class savedData : MonoBehaviour {

	private string fname;
	private float ftime = 9999.99f;
	private string lname;
	private float ltime = -9999.99f;

	public string playerName;


	private float l01;
	private float l02;
	private float l03;

	// Use this for initialization
	void Start () {
		l01 = 0.0f;
		l02 = 0.0f;
		l03 = 0.0f;
	}
	
	void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		showRecords();
	}
	
	public void setTime(int level) {
		if (level == 1) {
			l01 = GameObject.Find("BackgroundCamera").GetComponent<Clock>().t;
			Debug.Log(l01);
		}
		if (level == 2) {
			l01 = GameObject.Find("BackgroundCamera").GetComponent<Clock>().t;
			Debug.Log(l02);
		}
		if (level == 3) {
			l01 = GameObject.Find("BackgroundCamera").GetComponent<Clock>().t;
			Debug.Log(l03);
		}
	}
	
	public void setRecord() {
		string path = "Assets/records.txt";
		if (File.Exists(path)) {
			StreamWriter writer = new StreamWriter(path, true);
			writer.WriteLine(playerName + " " + l01 + " " + l02 + " " + l03);
			writer.Close();
			showRecords();
		}
		
	}
	
	private void parseData(string data) {
		string[] Array = data.Split(" " [0]);
		float dtime = (float.Parse(Array[1]) + float.Parse(Array[2]) + float.Parse(Array[3])) / 3;
		if (dtime <= ftime) {
			ftime = dtime;
			fname = Array[0];
		}
		if (dtime >= ltime) {
			ltime = dtime;
			lname = Array[0];
		}
	}
	
	public void showRecords(){
		string path = "Assets/records.txt";
		if (File.Exists(path)) {
			StreamReader reader = new StreamReader(path);
			for (int i=0; i<5; i++) {
				string data = reader.ReadLine();
				parseData(data);
			}
			reader.Close();
			Debug.Log(fname);
			Debug.Log(lname);
		}
	}
}
