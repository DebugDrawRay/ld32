using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * This class is for general projectiles. It includes many fields
 * to help make fast custom projectiles to be used by skills.
 */


public class Projectile : MonoBehaviour {
	public string matName;


	public bool setOnFire;
	public float fireDamage;
	public float fireTime;

	public bool teleport;

	//the fields are public so they can be changed in editor
	
	//team vars
	public string enemyTag;
	
	//basic vars
	public float life;
	public float velocity;
	public float damage;
	public float knockBack;

	public bool isBalistic; //not sure this is needed. I think if we add grav we'll get it anyway
	public float balisticImpulse;
	public float gravityAmount;
	
	//public List<string> statusEffects = new List<string>(); //this here tells the projectile what effects to 
	//apply. for now its just a list of stings because im not sure how effects will work
	public bool slows;
	public float slowPercent;
	public float slowTime;
	public bool stuns;
	public float stunTime;

	
	//for shotgun effects.
	public bool shotgun;
	public bool wave;
	public int spreadAmount;
	public float spreadAngle;

	//for wave effects
	//public bool wave;
	//public float expandRate;
	
	//for explosive effects
	public bool explosive;
	//public int exMag; //number of fragments
	//public GameObject frag; //what each fragment is
	public float radius; //not implimented yet. this is for an area explosion.
	public float explosionDamage;
	public float explosionKnock;
	//probably need other fields like damage, effect, ect.
	
	//for homing effects
	public bool homing;
	public float homeDistance; //distance to see target and start homing
	public float homeForce;
	public float homeAngle; //angle to see target and start homing (cone in front)
	public float closeAngleFixed; //the rate at witch the projectile can turn
	public GameObject closest; //don't change, this is just here for testing
	int wallMask = 1 << 12; //this mask is used in the raycast that checks if the projectile
	//can see the target

	public bool isWave;
	public GameObject parentWave;
	public List<GameObject> enemiesHit = new List<GameObject>();

	public bool isPage;
	public float fireDelay;
	public int fireAmount;
	public GameObject user;

	bool isFiring;
	GameObject theUser;
	float currentCount;
	int bulletsFired;

	public bool upKnock;
	public float upKnockForce;

	// Use this for initialization
	void Start () {
		
	}

	public GameObject explosion;

	//Assuming projectiles have colliders and are not triggers
	void OnTriggerEnter(Collider coll) {
		if(explosive) {
			/*GameObject[] ems = GameObject.FindGameObjectsWithTag(enemyTag);

			foreach(GameObject enemy in ems) {
				if(Mathf.Pow((Mathf.Pow((enemy.transform.position.x - transform.position.x), 2f) + Mathf.Pow((enemy.transform.position.y - transform.position.y), 2f) + Mathf.Pow((enemy.transform.position.z - transform.position.z), 2f)), 0.5f) < radius) {
					enemy.GetComponent<Health>().changeHealth(-damage);
				}
			}*/

			GameObject spl = (GameObject) Instantiate(explosion, transform.position, transform.rotation);
			spl.transform.localScale = new Vector3(radius, radius, radius);

			spl.GetComponent<Explosion>().damage = explosionDamage;
			spl.GetComponent<Explosion>().enemyTag = enemyTag;
			spl.GetComponent<Explosion>().knockBack = explosionKnock;

			spl.GetComponent<Explosion>().upKnock = upKnock;
			spl.GetComponent<Explosion>().upKnockForce = upKnockForce;

		}


		if (isWave) {
			if(coll.gameObject.tag == enemyTag) {
				if(parentWave.GetComponent<Projectile>().enemiesHit.Contains(coll.gameObject)) {

				} else {
					parentWave.GetComponent<Projectile>().enemiesHit.Add(coll.gameObject);
					coll.gameObject.GetComponent<Health>().changeHealth(-damage);

					Vector3 knockDir = coll.gameObject.transform.position - gameObject.transform.position;
					knockDir = knockDir.normalized;
					coll.gameObject.GetComponent<Rigidbody>().AddForce(knockDir * knockBack);

					if(upKnock && !explosive) {
						Vector3 knockDir2 = Vector3.up;
						coll.gameObject.GetComponent<Rigidbody>().AddForce(knockDir2 * upKnockForce);
					}
				}
			} else {
				Destroy (gameObject);
			}
		} else {
			if (coll.gameObject.tag == enemyTag) {
				//this is only here for now
				if(setOnFire) {
					coll.gameObject.GetComponent<Health>().burning = true;
					coll.gameObject.GetComponent<Health>().burnDamage = fireDamage;
					coll.gameObject.GetComponent<Health>().burnTime = fireTime;
				}

				//coll.gameObject.GetComponent<EnemyBase>().ApplyLifeChange(-1 * damage);
				coll.gameObject.GetComponent<Health>().changeHealth(-damage);

				Vector3 knockDir = coll.gameObject.transform.position - gameObject.transform.position;
				knockDir = knockDir.normalized;
				coll.gameObject.GetComponent<Rigidbody>().AddForce(knockDir * knockBack);

				if(upKnock && !explosive) {
					Vector3 knockDir2 = Vector3.up;
					coll.gameObject.GetComponent<Rigidbody>().AddForce(knockDir2 * upKnockForce);
				}
			}

			if(teleport) {
				user.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
			}

			Destroy (gameObject);
		}
		
	}
	
	public void fire() {

		if (matName != "the-chariot") {
			transform.GetComponentInChildren<MeshRenderer> ().material = (Material) Resources.Load ("3D/" + matName);
		}


		if (isPage) {
			gameObject.GetComponent<SphereCollider> ().enabled = false;

			gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;

			//gameObject.GetComponent<MeshRenderer> ().enabled = false;

			GameObject bullet = (GameObject)Instantiate (this.gameObject, new Vector3(user.GetComponent<Player>().playCam.transform.position.x, user.GetComponent<Player>().playCam.transform.position.y - 0.1f, user.GetComponent<Player>().playCam.transform.position.z), user.GetComponent<Player> ().playCam.transform.rotation);

			bullet.GetComponent<Projectile> ().isPage = false;
			bullet.GetComponent<SphereCollider> ().enabled = true;

			bullet.GetComponentInChildren<MeshRenderer>().enabled = true;
			//bullet.GetComponent<MeshRenderer> ().enabled = true;

			Physics.IgnoreCollision(bullet.GetComponent<Collider>(), user.GetComponent<Collider>());



			bullet.GetComponent<Projectile> ().fire ();
			
			currentCount = fireDelay;
			isFiring = true;
			bulletsFired = 1;
		} else {

			if (isBalistic) {
				//gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * balisticImpulse);
				gameObject.transform.position = gameObject.transform.position + transform.forward * 1f;
			}

			if (shotgun) {
				for (int i = 0; i < spreadAmount; i++) {
					GameObject bullet = (GameObject)Instantiate (this.gameObject, transform.position, transform.rotation);
					bullet.GetComponent<Projectile> ().shotgun = false;

					Physics.IgnoreCollision(bullet.GetComponent<Collider>(), user.GetComponent<Collider>());


					float arr = Random.Range (0f, spreadAngle);
					float theta = Random.Range (0f, 360f);

					float ranY = arr * Mathf.Sin (theta * Mathf.PI / 180f);
					float ranX = arr * Mathf.Cos (theta * Mathf.PI / 180f);

					//float shake = ranY;
					//float shake = (-1.0f * spreadAngle) + (((2.0f * spreadAngle) / (1.0f * spreadAmount)) * (i + 0.5f));
					//bullet.transform.localEulerAngles = new Vector3(bullet.transform.localEulerAngles.x, bullet.transform.localEulerAngles.y + shake, bullet.transform.localEulerAngles.z);

					bullet.transform.RotateAround (transform.position, transform.up, ranY);
					bullet.transform.RotateAround (transform.position, transform.right, ranX);

					bullet.GetComponent<Projectile> ().fire ();
				}
				Destroy (gameObject);
			}

			if (wave) {
				for (int i = 0; i < spreadAmount; i++) {
					GameObject bullet = (GameObject)Instantiate (this.gameObject, transform.position, transform.rotation);
					Physics.IgnoreCollision(bullet.GetComponent<Collider>(), user.GetComponent<Collider>());


					bullet.GetComponent<Projectile> ().wave = false;
					bullet.GetComponent<Projectile> ().isWave = true;
					bullet.GetComponent<Projectile> ().life = life - 0.1f;
					bullet.GetComponent<Projectile> ().parentWave = gameObject;


					float shake = (-1.0f * spreadAngle) + (((2.0f * spreadAngle) / (1.0f * spreadAmount)) * (i + 0.5f));

					bullet.transform.RotateAround (transform.position, transform.up, shake);

				
					bullet.GetComponent<Projectile> ().fire ();
				}

				gameObject.GetComponent<SphereCollider> ().enabled = false;

				gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
				//gameObject.GetComponent<MeshRenderer> ().enabled = false;

				//Destroy(gameObject);
			}
		}
	}

	/*IEnumerator rotateCard() {
		float elapsedTime;
		float maxTime;

		while (true) {


			if(elapsedTime > maxTime) {
				elapsedTime = 0;
			}

			yield return WaitForEndOfFrame();
		}
	}*/

	// Update is called once per frame
	void Update () {
		if (isFiring && isPage) {
			if (currentCount <= 0) {
				if (bulletsFired < fireAmount) {
					GameObject bullet = (GameObject)Instantiate (this.gameObject, new Vector3(user.GetComponent<Player>().playCam.transform.position.x, user.GetComponent<Player>().playCam.transform.position.y - 0.1f, user.GetComponent<Player>().playCam.transform.position.z), user.GetComponent<Player> ().playCam.transform.rotation);
					bullet.GetComponentInChildren<MeshRenderer> ().material = transform.GetComponentInChildren<MeshRenderer> ().material;

					bullet.GetComponent<Projectile> ().isPage = false;
					bullet.GetComponent<SphereCollider> ().enabled = true;

					bullet.GetComponentInChildren<MeshRenderer>().enabled = true;
					//bullet.GetComponent<MeshRenderer> ().enabled = true;

					Physics.IgnoreCollision(bullet.GetComponent<Collider>(), user.GetComponent<Collider>());

					bullet.GetComponent<Projectile> ().fire ();
					bulletsFired++;
					currentCount = fireDelay;
				} else {
					isFiring = false;
					Destroy (gameObject);
				}
			} else {
				currentCount -= Time.deltaTime;
			}
		} else {

			if (life > 0f) {
				life = life - 1.0f * Time.deltaTime;
				//transform.Translate(transform.forward * 1.0f * Time.deltaTime * velocity);
		
			
				Vector3 fMove = transform.forward * 1f;

				if (isBalistic) {
					//fMove = new Vector3(fMove.x, gameObject.GetComponent<Rigidbody> ().velocity.y, fMove.z);
					Vector3 dMove = Vector3.up * 1f * balisticImpulse;
					fMove = fMove + dMove;
					balisticImpulse -= gravityAmount * Time.deltaTime;
				}
			
				gameObject.GetComponent<Rigidbody> ().velocity = fMove * velocity;
			} else {
				Destroy (gameObject);
			}

			if (wave) {
				//transform.localScale = new Vector3(transform.localScale.x + expandRate * Time.deltaTime, transform.localScale.y, transform.localScale.z);
			}

			if (homing) {
				GameObject target = FindClosestEnemy ();



				if (target != null) {
					Vector3 aVect = transform.forward;
					Vector3 bVect = target.transform.position - transform.position;

					Vector3 cross = new Vector3 (aVect.y * bVect.z - aVect.z * bVect.y, aVect.z * bVect.x - aVect.x * bVect.z, aVect.x * bVect.y - aVect.y * bVect.x);
					
					gameObject.transform.RotateAround (transform.position, cross, homeForce * Time.deltaTime);



				
				
				}
			}
		}
		
		
		
	}
	
	//finds the closest enemy the projectile can see
	GameObject FindClosestEnemy (){
		// Find all game objects tagged to be enemies
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag(enemyTag); 
		//var closest : GameObject; 
		float distance = Mathf.Infinity; 
		closest = null; 
		
		
		// Iterate through them and find the closest one
		foreach (GameObject go in gos)  {
			//Fist check if its in the wedge where the projectile can see
			bool inSight = false;
			//Vector2 targetDir = go.transform.position - transform.position;
			//Vector2 forward = transform.up;
			//float angle = Vector3.Angle(targetDir, forward);
			
			
			//Debug.Log(angle);
			
			//if(Mathf.Abs(angle) < homeAngle) {
				inSight = true;
			//}
			
			//now check to see if there is anything in the way
			Vector3 diff = (go.transform.position - transform.position);
			float curDistance = diff.magnitude; 
			
			bool clear = true;
			//Debug.DrawRay(transform.position, (go.transform.position - transform.position) * 1, Color.red);
			
			//if(Physics2D.Raycast (transform.position, go.transform.position - transform.position, curDistance, wallMask)) {
				//clear = false;
			//}
			
			//if the current distance is less than the distance the projectile can see and the sightlines
			//are clear then we see if its a better option than the one we already have.
			if (curDistance < distance && curDistance < homeDistance && clear && inSight) {     
				closest = go; 
				distance = curDistance;
			}
			
		} 
		
		return closest;    
	}
}


