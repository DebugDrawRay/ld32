using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck{
	private ArrayList seedDeck;
	private ArrayList hand;
	private ArrayList currentDeck;

	private int maxHandSize;

	public string DrawCard(){
		if(maxHandSize != -1 && hand.Count >= maxHandSize) throw new UnityException();
		if(currentDeck.Count == 0) throw new UnityException ();
		string drawnCard = (string) currentDeck [Random.Range(0, currentDeck.Count)];
		currentDeck.Remove (drawnCard);
		hand.Add (drawnCard);
///		EventManager.CardAdded();
		return drawnCard;
	}

	public int DeckCount(){
		return currentDeck.Count;
	}

	public int HandCount(){
		return hand.Count;
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

	// Use this for initialization
	public Deck() {
		seedDeck = new ArrayList();
		hand = new ArrayList();
		currentDeck = new ArrayList();
		maxHandSize = -1;
	}
}
