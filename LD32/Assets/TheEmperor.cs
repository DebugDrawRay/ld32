using UnityEngine;
using System.Collections;

public class TheEmperor : UsableCard {

	public float slowAmount;
	public float slowDurration;

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
			if(!plays.Equals(user)) {
				plays.GetComponent<Player>().moveNerf = slowAmount;
				plays.GetComponent<Player>().moveNerfTime = slowDurration;
			}
		}
		
		foreach (GameObject enems in enemies) {
			//change enemySpeed
		}
	}
}