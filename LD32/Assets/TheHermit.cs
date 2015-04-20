using UnityEngine;
using System.Collections;

public class TheHermit : UsableCard {
	
	public float ampAmount;
	public float ampTime;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void UseCard(GameObject user) {
		if (user.GetComponent<Player> () != null) {
			user.GetComponent<Player> ().defenseBoost = ampAmount;
			user.GetComponent<Player> ().defenseBoostTime = ampTime;
		}
		if (user.GetComponent<PlayerMulti> () != null) {
			user.GetComponent<PlayerMulti> ().defenseBoost = ampAmount;
			user.GetComponent<PlayerMulti> ().defenseBoostTime = ampTime;
		}
	}
}