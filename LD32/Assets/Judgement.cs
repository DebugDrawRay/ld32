using UnityEngine;
using System.Collections;

public class Judgement : UsableCard {
	
	public GameObject shield;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void UseCard(GameObject user) {
		GameObject sun = (GameObject) Instantiate (shield, user.transform.position, user.transform.rotation);
		Physics.IgnoreCollision(sun.GetComponent<Collider>(), user.GetComponent<Collider>());
		if (user.GetComponent<Player>() != null) {
			sun.GetComponent<DamageArea> ().enemyTag = user.GetComponent<Player> ().enemyTag;
		}
		sun.transform.parent = user.transform;

		if (user.GetComponent<PlayerMulti> () != null) {
			sun.GetComponent<DamageArea> ().ownerNum = user.GetComponent<PlayerMulti> ().playerNumber;
		}


	}
}
