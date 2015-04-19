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
		user.GetComponent<Player> ().damageBoost = ampAmount;
		user.GetComponent<Player> ().damageBoostTime = ampTime;
	}
}