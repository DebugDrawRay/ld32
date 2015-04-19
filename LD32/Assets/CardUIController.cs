using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardUIController : MonoBehaviour {
	private const int CARD_VARIANCE = 135;
	private const int STARTING_POSITION_X = 90;
	private const int STARTING_POSITION_Y = 110;

	public GameObject cardobject;
	GameObject canvas;

	Deck currentDeck;
	int decksize;
	Text cardCountAsText;
	CardResourceLoader crl;
	ArrayList cards;

	void Start () {
		decksize = -1;
		canvas = GameObject.FindGameObjectWithTag("Canvas");
		//DeckTest a = (DeckTest) GameObject.FindGameObjectWithTag ("DeckTest").GetComponent("DeckTest");
		//currentDeck = a.startingDeck;
		currentDeck = GameObject.Find ("Player").GetComponent<Player> ().currentDeck;
		crl = (CardResourceLoader)GameObject.Find ("CardResourceLoader").GetComponent ("CardResourceLoader");
		cards = new ArrayList ();
		int count = 0;
		foreach(string cardname in currentDeck.GetHand()){
			GameObject current = (GameObject) Instantiate(cardobject, new Vector3(STARTING_POSITION_X + CARD_VARIANCE * count, STARTING_POSITION_Y,0) ,Quaternion.identity);
			current.transform.SetParent(canvas.transform);
			Texture2D currentTexture = crl.Get2DCardReference(cardname);
			current.GetComponent<Image>().sprite = Sprite.Create (currentTexture, new Rect(0,0, currentTexture.width, currentTexture.height),Vector2.zero);
			cards.Add ( current );
			count++;
		}

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
				GameObject current = (GameObject) Instantiate(cardobject, new Vector3(STARTING_POSITION_X + CARD_VARIANCE * (currentDeck.HandCount() - 1), STARTING_POSITION_Y,0) ,Quaternion.identity);
				current.transform.SetParent(canvas.transform);
				Texture2D currentTexture = crl.Get2DCardReference((string)currentDeck.GetHand()[currentDeck.HandCount() - 1]);
				current.GetComponent<Image>().sprite = Sprite.Create (currentTexture, new Rect(0,0, currentTexture.width, currentTexture.height),Vector2.zero);
				cards.Add ( current );
			}else if(currentDeck.GetModifier() > -1){
				for(int index = currentDeck.GetModifier() + 1; index <= currentDeck.HandCount(); index ++){
					GameObject previousCard = (GameObject) cards[index - 1];
					StartCoroutine(MoveCard( (GameObject) cards[index], previousCard.transform.position));
				}
				GameObject deletedcard = (GameObject) cards[currentDeck.GetModifier()];
				cards.RemoveAt(currentDeck.GetModifier());
				Destroy(deletedcard);
			}
			if(currentDeck.SelectionChanged()){
				//Deal with it
				currentDeck.ResetSelection();
			}
		} else {
			GameObject cCount = GameObject.FindGameObjectWithTag ("CardCount");
			cardCountAsText = cCount.GetComponent<Text> ();
			cardCountAsText.text = "Butts";
			//DeckTest a = (DeckTest) GameObject.FindGameObjectWithTag ("DeckTest").GetComponent("DeckTest");
			//currentDeck = a.startingDeck;
		}
		currentDeck.ResetModifier();
	}

	IEnumerator MoveCard(GameObject card, Vector3 target){
		float elapsedTime = 0;
		float totalTime = 0.1f;
		Vector3 startingPos = card.transform.position;
		while(elapsedTime < totalTime){
			card.transform.position = Vector3.Lerp (startingPos, target, (elapsedTime / totalTime));
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		card.transform.position = target;
	}
}
