using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {

	public float levelEndDelay = 3.0f;
	public GameObject SplashParticle;
	private Player player;
	AudioSource splash;
	bool loadingEnd;
	
	// Use this for initialization
	void Start () {
		loadingEnd = false;
		player = FindObjectOfType<Player>();
		splash = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			AsyncOperation async = Application.LoadLevelAsync("practice_level");
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			AsyncOperation async = Application.LoadLevelAsync("citylevel");
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			AsyncOperation async = Application.LoadLevelAsync("cemeterylevel");
		}
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		StartCoroutine("waitfor");
		if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("practice_level")) {
			GameObject.Find("Record").GetComponent<savedData>().setTime(1);
		} else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("citylevel")) {
			GameObject.Find("Record").GetComponent<savedData>().setTime(2);
		} else if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("cemeterylevel")) {
			GameObject.Find("Record").GetComponent<savedData>().setTime(3);
		}
		splash.Play();
	}
	
	public IEnumerator waitfor() {
		Instantiate(SplashParticle, player.transform.position, player.transform.rotation);
		yield return new WaitForSeconds(2.0f);
		GameObject.Find("FadeOut").GetComponent<FadeOut>().fadeOut();
		yield return new WaitForSeconds(1.0f);
		if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("practice_level") && loadingEnd == false) {
			AsyncOperation async = Application.LoadLevelAsync("citylevel");
			loadingEnd = true;
			yield return async;
		}
		if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("citylevel") && loadingEnd == false) {
			AsyncOperation async = Application.LoadLevelAsync("cemeterylevel");
			loadingEnd = true;
			yield return async;
		}
		if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("cemeterylevel") && loadingEnd == false) {
			AsyncOperation async = Application.LoadLevelAsync("menu");
			loadingEnd = true;
			yield return async;
		}
	}
}
