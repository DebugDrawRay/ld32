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
				if(plays.GetComponent<Player>() != null) {
					plays.GetComponent<Player>().moveNerf = slowAmount;
					plays.GetComponent<Player>().moveNerfTime = slowDurration;
				}

				if(plays.GetComponent<PlayerMulti>() != null) {
					plays.GetComponent<PlayerMulti>().moveNerf = slowAmount;
					plays.GetComponent<PlayerMulti>().moveNerfTime = slowDurration;
				}
			}
		}
		
		foreach (GameObject enems in enemies) {
			if(enems.GetComponent<RunMan>() != null) {
				enems.GetComponent<RunMan>().moveNerf = slowAmount;
				enems.GetComponent<RunMan>().moveNerfTime = slowDurration;
			}

			if(enems.GetComponent<EnemyChaseBird>() != null) {
				enems.GetComponent<EnemyChaseBird>().moveNerf = slowAmount;
				enems.GetComponent<EnemyChaseBird>().moveNerfTime = slowDurration;
			}
		}
	}
}