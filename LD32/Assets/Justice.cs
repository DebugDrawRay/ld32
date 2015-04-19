using UnityEngine;
using System.Collections;

public class Justice : UsableCard {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void UseCard(GameObject user) {
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("EnemyUnit");

		foreach (GameObject plays in players) {
			plays.GetComponent<Health>().health = 1f;
		}

		foreach (GameObject enems in enemies) {
			enems.GetComponent<Health>().health = 1f;
		}
	}
}

