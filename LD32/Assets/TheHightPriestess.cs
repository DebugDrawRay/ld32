using UnityEngine;
using System.Collections;

public class TheHightPriestess : UsableCard {

	public float revDurration;
	
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
				plays.GetComponent<Player>().reversed = true;
				plays.GetComponent<Player>().reversedTime = revDurration;
			}
		}
		
		foreach (GameObject enems in enemies) {
			if(enems.GetComponent<RunMan>() != null) {
				enems.GetComponent<RunMan>().reversed = true;
				enems.GetComponent<RunMan>().reversedTime = revDurration;
			}
		}
	}
}
