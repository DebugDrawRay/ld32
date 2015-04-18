using UnityEngine;
using System.Collections;

public class QueenCard : UsableCard {
	
	public GameObject projectile;
	public float slowPercent;
	public float slowTime;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void UseCard(GameObject user) {
		GameObject bullet = (GameObject) Instantiate(projectile, user.GetComponent<Player>().playCam.transform.position, user.GetComponent<Player>().playCam.transform.rotation);
		bullet.GetComponent<Projectile> ().slows = true;
		bullet.GetComponent<Projectile> ().slowPercent = slowPercent;
		bullet.GetComponent<Projectile> ().slowTime = slowTime;

		bullet.GetComponent<Projectile>().fire();
	}
	
}
