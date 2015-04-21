using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KillMaster : MonoBehaviour {
	public int maxScore;

	public int scorePlayer1;
	public int scorePlayer2;
	public int scorePlayer3;
	public int scorePlayer4;

	public Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (scorePlayer1 >= maxScore) {
			//player1 wins
			text.text = "Player 1 has proved himself" + "\n" + "to be the greatest.";

		} else if (scorePlayer2 >= maxScore) {
			//player2 wins
			text.text = "Player 2 has proved himself" + "\n" + "to be the greatest.";
			
		} else if (scorePlayer3 >= maxScore) {
			//player3 wins
			text.text = "Player 3 has proved himself" + "\n" + "to be the greatest.";
			
		} else if (scorePlayer4 >= maxScore) {
			//player4 wins
			text.text = "Player 4 has proved himself" + "\n" + "to be the greatest.";

		} else {
			text.text = "P1: " + scorePlayer1 + "\n" + "P2: " + scorePlayer2+ "\n" + "P3: " + scorePlayer3+ "\n" + "P4: " + scorePlayer4;
		}
	}
}
