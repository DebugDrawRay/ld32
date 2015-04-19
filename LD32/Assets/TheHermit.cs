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
		user.GetComponent<Player> ().defenseBoost = ampAmount;
		user.GetComponent<Player> ().defenseBoostTime = ampTime;
	}
}