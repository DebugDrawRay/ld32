using UnityEngine;
using System.Collections;

public class TheTower : UsableCard {
	
	public float boostAmount;
	public float boostTime;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void UseCard(GameObject user) {
		if (user.GetComponent<Player> () != null) {
			user.GetComponent<Player> ().jumpBoost = boostAmount;
			user.GetComponent<Player> ().jumpBoostTime = boostTime;
		}
		if (user.GetComponent<PlayerMulti> () != null) {
			user.GetComponent<PlayerMulti> ().jumpBoost = boostAmount;
			user.GetComponent<PlayerMulti> ().jumpBoostTime = boostTime;
		}
	}
}

