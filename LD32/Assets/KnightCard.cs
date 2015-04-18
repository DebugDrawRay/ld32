using UnityEngine;
using System.Collections;

public class KnightCard : UsableCard {
	
	public GameObject projectile;
	public float knockUp;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void UseCard(GameObject user) {
		GameObject bullet = (GameObject) Instantiate(projectile, user.GetComponent<Player>().playCam.transform.position, user.GetComponent<Player>().playCam.transform.rotation);
		bullet.GetComponent<Projectile> ().upKnock = true;
		bullet.GetComponent<Projectile> ().upKnockForce = knockUp;
		bullet.GetComponent<Projectile>().fire();
	}
	
}

