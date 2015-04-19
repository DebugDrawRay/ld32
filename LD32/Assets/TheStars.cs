using UnityEngine;
using System.Collections;

public class TheStars : UsableCard {

	public float invulTime;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void UseCard(GameObject user) {
		user.GetComponent<Health> ().invul = true;
		user.GetComponent<Health> ().invulTime = invulTime;
	}
}

