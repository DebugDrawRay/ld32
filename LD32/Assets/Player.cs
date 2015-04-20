using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public string enemyTag;

	public float moveForce;
	public GameObject playCam;
	public float jumpForce;

	public Deck currentDeck;

	public float moveBoost;
	public float moveBoostTime;

	public float jumpBoost;
	public float jumpBoostTime;

	public float damageBoost;
	public float damageBoostTime;

	public float defenseBoost;
	public float defenseBoostTime;

	public float moveNerf;
	public float moveNerfTime;

	public bool stunned;
	public float stunTime;

	public bool reversed;
	public float reversedTime;

	public bool confused;
	public float confuseTime;

	public bool isBuffed;

	public Vector3 knockback;

	public GameObject card1;
	public GameObject card2;
	public GameObject card3;
	public GameObject card4;
	public GameObject card5;

	public string InputVertical;
	public string InputHorizontal;
	public string InputViewControlX;
	public string InputViewControlY;
	public string InputIncrement;
	public string InputDecrement;
	public string InputTriggers;
	public string InputStart;
	public string InputJump;
	public string InputDraw;
	public string InputDirectionalX;
	public string InputDirectionalY;
	public string InputCard4;

	bool canUse = true;
	float currentCooldown;

    public bool lockCursor;

	public GameObject pauseObject;

	void Awake() {
		currentDeck = new Deck ();
        currentDeck.AddToSeedDeck ("two-of-swords");
        currentDeck.AddToSeedDeck ("three-of-swords");
        currentDeck.AddToSeedDeck ("four-of-swords");
        currentDeck.AddToSeedDeck ("five-of-swords");
        currentDeck.AddToSeedDeck ("six-of-swords");
        currentDeck.AddToSeedDeck ("seven-of-swords");
        currentDeck.AddToSeedDeck ("eight-of-swords");
        currentDeck.AddToSeedDeck ("nine-of-swords");
        currentDeck.AddToSeedDeck ("ten-of-swords");
        currentDeck.AddToSeedDeck ("page-of-swords");
        currentDeck.AddToSeedDeck ("knight-of-swords");
        currentDeck.AddToSeedDeck ("king-of-swords");
        currentDeck.AddToSeedDeck ("queen-of-swords");
        currentDeck.AddToSeedDeck ("ace-of-swords");

        currentDeck.AddToSeedDeck ("two-of-cups");
        currentDeck.AddToSeedDeck ("three-of-cups");
        currentDeck.AddToSeedDeck ("four-of-cups");
        currentDeck.AddToSeedDeck ("five-of-cups");
        currentDeck.AddToSeedDeck ("six-of-cups");
        currentDeck.AddToSeedDeck ("seven-of-cups");
        currentDeck.AddToSeedDeck ("eight-of-cups");
        currentDeck.AddToSeedDeck ("nine-of-cups");
        currentDeck.AddToSeedDeck ("ten-of-cups");
        currentDeck.AddToSeedDeck ("page-of-cups");
        currentDeck.AddToSeedDeck ("knight-of-cups");
        currentDeck.AddToSeedDeck ("king-of-cups");
        currentDeck.AddToSeedDeck ("queen-of-cups");
        currentDeck.AddToSeedDeck ("ace-of-cups");

        currentDeck.AddToSeedDeck ("two-of-wands");
        currentDeck.AddToSeedDeck ("three-of-wands");
        currentDeck.AddToSeedDeck ("four-of-wands");
        currentDeck.AddToSeedDeck ("five-of-wands");
        currentDeck.AddToSeedDeck ("six-of-wands");
        currentDeck.AddToSeedDeck ("seven-of-wands");
        currentDeck.AddToSeedDeck ("eight-of-wands");
        currentDeck.AddToSeedDeck ("nine-of-wands");
        currentDeck.AddToSeedDeck ("ten-of-wands");
        currentDeck.AddToSeedDeck ("page-of-wands");
        currentDeck.AddToSeedDeck ("knight-of-wands");
        currentDeck.AddToSeedDeck ("king-of-wands");
        currentDeck.AddToSeedDeck ("queen-of-wands");
        currentDeck.AddToSeedDeck ("ace-of-wands");

        currentDeck.AddToSeedDeck ("three-of-pentacles");
        currentDeck.AddToSeedDeck ("four-of-pentacles");
        currentDeck.AddToSeedDeck ("five-of-pentacles");
        currentDeck.AddToSeedDeck ("six-of-pentacles");
        currentDeck.AddToSeedDeck ("seven-of-pentacles");
        currentDeck.AddToSeedDeck ("eight-of-pentacles");
        currentDeck.AddToSeedDeck ("nine-of-pentacles");
        currentDeck.AddToSeedDeck ("ten-of-pentacles");
        currentDeck.AddToSeedDeck ("page-of-pentacles");
        currentDeck.AddToSeedDeck ("knight-of-pentacles");
        currentDeck.AddToSeedDeck ("king-of-pentacles");
        currentDeck.AddToSeedDeck ("queen-of-pentacles");
        currentDeck.AddToSeedDeck ("ace-of-pentacles");
        currentDeck.AddToSeedDeck ("two-of-pentacles");

		currentDeck.AddToSeedDeck("the-fool");
		currentDeck.AddToSeedDeck("the-magician");
		currentDeck.AddToSeedDeck("the-high-priestess");
		currentDeck.AddToSeedDeck("the-empress");
		currentDeck.AddToSeedDeck("the-emperor");
		currentDeck.AddToSeedDeck("the-hierophant");
		currentDeck.AddToSeedDeck("the-lovers");
		currentDeck.AddToSeedDeck("the-chariot");
		currentDeck.AddToSeedDeck("strength");
		currentDeck.AddToSeedDeck("the-hermit");
		currentDeck.AddToSeedDeck("wheel-of-fortune");
		currentDeck.AddToSeedDeck("justice");
		currentDeck.AddToSeedDeck("the-hanged-man");
		currentDeck.AddToSeedDeck("death");
		currentDeck.AddToSeedDeck("temperance");
		currentDeck.AddToSeedDeck("the-devil");
		currentDeck.AddToSeedDeck("the-tower");
		currentDeck.AddToSeedDeck("the-star");
		currentDeck.AddToSeedDeck("the-moon");
        currentDeck.AddToSeedDeck("the-sun");
		currentDeck.AddToSeedDeck("judgement");
		currentDeck.AddToSeedDeck ("the-world");

		currentDeck.InstanceSeedDeck ();
		currentDeck.DrawCard ();
		currentDeck.DrawCard ();
		currentDeck.DrawCard ();
		currentDeck.ResetModifier ();
		
	}

	// Use this for initialization
	void Start () {
		pauseObject = GameObject.Find ("PauseMaster");

        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
        }
		InitiateCam ();
	}

	void InitiateCam() {
		Init (transform, playCam.transform);
	}

	public bool canJump = true;

	public GameObject testProjectile;

	void Update() {
		if (pauseObject.GetComponent<PausingMaster> ().paused) {

		} else {

			RotateCam ();

			if (moveBoostTime <= 0) {
				moveBoost = 0f;
			} else {
				moveBoostTime -= Time.deltaTime;
			}

			if (jumpBoostTime <= 0) {
				jumpBoost = 0f;
			} else {
				jumpBoostTime -= Time.deltaTime;
			}

			if (damageBoostTime <= 0) {
				damageBoost = 0f;
			} else {
				damageBoostTime -= Time.deltaTime;
			}

			if (moveNerfTime <= 0) {
				moveNerf = 0f;
			} else {
				moveNerfTime -= Time.deltaTime;
			}

			if (stunTime <= 0) {
				stunned = false;
			} else {
				stunTime -= Time.deltaTime;
			}

			if (confuseTime <= 0) {
				confused = false;
			} else {
				confuseTime -= Time.deltaTime;
			}

			if (Input.GetButtonDown ("Draw") || Input.GetButtonDown ("Player1B")) {
				currentDeck.DrawCard ();
			}

			if (canUse) {
				if (Input.GetButtonDown ("Card0")) {
					//string curCard = currentDeck.UseCardInHandAtIndex (0);
					//if (curCard != "") {
					//    Debug.Log (curCard);
					//    GameObject curCardPref = (GameObject)Resources.Load ("CardPrefabs/" + curCard);
					//    curCardPref.GetComponent<UsableCard> ().UseCard (gameObject);

					//    canUse = false;
					//    currentCooldown = curCardPref.GetComponent<UsableCard> ().coolDown;
					//}
					currentDeck.SetSelectedCard (0);
				}
				if (Input.GetButtonDown ("Card1")) {
					/*string curCard = currentDeck.UseCardInHandAtIndex (1);
				if (curCard != "") {
					Debug.Log (curCard);
					GameObject curCardPref = (GameObject)Resources.Load ("CardPrefabs/" + curCard);
					curCardPref.GetComponent<UsableCard> ().UseCard (gameObject);

					canUse = false;
					currentCooldown = curCardPref.GetComponent<UsableCard> ().coolDown;
				}*/
					currentDeck.SetSelectedCard (1);
				}
				if (Input.GetButtonDown ("Card2")) {
					/*string curCard = currentDeck.UseCardInHandAtIndex (2);
				if (curCard != "") {
					Debug.Log (curCard);
					GameObject curCardPref = (GameObject)Resources.Load ("CardPrefabs/" + curCard);
					curCardPref.GetComponent<UsableCard> ().UseCard (gameObject);

					canUse = false;
					currentCooldown = curCardPref.GetComponent<UsableCard> ().coolDown;
				}*/
					currentDeck.SetSelectedCard (2);
				}
				if (Input.GetButtonDown ("Card3")) {
					/*string curCard = currentDeck.UseCardInHandAtIndex (3);
				if (curCard != "") {
					Debug.Log (curCard);
					GameObject curCardPref = (GameObject)Resources.Load ("CardPrefabs/" + curCard);
					curCardPref.GetComponent<UsableCard> ().UseCard (gameObject);

					canUse = false;
					currentCooldown = curCardPref.GetComponent<UsableCard> ().coolDown;
				}*/
					currentDeck.SetSelectedCard (3);
				}
				if (Input.GetButtonDown ("Card4")) {
					/*string curCard = currentDeck.UseCardInHandAtIndex (4);
				if (curCard != "") {
					Debug.Log (curCard);
					GameObject curCardPref = (GameObject)Resources.Load ("CardPrefabs/" + curCard);
					curCardPref.GetComponent<UsableCard> ().UseCard (gameObject);

					canUse = false;
					currentCooldown = curCardPref.GetComponent<UsableCard> ().coolDown;
				}*/
					currentDeck.SetSelectedCard (4);
				}
				if (Input.GetButtonDown ("Previous Selection") || Input.GetButtonDown ("Player1LB")) {
					currentDeck.DecrementSelectedCard ();
				}
				if (Input.GetButtonDown ("Next Selection") || Input.GetButtonDown ("Player1RB")) {
					currentDeck.IncrementSelectedCard ();
				}
				if (Input.GetButtonDown ("Mouse 0") || Input.GetAxis ("Player1Triggers") < -0.5f) {
					if (confused) {
						gameObject.GetComponent<Health> ().changeHealth (-10);
					}

					string curCard = currentDeck.UseCardInHandAtIndex (currentDeck.GetSelectedCard ());
					if (curCard != "") {
						Debug.Log (curCard);
						GameObject curCardPref = (GameObject)Resources.Load ("CardPrefabs/" + curCard);
						curCardPref.GetComponent<UsableCard> ().UseCard (gameObject);

						canUse = false;
						currentCooldown = curCardPref.GetComponent<UsableCard> ().coolDown;
					}
				}
			} else {
				if (currentCooldown <= 0) {
					canUse = true;
				} else {
					currentCooldown -= Time.deltaTime;
				}
			}


			/*if (Input.GetButtonDown ("Fire1")) {
			card1.GetComponent<UsableCard>().UseCard(gameObject);
		}

		if (Input.GetButtonDown ("Fire2")) {
			card2.GetComponent<UsableCard>().UseCard(gameObject);
		}

		if (Input.GetButtonDown ("Fire3")) {
			card3.GetComponent<UsableCard>().UseCard(gameObject);
		}

		if (Input.GetButtonDown ("Fire4")) {
			card4.GetComponent<UsableCard>().UseCard(gameObject);
		}

		if (Input.GetButtonDown ("Fire5")) {
			card5.GetComponent<UsableCard>().UseCard(gameObject);
		}*/

			if (Input.GetButtonDown ("Jump") || Input.GetButtonDown ("Player1A")) {
				if (Physics.Raycast (transform.position, -transform.up, 1.5f)) {
					gameObject.GetComponent<Rigidbody> ().AddForce (transform.up * (jumpForce + jumpBoost));
				}
				if (canJump) {
					//gameObject.GetComponent<Rigidbody>().AddForce(transform.up * jumpForce);
				}
			}
			if(moveBoost > 0 || jumpBoost > 0 || damageBoost > 0 || defenseBoost > 0 || moveNerf > 0 || stunned || reversed || confused)
			{
				isBuffed = true;
			}
			else
			{
				isBuffed = false;
			}
		}
	}

	// Update is called once per frame
	void FixedUpdate () {


		float h;
		float v;
		
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis ("Vertical");
		//Debug.Log ("HORIZONTAL: " + h + "\nVertical: " + v);
		Vector3 fMove = transform.forward * v;
		Vector3 sMove = transform.right * h;

		Vector3 mover = fMove + sMove;

		//actually move the player
		//Vector3 mover = new Vector3 (h, 0, v);
		mover.Normalize ();
		Vector3 fMover = mover * (moveForce + moveBoost - moveNerf);

		if (reversed) {
			fMover = -1f * fMover;
		}

		if (stunned) {
			fMover = fMover * 0f;
		}

		Vector3 finMover = new Vector3 (fMover.x, gameObject.GetComponent<Rigidbody> ().velocity.y, fMover.z);
		finMover += knockback;
		knockback = knockback * 0.9f;

		gameObject.GetComponent<Rigidbody> ().velocity = finMover;

		//transform.Translate (mover * Time.deltaTime * moveForce);

	}

	void RotateCam() {
		LookRotation (transform, playCam.transform);
	}

	///===================================================================================================================

	public float XSensitivity = 2f;
	public float YSensitivity = 2f;
	public bool clampVerticalRotation = true;
	public float MinimumX = -90F;
	public float MaximumX = 90F;
	public bool smooth;
	public float smoothTime = 5f;
	
	
	private Quaternion charTargetRot;
	private Quaternion camTargetRot;
	
	
	public void Init(Transform character, Transform camera)
	{
		charTargetRot = character.localRotation;
		camTargetRot = camera.localRotation;
	}
	
	
	public void LookRotation(Transform character, Transform camera)
	{
		float yRot = Input.GetAxisRaw("Mouse X") * XSensitivity;
		float xRot = Input.GetAxisRaw("Mouse Y") * YSensitivity;

		//float yRot = Input.GetAxis("Player1RightStickX") * XSensitivity;
		//float xRot = Input.GetAxis("Player1RightStickY") * YSensitivity;

		charTargetRot *= Quaternion.Euler (0f, yRot, 0f);
		camTargetRot *= Quaternion.Euler (-xRot, 0f, 0f);
		
		if(clampVerticalRotation)
			camTargetRot = ClampRotationAroundXAxis (camTargetRot);
		
		if(smooth)
		{
			character.localRotation = Quaternion.Slerp (character.localRotation, charTargetRot,
			                                            smoothTime * Time.deltaTime);
			camera.localRotation = Quaternion.Slerp (camera.localRotation, camTargetRot,
			                                         smoothTime * Time.deltaTime);
		}
		else
		{
			character.localRotation = charTargetRot;
			camera.localRotation = camTargetRot;
		}
	}
	
	
	Quaternion ClampRotationAroundXAxis(Quaternion q)
	{
		q.x /= q.w;
		q.y /= q.w;
		q.z /= q.w;
		q.w = 1.0f;
		
		float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);
		
		angleX = Mathf.Clamp (angleX, MinimumX, MaximumX);
		
		q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);
		
		return q;
	}

}
