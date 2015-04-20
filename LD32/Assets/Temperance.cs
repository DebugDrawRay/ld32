using UnityEngine;
using System.Collections;

public class Temperance : UsableCard {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void UseCard(GameObject user) {
		if (user.GetComponent<Player> () != null) {
			user.GetComponent<Player> ().currentDeck.InstanceSeedDeck ();
		}
		if (user.GetComponent<PlayerMulti> () != null) {
			user.GetComponent<PlayerMulti> ().currentDeck.InstanceSeedDeck ();
		}
	}
}