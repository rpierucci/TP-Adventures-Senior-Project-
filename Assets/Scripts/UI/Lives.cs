using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour {


	public Text liveText;
	private int lives;
	private GameObject levelmanager;
	public SpriteRenderer livesprite;
	public Sprite uisprite1;
	public Sprite uisprite2;
	public Sprite uisprite3;

	// Use this for initialization
	void Start () {
		levelmanager = GameObject.Find("LevelManager");
		lives = levelmanager.GetComponent<LevelManager>().lives - 1;
		livesprite = GameObject.Find("ui-lives").GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		lives = levelmanager.GetComponent<LevelManager>().lives - 1;
		liveText.text = lives.ToString();
		if (lives == 2) {
			livesprite.sprite = uisprite1;
		} else if (lives == 1) {
			livesprite.sprite = uisprite2;
		} else if (lives == 0) {
			livesprite.sprite = uisprite3;
		}
	}

}
