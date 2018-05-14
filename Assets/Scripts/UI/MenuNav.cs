using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNav : MonoBehaviour {
	
	int index = 0;
	public int optionCount = 3;
	public float yOffset = 1f;
	AudioSource audio;
	bool selected;
	
	// Use this for initialization
	void Start () {
		selected = false;
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		//down
		if (Input.GetAxis ("Vertical") < 0.0f && selected == false) {
			if (index < optionCount - 1) {
				audio.Play();
				index++;
				Vector2 position = transform.position;
				position.y -= yOffset;
				transform.position = position;
				Input.ResetInputAxes();
			}
		}
		
		//up
		if (Input.GetAxis ("Vertical") > 0.0f && selected == false) {
			if (index > 0) { 
				audio.Play();
				index--;
				Vector2 position = transform.position;
				position.y += yOffset;
				transform.position = position;
				Input.ResetInputAxes();
			}
		}
		
		if (Input.GetButton("Jump") && selected == false) {
			selected = true;
			StartCoroutine("loadLevel");
		}
	}
	
	public IEnumerator loadLevel() {
		if (index == 0) {
			GameObject.Find("FadeOut").GetComponent<FadeOut>().fadeOut();
			yield return new WaitForSeconds(1.0f);
			AsyncOperation async = Application.LoadLevelAsync("practice_level");
			yield return async;
		} else if (index == 1) {
			Application.Quit();
		} else if (index == 2) {
			GameObject.Find("FadeOut").GetComponent<FadeOut>().fadeOut();
			yield return new WaitForSeconds(1.0f);
			AsyncOperation async = Application.LoadLevelAsync("credits");
			yield return async;
		}
	}
}
