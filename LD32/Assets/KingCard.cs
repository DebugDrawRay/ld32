using UnityEngine;
using System.Collections;

public class KingCard : UsableCard {
	
	public GameObject projectile;
	public float stunTime;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void UseCard(GameObject user) {
		GameObject bullet = (GameObject) Instantiate(projectile, user.GetComponent<Player>().playCam.transform.position, user.GetComponent<Player>().playCam.transform.rotation);
		bullet.GetComponent<Projectile> ().stuns = true;
		bullet.GetComponent<Projectile> ().stunTime = stunTime;

		bullet.GetComponent<Projectile>().fire();
	}
	
}
