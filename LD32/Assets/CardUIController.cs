using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardUIController : MonoBehaviour {
	private const int CARD_VARIANCE = 67;
	private const int STARTING_POSITION_X = 90;
	private const int STARTING_POSITION_Y = 70;
    private Rect CARD_SIZE = new Rect(0f, 0f, 300f, 531f);

	public GameObject cardobject;
	GameObject canvas;

	Deck currentDeck;
    Health playerHealth;
	int decksize;
	Text cardCountAsText;
	CardResourceLoader crl;
	ArrayList cards;
    public Image health;
    public Text healthTxt;
    float maxHealth;

	void Start () {
		decksize = -1;
		canvas = GameObject.FindGameObjectWithTag("Canvas");
		//DeckTest a = (DeckTest) GameObject.FindGameObjectWithTag ("DeckTest").GetComponent("DeckTest");
		//currentDeck = a.startingDeck;
		currentDeck = GameObject.Find ("Player").GetComponent<Player> ().currentDeck;
        playerHealth = GameObject.Find("Player").GetComponent<Health>();
        maxHealth = playerHealth.getHealth();
		crl = (CardResourceLoader)GameObject.Find ("CardResourceLoader").GetComponent ("CardResourceLoader");
		cards = new ArrayList ();
		int count = 0;
		foreach(string cardname in currentDeck.GetHand()){
			GameObject current = (GameObject) Instantiate(cardobject, new Vector3(STARTING_POSITION_X + CARD_VARIANCE * count, STARTING_POSITION_Y,0) ,Quaternion.identity);
			current.transform.SetParent(canvas.transform);
			current.GetComponent<Image>().sprite = Sprite.Create (crl.Get2DCardReference(cardname), CARD_SIZE, Vector2.zero);
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
		cardCountAsText.text = decksize.ToString();
	}

	// Update is called once per frame
	void Update () {

        health.fillAmount = playerHealth.getHealth() / maxHealth;
        healthTxt.text = playerHealth.getHealth().ToString();
		if (currentDeck != null) {
			if (currentDeck.DeckCount () != decksize) {
				decksize = currentDeck.DeckCount ();
				DrawDeckSize ();
			}
			if(currentDeck.GetModifier() == -2){
				GameObject current = (GameObject) Instantiate(cardobject, new Vector3(STARTING_POSITION_X + CARD_VARIANCE * (currentDeck.HandCount() - 1), STARTING_POSITION_Y,0) ,Quaternion.identity);
				current.transform.SetParent(canvas.transform);
				current.GetComponent<Image>().sprite = Sprite.Create (crl.Get2DCardReference((string)currentDeck.GetHand()[currentDeck.HandCount() - 1]), CARD_SIZE,Vector2.zero);
				cards.Add ( current );
			}else if(currentDeck.GetModifier() > -1){
				for(int index = currentDeck.GetModifier() + 1; index <= currentDeck.HandCount(); index ++){
					GameObject previousCard = (GameObject) cards[index - 1];
					StartCoroutine(MoveCard( (GameObject) cards[index], previousCard.transform.position));
				}
				GameObject deletedcard = (GameObject) cards[currentDeck.GetModifier()];
				cards.Remove(deletedcard);
				Destroy(deletedcard);
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
	}
}
