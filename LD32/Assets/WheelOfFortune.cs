using UnityEngine;
using System.Collections;

public class WheelOfFortune : UsableCard {
	//chance to stun you
	//tower and empress
	//make it rain
	//four suns
	//four moons
	//jackshit


	public float stunTime;

	public float boostAmount;
	public float boostTime;

	public float jboostAmount;
	public float jboostTime;

	public GameObject rainer;

	public GameObject spillar;
	public float sfrontOffset;

	public GameObject mun;
	public float mfrontOffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public override void UseCard(GameObject user) {
		int choice = Random.Range (0, 100);

		if (choice < 10) {
			user.gameObject.GetComponent<Player>().stunned = true;
			user.gameObject.GetComponent<Player>().stunTime = stunTime;

		} else if (choice < 20) {
			user.GetComponent<Player> ().moveBoost = boostAmount;
			user.GetComponent<Player> ().moveBoostTime = boostTime;

			user.GetComponent<Player> ().jumpBoost = jboostAmount;
			user.GetComponent<Player> ().jumpBoostTime = jboostTime;

		} else if (choice < 30) {
			rainer.GetComponent<UsableCard>().UseCard(user);

		} else if (choice < 40) {
			GameObject sun = (GameObject) Instantiate (spillar, user.transform.position + (user.transform.forward * sfrontOffset), user.transform.rotation);
			Physics.IgnoreCollision(sun.GetComponent<Collider>(), user.GetComponent<Collider>());
			
			sun.GetComponent<DamageArea> ().enemyTag = user.GetComponent<Player> ().enemyTag;

			GameObject sun2 = (GameObject) Instantiate (spillar, user.transform.position + (-user.transform.forward * sfrontOffset), user.transform.rotation);
			Physics.IgnoreCollision(sun2.GetComponent<Collider>(), user.GetComponent<Collider>());
			
			sun2.GetComponent<DamageArea> ().enemyTag = user.GetComponent<Player> ().enemyTag;

			GameObject sun3 = (GameObject) Instantiate (spillar, user.transform.position + (user.transform.right * sfrontOffset), user.transform.rotation);
			Physics.IgnoreCollision(sun3.GetComponent<Collider>(), user.GetComponent<Collider>());
			
			sun3.GetComponent<DamageArea> ().enemyTag = user.GetComponent<Player> ().enemyTag;

			GameObject sun4 = (GameObject) Instantiate (spillar, user.transform.position + (-user.transform.right * sfrontOffset), user.transform.rotation);
			Physics.IgnoreCollision(sun4.GetComponent<Collider>(), user.GetComponent<Collider>());
			
			sun4.GetComponent<DamageArea> ().enemyTag = user.GetComponent<Player> ().enemyTag;

			if (user.GetComponent<PlayerMulti> () != null) {
				sun.GetComponent<DamageArea> ().ownerNum = user.GetComponent<PlayerMulti> ().playerNumber;
				sun2.GetComponent<DamageArea> ().ownerNum = user.GetComponent<PlayerMulti> ().playerNumber;
				sun3.GetComponent<DamageArea> ().ownerNum = user.GetComponent<PlayerMulti> ().playerNumber;
				sun4.GetComponent<DamageArea> ().ownerNum = user.GetComponent<PlayerMulti> ().playerNumber;
			}


		} else if (choice < 50) {
			Instantiate (mun, user.transform.position + (user.transform.forward * mfrontOffset), user.transform.rotation);

			Instantiate (mun, user.transform.position + (-user.transform.forward * mfrontOffset), user.transform.rotation);

			Instantiate (mun, user.transform.position + (user.transform.right * mfrontOffset), user.transform.rotation);

			Instantiate (mun, user.transform.position + (-user.transform.right * mfrontOffset), user.transform.rotation);


		} else if (choice < 101) {
			//jackShit
		}
		
		
	}
}
