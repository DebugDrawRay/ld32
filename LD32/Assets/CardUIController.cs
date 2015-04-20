using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardUIController : MonoBehaviour {
	private const int CARD_VARIANCE = 67;
	private const int STARTING_POSITION_X = -332;
	private const int STARTING_POSITION_Y = 64;
    private Rect CARD_SIZE = new Rect(0f, 0f, 300f, 531f);

    private int prevCard = -1;

	public GameObject cardobject;
	public GameObject canvas;
	public Text cardcount;

	Deck currentDeck;
    Health playerHealth;
	int decksize;
	Text cardCountAsText;
	CardResourceLoader crl;
	ArrayList cards;
    public Image health;
    public Text healthTxt;
    float maxHealth;
    public Image cardMeter;
    float maxCards;


	public void InitializeUIController(GameObject pl) {
		decksize = -1;
		this.cardcount = cardcount;
		this.canvas = canvas;
		//DeckTest a = (DeckTest) GameObject.FindGameObjectWithTag ("DeckTest").GetComponent("DeckTest");
		//currentDeck = a.startingDeck;
		currentDeck = pl.GetComponent<Player> ().currentDeck;
        playerHealth = pl.GetComponent<Health>();
        maxHealth = playerHealth.getHealth();
        maxCards = currentDeck.DeckCount();
		crl = (CardResourceLoader)GameObject.Find ("CardResourceLoader").GetComponent ("CardResourceLoader");
		cards = new ArrayList ();
		int count = 0;
		foreach(string cardname in currentDeck.GetHand()){
			GameObject current = (GameObject) Instantiate(cardobject, new Vector2(STARTING_POSITION_X + CARD_VARIANCE * count, STARTING_POSITION_Y) ,Quaternion.identity);
			current.transform.SetParent(canvas.transform, false);
			current.GetComponent<Image>().sprite = Sprite.Create (crl.Get2DCardReference(cardname), CARD_SIZE, Vector2.zero);
            Texture2D currentTexture = crl.Get2DCardReference(cardname);
			current.GetComponent<Image>().sprite = Sprite.Create (currentTexture, new Rect(0,0, currentTexture.width, currentTexture.height),Vector2.zero);
			cards.Add ( current );
			count++;
		}

        //GameObject selection = cards[currentDeck.GetSelectedCard()] as GameObject;
        //StartCoroutine(SelectedCardControl(selection, 20f));


	}

	public void setCurrentDeck(Deck curDeck){
		currentDeck = curDeck;
	}

	public void DrawDeckSize(){
		cardCountAsText = cardcount.GetComponent<Text> ();
		cardCountAsText.text = decksize.ToString();
	}

	// Update is called once per frame
	void Update () {
        health.fillAmount = playerHealth.getHealth() / maxHealth;
        healthTxt.text = playerHealth.getHealth().ToString();

        cardMeter.fillAmount = currentDeck.DeckCount() / maxCards;

		if (currentDeck != null) {
			if (currentDeck.DeckCount () != decksize) {
				decksize = currentDeck.DeckCount ();
				DrawDeckSize ();
			}
			if(currentDeck.GetModifier() == -2){
				GameObject current = (GameObject) Instantiate(cardobject, new Vector2(STARTING_POSITION_X + CARD_VARIANCE * (currentDeck.HandCount() - 1), STARTING_POSITION_Y) ,Quaternion.identity);
				current.transform.SetParent(canvas.transform, false);
				current.GetComponent<Image>().sprite = Sprite.Create (crl.Get2DCardReference((string)currentDeck.GetHand()[currentDeck.HandCount() - 1]), CARD_SIZE,Vector2.zero);
				Texture2D currentTexture = crl.Get2DCardReference((string)currentDeck.GetHand()[currentDeck.HandCount() - 1]);
				current.GetComponent<Image>().sprite = Sprite.Create (currentTexture, new Rect(0,0, currentTexture.width, currentTexture.height),Vector2.zero);
				cards.Add ( current );
			}else if(currentDeck.GetModifier() > -1){
				for(int index = currentDeck.GetModifier() + 1; index <= currentDeck.HandCount(); index ++){
					GameObject previousCard = (GameObject) cards[index - 1];
					StartCoroutine(MoveCard((GameObject)cards[index], previousCard.GetComponent<RectTransform>().anchoredPosition));
				}
				GameObject deletedcard = (GameObject) cards[currentDeck.GetModifier()];
				cards.RemoveAt(currentDeck.GetModifier());
				Destroy(deletedcard);
			}
			if(currentDeck.SelectionChanged()){
				//Deal with it
                if (currentDeck.GetSelectedCard() != prevCard)
                {
                    GameObject selection = (GameObject) cards[currentDeck.GetSelectedCard()];
                    StartCoroutine(SelectedCardControl(selection, 20f));

                    if (prevCard != -1 && prevCard < cards.Count)
                    {
                        selection = cards[prevCard] as GameObject;
                        StartCoroutine(SelectedCardControl(selection, 0f));
                    }

                    prevCard = currentDeck.GetSelectedCard();
                    currentDeck.ResetSelection();
                }
			}
		} else {
			cardCountAsText = cardcount.GetComponent<Text> ();
			cardCountAsText.text = "Butts";
			//DeckTest a = (DeckTest) GameObject.FindGameObjectWithTag ("DeckTest").GetComponent("DeckTest");
			//currentDeck = a.startingDeck;
		}
		currentDeck.ResetModifier();
	}

	IEnumerator MoveCard(GameObject card, Vector2 target){
		float elapsedTime = 0;
		float totalTime = 0.1f;
		Vector2 startingPos = card.GetComponent<RectTransform>().anchoredPosition;
		Vector2 endingPos = new Vector2(target.x, startingPos.y);
		while(elapsedTime < totalTime){
			if(card != null)
				card.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp (startingPos, endingPos, (elapsedTime / totalTime));
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		if(card != null)
			card.GetComponent<RectTransform>().anchoredPosition = endingPos;
		//card.transform.position.z = 0;
	}

    IEnumerator SelectedCardControl(GameObject card, float offset)
    {

		float elapsedTime = 0;
		float totalTime = 0.1f;
		Vector2 startingPos = card.GetComponent<RectTransform>().anchoredPosition;
		Vector2 target = new Vector2(startingPos.x, STARTING_POSITION_Y + offset);
		while (elapsedTime < totalTime && card != null) {
			if(card != null)
				card.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp (startingPos, target, (elapsedTime / totalTime));
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}
		if(card!=null) card.GetComponent<RectTransform>().anchoredPosition = target;
		//card.transform.position.z = 0;
    }
}
