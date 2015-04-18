using UnityEngine;
using System.Collections;

public class ProjectileCard : UsableCard {

	public GameObject projectile;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void UseCard(GameObject user) {
		GameObject bullet = (GameObject) Instantiate(projectile, user.GetComponent<Player>().playCam.transform.position, user.GetComponent<Player>().playCam.transform.rotation);
		bullet.GetComponent<Projectile>().fire();
	}

}
