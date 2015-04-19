using UnityEngine;
using System.Collections;

public class TheEmpress : UsableCard {
	
	public float boostAmount;
	public float boostTime;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void UseCard(GameObject user) {
		user.GetComponent<Player> ().moveBoost = boostAmount;
		user.GetComponent<Player> ().moveBoostTime = boostTime;
	}
}
