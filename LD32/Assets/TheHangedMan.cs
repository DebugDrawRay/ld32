using UnityEngine;
using System.Collections;

public class TheHangedMan : UsableCard {
	
	public GameObject pillar;
	public float frontOffset;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void UseCard(GameObject user) {
		GameObject sun = (GameObject) Instantiate (pillar, user.transform.position + (user.transform.forward * frontOffset), user.transform.rotation);
		sun.GetComponent<InstantDamge> ().enemyTag = user.GetComponent<Player> ().enemyTag;
	}
}
