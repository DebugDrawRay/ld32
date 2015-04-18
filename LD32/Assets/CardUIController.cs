using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class CardUIController : MonoBehaviour {
	public GameObject cardobject;
	GameObject canvas;

	Deck currentDeck;
	int decksize;
	Text cardCountAsText;

	ArrayList cards;

	void Start () {
		decksize = -1;
		canvas = GameObject.FindGameObjectWithTag("Canvas");
		DeckTest a = (DeckTest) GameObject.FindGameObjectWithTag ("DeckTest").GetComponent("DeckTest");
		currentDeck = a.startingDeck;
		CardResourceLoader crl = (CardResourceLoader)GameObject.Find ("CardResourceLoader").GetComponent ("CardResourceLoader");

		foreach(string cardname in currentDeck.GetHand()){
			GameObject current = (GameObject) Instantiate(cardobject, Vector3.zero,Quaternion.identity);
			current.transform.SetParent(canvas.transform);
			cards.Add ( crl.Get2DCardReference(cardname));
		}
		//setCurrentDeck((Deck)GameObject.FindGameObjectWithTag("DeckTest").GetComponent(DeckTest).startingDeck);
	}

	public void setCurrentDeck(Deck curDeck){
		currentDeck = curDeck;
	}

	public void DrawDeckSize(){
		GameObject cCount = GameObject.FindGameObjectWithTag ("CardCount");
		cardCountAsText = cCount.GetComponent<Text> ();
		cardCountAsText.text = "" + decksize;
	}

	// Update is called once per frame
	void Update () {
		if (currentDeck != null) {
			if (currentDeck.DeckCount () != decksize) {
				decksize = currentDeck.DeckCount ();
				DrawDeckSize ();
			}
			if(currentDeck.GetModifier() == -2){
				
			}else if(currentDeck.GetModifier() > -1){
				
			}
		} else {
			GameObject cCount = GameObject.FindGameObjectWithTag ("CardCount");
			cardCountAsText = cCount.GetComponent<Text> ();
			cardCountAsText.text = "Butts";
			//DeckTest a = (DeckTest) GameObject.FindGameObjectWithTag ("DeckTest").GetComponent("DeckTest");
			//currentDeck = a.startingDeck;
		}
	}
}
