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
		if ((maxHandSize == -1 || hand.Count >= maxHandSize) && currentDeck.Count != 0) {
			string drawnCard = (string)currentDeck [Random.Range (0, currentDeck.Count)];
			currentDeck.Remove (drawnCard);
			hand.Add (drawnCard);
			mod = -2;
			///		EventManager.CardAdded();
			return drawnCard;
		}
		return "";
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
		if (index < hand.Count &&  index >= 0) {
			string usedCard = (string)hand [index];
			hand.Remove (usedCard);
			mod = index;
			return usedCard;
		}
		return "";
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

	public void ResetModifier(){
		mod = -1;
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
