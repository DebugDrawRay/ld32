using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float health;

	public void changeHealth(float change) {
		health += change;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0f) {
			Destroy(gameObject);
		}
	}
}
