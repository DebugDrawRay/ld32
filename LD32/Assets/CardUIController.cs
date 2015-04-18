using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardUIController : MonoBehaviour {
	GameObject canvas;

	Deck currentDeck;
	int decksize;

	void Start () {
		decksize = -1;
		canvas = GameObject.FindGameObjectWithTag("Canvas");
	}

	public void setCurrentDeck(Deck curDeck){
		currentDeck = curDeck;
	}

	public void DrawDeckSize(){
		//canvas.
	}


	// Update is called once per frame
	void Update () {
		if (currentDeck.DeckCount() != decksize) {
			decksize = currentDeck.DeckCount();
			DrawDeckSize();
		}

	}
}
