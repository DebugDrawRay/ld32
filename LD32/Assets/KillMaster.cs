using UnityEngine;
using System.Collections;

public class KillMaster : MonoBehaviour {
	public int maxScore;

	public int scorePlayer1;
	public int scorePlayer2;
	public int scorePlayer3;
	public int scorePlayer4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (scorePlayer1 >= maxScore) {
			//player1 wins

		}
		if (scorePlayer2 >= maxScore) {
			//player2 wins
			
		}
		if (scorePlayer3 >= maxScore) {
			//player3 wins
			
		}
		if (scorePlayer4 >= maxScore) {
			//player4 wins
			
		}
	}
}
