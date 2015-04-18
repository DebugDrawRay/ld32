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
		//Debug.Log (startingDeck.UseCardInHandAtIndex (0));
		//Debug.Log (startingDeck.UseCardInHandAtIndex (0));
		//Debug.Log (startingDeck.UseCardInHandAtIndex (0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
