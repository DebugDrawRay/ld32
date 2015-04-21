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
		GameObject sun = (GameObject) Instantiate (pillar, user.transform.position + (user.transform.forward * frontOffset), user.transform.rotation);
		Physics.IgnoreCollision(sun.GetComponent<Collider>(), user.GetComponent<Collider>());

		if (user.GetComponent<Player> () != null) {
			sun.GetComponent<DamageArea> ().enemyTag = user.GetComponent<Player> ().enemyTag;
		}
		if (user.GetComponent<PlayerMulti> () != null) {
			sun.GetComponent<DamageArea> ().enemyTag = user.GetComponent<PlayerMulti> ().enemyTag;
			sun.GetComponent<DamageArea> ().ownerNum = user.GetComponent<PlayerMulti> ().playerNumber;
		}


	}
}
