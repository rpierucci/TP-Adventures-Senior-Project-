using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {

	private GameObject fadeScreen;
	private SpriteRenderer blackScreen;
	private SpriteRenderer loadingText;

	// Use this for initialization
	void Start () {
		fadeScreen = GameObject.Find("FadeOut");
		loadingText = GameObject.Find("LoadingText").GetComponent<SpriteRenderer>();
		blackScreen = GameObject.Find("BlackScreen").GetComponent<SpriteRenderer>();
		loadingText.color = new Color (1.0f, 1.0f, 1.0f, 0.0f);
		blackScreen.color = new Color (1.0f, 1.0f, 1.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void fadeOut () {
		StartCoroutine("FadeAnim");
	}
	
	public IEnumerator FadeAnim() {
		yield return new WaitForSeconds(0.01f);
		loadingText.color = new Color (1.0f, 1.0f, 1.0f, 0.2f);
		blackScreen.color = new Color (1.0f, 1.0f, 1.0f, 0.2f);
		yield return new WaitForSeconds(0.01f);
		loadingText.color = new Color (1.0f, 1.0f, 1.0f, 0.4f);
		blackScreen.color = new Color (1.0f, 1.0f, 1.0f, 0.4f);
		yield return new WaitForSeconds(0.01f);
		loadingText.color = new Color (1.0f, 1.0f, 1.0f, 0.6f);
		blackScreen.color = new Color (1.0f, 1.0f, 1.0f, 0.6f);
		yield return new WaitForSeconds(0.01f);
		loadingText.color = new Color (1.0f, 1.0f, 1.0f, 0.8f);
		blackScreen.color = new Color (1.0f, 1.0f, 1.0f, 0.8f);
		yield return new WaitForSeconds(0.01f);
		loadingText.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
		blackScreen.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
	}
}
