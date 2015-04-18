using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck{
	private ArrayList seedDeck;
	private ArrayList hand;
	private ArrayList currentDeck;

	private int maxHandSize;

	private int mod;
	//-1 means no change
	//-2 means card added
	//other number means card removed at index;

	public string DrawCard(){
		if(maxHandSize != -1 && hand.Count >= maxHandSize) throw new UnityException();
		if(currentDeck.Count == 0) throw new UnityException ();
		string drawnCard = (string) currentDeck [Random.Range(0, currentDeck.Count)];
		currentDeck.Remove (drawnCard);
		hand.Add (drawnCard);
		mod = -2;
///		EventManager.CardAdded();
		return drawnCard;
	}

	public int DeckCount(){
		return currentDeck.Count;
	}

	public int HandCount(){
		return hand.Count;
	}

	public ArrayList GetHand(){
		return hand;
	}

	public void AddCardToDeck(string card){
		//if (Resources. != null)
		currentDeck.Add (card);
	}

	public string UseCardInHandAtIndex(int index){
		if (index >= hand.Count) throw new UnityException ();
		if (index < 0) throw new UnityException();
		string usedCard = (string) hand [Random.Range(0, hand.Count)];
		hand.Remove (usedCard);
		return usedCard;
	}

	public void InstanceSeedDeck(){
		currentDeck = (ArrayList) seedDeck.Clone ();
	}

	public void AddToSeedDeck (string cardname){
		seedDeck.Add (cardname);
	}

	public int GetModifier(){
		return mod;
	}

	// Use this for initialization
	public Deck() {
		seedDeck = new ArrayList();
		hand = new ArrayList();
		currentDeck = new ArrayList();
		maxHandSize = -1;
		mod = -1;
	}
}
