using UnityEngine;
using System.Collections;

public class PlayerCountHandler : MonoBehaviour {
	public int numberOfPlayers;

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
	}
}
