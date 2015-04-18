using UnityEngine;
using System.Collections;

public class DeckTest : MonoBehaviour {
	public Deck startingDeck;
	// Use this for initialization
	void Awake () {
		startingDeck = new Deck ();
		startingDeck.AddToSeedDeck ("ace-of-cups");
		startingDeck.AddToSeedDeck ("ace-of-cups");
		startingDeck.AddToSeedDeck ("ace-of-cups");
		startingDeck.AddToSeedDeck ("ace-of-cups");
		startingDeck.AddToSeedDeck ("ace-of-cups");
		startingDeck.AddToSeedDeck ("ace-of-cups");
		startingDeck.AddToSeedDeck ("ace-of-cups");
		startingDeck.AddToSeedDeck ("ace-of-cups");
		startingDeck.InstanceSeedDeck ();
		startingDeck.DrawCard ();
		startingDeck.DrawCard ();
		startingDeck.DrawCard ();
		startingDeck.ResetModifier ();
		//Debug.Log (startingDeck.UseCardInHandAtIndex (0));
		//Debug.Log (startingDeck.UseCardInHandAtIndex (0));
		//Debug.Log (startingDeck.UseCardInHandAtIndex (0));
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("CurrentHand Size: " + startingDeck.HandCount());
		if (Input.GetButtonDown ("Draw")) {
			startingDeck.DrawCard();
		}
		if (Input.GetButtonDown ("Card0")) {
			startingDeck.UseCardInHandAtIndex(0);
		}
		if (Input.GetButtonDown ("Card2")) {
			startingDeck.UseCardInHandAtIndex(2);
		}
		if (Input.GetButtonDown ("Card3")) {
			startingDeck.UseCardInHandAtIndex(3);
		}
		if (Input.GetButtonDown ("Card4")) {
			startingDeck.UseCardInHandAtIndex(4);
		}
		if (Input.GetButtonDown ("Card1")) {
			startingDeck.UseCardInHandAtIndex(1);
		}
	}
}
