using UnityEngine;
using System.Collections;

public class TheSun : UsableCard {

	public GameObject pillar;
	public float frontOffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void UseCard(GameObject user) {
		Instantiate (pillar, user.transform.position + (user.transform.forward * frontOffset), user.transform.rotation);
	}
}
