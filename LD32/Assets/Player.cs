using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float moveForce;
	public GameObject playCam;
	public float jumpForce;

	public Deck currentDeck;

	public GameObject card1;
	public GameObject card2;
	public GameObject card3;
	public GameObject card4;
	public GameObject card5;

	bool canUse = true;
	float currentCooldown;

	void Awake() {
		currentDeck = new Deck ();
		currentDeck.AddToSeedDeck ("ace-of-cups");
		currentDeck.AddToSeedDeck ("ace-of-cups");
		currentDeck.AddToSeedDeck ("ace-of-cups");
		currentDeck.AddToSeedDeck ("ace-of-cups");
		currentDeck.AddToSeedDeck ("ace-of-cups");
		currentDeck.AddToSeedDeck ("ace-of-cups");
		currentDeck.AddToSeedDeck ("ace-of-cups");
		currentDeck.AddToSeedDeck ("ace-of-cups");
		currentDeck.AddToSeedDeck ("ace-of-cups");
		currentDeck.AddToSeedDeck ("ace-of-cups");
		currentDeck.InstanceSeedDeck ();
		currentDeck.DrawCard ();
		currentDeck.DrawCard ();
		currentDeck.DrawCard ();
		currentDeck.ResetModifier ();


	}

	// Use this for initialization
	void Start () {
		InitiateCam ();
	}

	void InitiateCam() {
		Init (transform, playCam.transform);
	}

	public bool canJump = true;

	public GameObject testProjectile;

	void Update() {
		RotateCam ();

		if (Input.GetButtonDown ("Draw")) {
			currentDeck.DrawCard ();
		}

		if (canUse) {
			if (Input.GetButtonDown ("Card0")) {
				string curCard = currentDeck.UseCardInHandAtIndex (0);
				if (curCard != "") {
					Debug.Log (curCard);
					GameObject curCardPref = (GameObject)Resources.Load ("CardPrefabs/" + curCard);
					curCardPref.GetComponent<UsableCard> ().UseCard (gameObject);

					canUse = false;
					currentCooldown = curCardPref.GetComponent<UsableCard> ().coolDown;
				}
			}
			if (Input.GetButtonDown ("Card1")) {
				string curCard = currentDeck.UseCardInHandAtIndex (1);
				if (curCard != "") {
					Debug.Log (curCard);
					GameObject curCardPref = (GameObject)Resources.Load ("CardPrefabs/" + curCard);
					curCardPref.GetComponent<UsableCard> ().UseCard (gameObject);

					canUse = false;
					currentCooldown = curCardPref.GetComponent<UsableCard> ().coolDown;
				}
			}
			if (Input.GetButtonDown ("Card2")) {
				string curCard = currentDeck.UseCardInHandAtIndex (2);
				if (curCard != "") {
					Debug.Log (curCard);
					GameObject curCardPref = (GameObject)Resources.Load ("CardPrefabs/" + curCard);
					curCardPref.GetComponent<UsableCard> ().UseCard (gameObject);

					canUse = false;
					currentCooldown = curCardPref.GetComponent<UsableCard> ().coolDown;
				}
			}
			if (Input.GetButtonDown ("Card3")) {
				string curCard = currentDeck.UseCardInHandAtIndex (3);
				if (curCard != "") {
					Debug.Log (curCard);
					GameObject curCardPref = (GameObject)Resources.Load ("CardPrefabs/" + curCard);
					curCardPref.GetComponent<UsableCard> ().UseCard (gameObject);

					canUse = false;
					currentCooldown = curCardPref.GetComponent<UsableCard> ().coolDown;
				}
			}
			if (Input.GetButtonDown ("Card4")) {
				string curCard = currentDeck.UseCardInHandAtIndex (4);
				if (curCard != "") {
					Debug.Log (curCard);
					GameObject curCardPref = (GameObject)Resources.Load ("CardPrefabs/" + curCard);
					curCardPref.GetComponent<UsableCard> ().UseCard (gameObject);

					canUse = false;
					currentCooldown = curCardPref.GetComponent<UsableCard> ().coolDown;
				}
			}
		} else {
			if(currentCooldown <= 0) {
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

		if(Input.GetButtonDown("Jump")) {
			if(Physics.Raycast(transform.position, -transform.up, 1.5f)) {
				gameObject.GetComponent<Rigidbody>().AddForce(transform.up * jumpForce);
			}
			if(canJump) {
				//gameObject.GetComponent<Rigidbody>().AddForce(transform.up * jumpForce);
			}
		}
	}

	// Update is called once per frame
	void FixedUpdate () {


		float h;
		float v;
		
		h = Input.GetAxisRaw ("Horizontal");
		v = Input.GetAxisRaw ("Vertical");

		Vector3 fMove = transform.forward * v;
		Vector3 sMove = transform.right * h;

		Vector3 mover = fMove + sMove;

		//actually move the player
		//Vector3 mover = new Vector3 (h, 0, v);
		mover.Normalize ();
		Vector3 fMover = mover * moveForce;
		Vector3 finMover = new Vector3 (fMover.x, gameObject.GetComponent<Rigidbody> ().velocity.y, fMover.z);

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
		float yRot = Input.GetAxis("Mouse X") * XSensitivity;
		float xRot = Input.GetAxis("Mouse Y") * YSensitivity;
		
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
