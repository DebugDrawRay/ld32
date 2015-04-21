using UnityEngine;
using System.Collections;

public class PausingMaster : MonoBehaviour {

	public bool paused;
    public bool pauseGame;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Pause")) {
            pauseGame = false;
			if(paused) {
               Time.timeScale = 1.0f;
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;

				paused = false;
			} else {
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;

				paused = true;
			}
		}
	}
}
