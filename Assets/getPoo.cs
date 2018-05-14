using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getPoo : MonoBehaviour {

	void OnDestroy() {
		GameObject.Find("Player").GetComponent<Player>().hasPoo=true;
	}
}
