using UnityEngine;
using System.Collections;

public class DeckTest : MonoBehaviour {
	Deck startingDeck;
	// Use this for initialization
	void Start () {
		startingDeck = new Deck ();
		startingDeck.AddToSeedDeck ("Card0");
		startingDeck.AddToSeedDeck ("Card1");
		startingDeck.AddToSeedDeck ("Card2");
		startingDeck.AddToSeedDeck ("Card3");
		startingDeck.AddToSeedDeck ("Card4");
		startingDeck.AddToSeedDeck ("Card5");
		startingDeck.AddToSeedDeck ("Card6");
		startingDeck.AddToSeedDeck ("Card7");
		startingDeck.InstanceSeedDeck ();
		startingDeck.DrawCard ();
		startingDeck.DrawCard ();
		startingDeck.DrawCard ();
		Debug.Log (startingDeck.UseCardInHandAtIndex (0));
		Debug.Log (startingDeck.UseCardInHandAtIndex (0));
		Debug.Log (startingDeck.UseCardInHandAtIndex (0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
