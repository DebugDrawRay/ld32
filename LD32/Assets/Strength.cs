using UnityEngine;
using System.Collections;

public class Strength : UsableCard {
	
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
			user.GetComponent<Player> ().damageBoost = ampAmount;
			user.GetComponent<Player> ().damageBoostTime = ampTime;
		}
		if (user.GetComponent<PlayerMulti> () != null) {
			user.GetComponent<PlayerMulti> ().damageBoost = ampAmount;
			user.GetComponent<PlayerMulti> ().damageBoostTime = ampTime;
		}

	}
}