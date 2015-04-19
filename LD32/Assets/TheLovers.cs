using UnityEngine;
using System.Collections;

public class TheLovers : UsableCard {
	
	public float healAmount;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void UseCard(GameObject user) {
		user.GetComponent<Health> ().changeHealth (healAmount);
		if (user.GetComponent<Health> ().health > 100f) {
			user.GetComponent<Health> ().health = 100f;
		}
	}
}

