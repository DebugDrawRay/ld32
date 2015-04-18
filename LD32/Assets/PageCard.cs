using UnityEngine;
using System.Collections;

public class PageCard : UsableCard {
	
	public GameObject projectile;
	public float fireDelay;
	public int fireAmount;

	bool isFiring;
	GameObject theUser;
	float currentCount;
	int bulletsFired;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*if (isFiring) {
			if(currentCount <= 0) {
				if(bulletsFired < fireAmount) {
					GameObject bullet = (GameObject) Instantiate(projectile, theUser.GetComponent<Player>().playCam.transform.position, theUser.GetComponent<Player>().playCam.transform.rotation);
					bullet.GetComponent<Projectile>().fire();
					bulletsFired++;
					currentCount = fireDelay;
				} else {
					isFiring = false;
				}
			} else {
				currentCount -= Time.deltaTime;
			}
		}*/
	}
	
	public override void UseCard(GameObject user) {
		GameObject bullet = (GameObject) Instantiate(projectile, user.GetComponent<Player>().playCam.transform.position, user.GetComponent<Player>().playCam.transform.rotation);
		bullet.GetComponent<Projectile> ().user = user;
		bullet.GetComponent<Projectile> ().fireDelay = fireDelay;
		bullet.GetComponent<Projectile> ().fireAmount = fireAmount;
		bullet.GetComponent<Projectile> ().isPage = true;

		bullet.GetComponent<Projectile>().fire();

		//currentCount = fireDelay;
		//isFiring = true;
		//bulletsFired = 1;

		//theUser = user;
	}
	
}

