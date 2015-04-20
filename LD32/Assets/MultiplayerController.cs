using UnityEngine;
using System.Collections;

public class MultiplayerController : MonoBehaviour {

	int maxNumberOfPlayers = 4;

	ArrayList players;

	public GameObject P1Spawn;
	public GameObject P2Spawn;
	public GameObject P3Spawn;
	public GameObject P4Spawn;

	public GameObject CanvasPrefab;

	public GameObject PlayerPrefab;

	private const string P1V = "Player1Vertical";
	private const string P1H = "Player1Horizontal";
	private const string P1X = "Player1X";
	private const string P1Y = "Player1Y";
	private const string P1A = "Player1A";
	private const string P1B = "Player1B";
	private const string P1T = "Player1Triggers";
	private const string P1RB = "Player1RB";
	private const string P1LB = "Player1LB";
	private const string P1ST = "Player1Start";
	private const string P1SE = "Player1Select";
	private const string P1LC = "Player1LeftClick";
	private const string P1RC = "Player1RightClick";
	private const string P1RSX = "Player1RightStickX";
	private const string P1RSY = "Player1RightStickY";
	private const string P1DX = "Player1DirectionalX";
	private const string P1DY = "Player1DirectionalY";

	private const string P2V = "Player2Vertical";
	private const string P2H = "Player2Horizontal";
	private const string P2X = "Player2X";
	private const string P2Y = "Player2Y";
	private const string P2A = "Player2A";
	private const string P2B = "Player2B";
	private const string P2T = "Player2Triggers";
	private const string P2RB = "Player2RB";
	private const string P2LB = "Player2LB";
	private const string P2ST = "Player2Start";
	private const string P2SE = "Player2Select";
	private const string P2LC = "Player2LeftClick";
	private const string P2RC = "Player2RightClick";
	private const string P2RSX = "Player2RightStickX";
	private const string P2RSY = "Player2RightStickY";
	private const string P2DX = "Player2DirectionalX";
	private const string P2DY = "Player2DirectionalY";

	private const string P3V = "Player3Vertical";
	private const string P3H = "Player3Horizontal";
	private const string P3X = "Player3X";
	private const string P3Y = "Player3Y";
	private const string P3A = "Player3A";
	private const string P3B = "Player3B";
	private const string P3T = "Player3Triggers";
	private const string P3RB = "Player3RB";
	private const string P3LB = "Player3LB";
	private const string P3ST = "Player3Start";
	private const string P3SE = "Player3Select";
	private const string P3LC = "Player3LeftClick";
	private const string P3RC = "Player3RightClick";
	private const string P3RSX = "Player3RightStickX";
	private const string P3RSY = "Player3RightStickY";
	private const string P3DX = "Player3DirectionalX";
	private const string P3DY = "Player3DirectionalY";

	private const string P4V = "Player4Vertical";
	private const string P4H = "Player4Horizontal";
	private const string P4X = "Player4X";
	private const string P4Y = "Player4Y";
	private const string P4A = "Player4A";
	private const string P4B = "Player4B";
	private const string P4T = "Player4Triggers";
	private const string P4RB = "Player4RB";
	private const string P4LB = "Player4LB";
	private const string P4ST = "Player4Start";
	private const string P4SE = "Player4Select";
	private const string P4LC = "Player4LeftClick";
	private const string P4RC = "Player4RightClick";
	private const string P4RSX = "Player4RightStickX";
	private const string P4RSY = "Player4RightStickY";
	private const string P4DX = "Player4DirectionalX";
	private const string P4DY = "Player4DirectionalY";

	// Use this for initialization
	void Start () {
		players = new ArrayList ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetInputsToPlayer1(GameObject player){
		Player control = player.GetComponent<Player> ();
		control.InputVertical = P1V;
		control.InputHorizontal = P1H;
		control.InputViewControlX = P1RSX;
		control.InputViewControlY = P1RSY;
		control.InputIncrement = P1RB;
		control.InputDecrement = P1LB;
		control.InputTriggers = P1T;
		control.InputStart = P1ST;
		control.InputJump = P1A;
		control.InputDraw = P1B;
		control.InputDirectionalX = P1DX;
		control.InputDirectionalY = P1DY;
		control.InputCard4 = P1RC;
	}

	void SetInputsToPlayer2(GameObject player){
		Player control = player.GetComponent<Player> ();
		control.InputVertical = P2V;
		control.InputHorizontal = P2H;
		control.InputViewControlX = P2RSX;
		control.InputViewControlY = P2RSY;
		control.InputIncrement = P2RB;
		control.InputDecrement = P2LB;
		control.InputTriggers = P2T;
		control.InputStart = P2ST;
		control.InputJump = P2A;
		control.InputDraw = P2B;
		control.InputDirectionalX = P2DX;
		control.InputDirectionalY = P2DY;
		control.InputCard4 = P2RC;
	}

	void SetInputsToPlayer3(GameObject player){
		Player control = player.GetComponent<Player> ();
		control.InputVertical = P3V;
		control.InputHorizontal = P3H;
		control.InputViewControlX = P3RSX;
		control.InputViewControlY = P3RSY;
		control.InputIncrement = P3RB;
		control.InputDecrement = P3LB;
		control.InputTriggers = P3T;
		control.InputStart = P3ST;
		control.InputJump = P3A;
		control.InputDraw = P3B;
		control.InputDirectionalX = P3DX;
		control.InputDirectionalY = P3DY;
		control.InputCard4 = P3RC;
	}

	void SetInputsToPlayer4(GameObject player){
		Player control = player.GetComponent<Player> ();
		control.InputVertical = P4V;
		control.InputHorizontal = P4H;
		control.InputViewControlX = P4RSX;
		control.InputViewControlY = P4RSY;
		control.InputIncrement = P4RB;
		control.InputDecrement = P4LB;
		control.InputTriggers = P4T;
		control.InputStart = P4ST;
		control.InputJump = P4A;
		control.InputDraw = P4B;
		control.InputDirectionalX = P4DX;
		control.InputDirectionalY = P4DY;
		control.InputCard4 = P4RC;
	}

	void CreatePlayers(int numberOfPlayers){
		for (int i = 0; i < numberOfPlayers; i++) {
			GameObject currentPlayer;
			GameObject newcanvas;
			switch (i){
			case 0:
				currentPlayer = (GameObject) Instantiate(PlayerPrefab, P1Spawn.transform.position, P1Spawn.transform.rotation);
				SetInputsToPlayer1(currentPlayer);

				if(numberOfPlayers == 2){
					currentPlayer.GetComponentInChildren<Camera>().rect = new Rect(0,0, 0.5f, 1);
				}else if(numberOfPlayers == 1){
					currentPlayer.GetComponentInChildren<Camera>().rect = new Rect(0,0, 1, 1);
				}else{
					currentPlayer.GetComponentInChildren<Camera>().rect = new Rect(0,0, 0.5f, 0.5f);
				}
				newcanvas = (GameObject) Instantiate(CanvasPrefab, Vector3.zero, Quaternion.identity);
				newcanvas.GetComponent<Canvas>().worldCamera = currentPlayer.GetComponentInChildren<Camera>();
				newcanvas.GetComponent<CardUIController>().InitializeUIController(currentPlayer);
				break;
			case 1:
				currentPlayer =  (GameObject) Instantiate(PlayerPrefab, P2Spawn.transform.position, P2Spawn.transform.rotation);
				SetInputsToPlayer2(currentPlayer);
				if(numberOfPlayers == 2){
					currentPlayer.GetComponentInChildren<Camera>().rect = new Rect(0.5f,0, 0.5f, 1);
				}else{
					currentPlayer.GetComponentInChildren<Camera>().rect = new Rect(0.5f,0, 0.5f, 0.5f);
				}
				newcanvas = (GameObject) Instantiate(CanvasPrefab, Vector3.zero, Quaternion.identity);
				newcanvas.GetComponent<Canvas>().worldCamera = currentPlayer.GetComponentInChildren<Camera>();
				newcanvas.GetComponent<CardUIController>().InitializeUIController(currentPlayer);
				break;
			case 2:
				currentPlayer =  (GameObject) Instantiate(PlayerPrefab, P3Spawn.transform.position, P3Spawn.transform.rotation);
				SetInputsToPlayer3(currentPlayer);
				if(numberOfPlayers == 2){
					currentPlayer.GetComponent<Camera>().rect = new Rect(0,0.5f, 0.5f, 0.5f);
				}else{
					currentPlayer.GetComponent<Camera>().rect = new Rect(0,0.5f, 0.5f, 0.5f);
				}
				newcanvas = (GameObject) Instantiate(CanvasPrefab, Vector3.zero, Quaternion.identity);
				newcanvas.GetComponent<Canvas>().worldCamera = currentPlayer.GetComponentInChildren<Camera>();
				break;
			case 3:
				currentPlayer =  (GameObject) Instantiate(PlayerPrefab, P4Spawn.transform.position, P4Spawn.transform.rotation);
				SetInputsToPlayer4(currentPlayer);
				if(numberOfPlayers == 2){
					currentPlayer.GetComponent<Camera>().rect = new Rect(0.5f,0.5f, 0.5f, 0.5f);
				}else{
					currentPlayer.GetComponent<Camera>().rect = new Rect(0.5f,0.5f, 0.5f, 0.5f);
				}
				newcanvas = (GameObject) Instantiate(CanvasPrefab, Vector3.zero, Quaternion.identity);
				newcanvas.GetComponent<Canvas>().worldCamera = currentPlayer.GetComponentInChildren<Camera>();
				break;
			}
		}
	}

	void Awake(){
		CreatePlayers (2);
	}
}
