using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * This class is for general projectiles. It includes many fields
 * to help make fast custom projectiles to be used by skills.
 */


public class Projectile : MonoBehaviour {
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
	
	public List<string> statusEffects = new List<string>(); //this here tells the projectile what effects to 
	//apply. for now its just a list of stings because im not sure how effects will work
	
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
				}
			} else {
				Destroy (gameObject);
			}
		} else {
			if (coll.gameObject.tag == enemyTag) {
				//coll.gameObject.GetComponent<EnemyBase>().ApplyLifeChange(-1 * damage);
				coll.gameObject.GetComponent<Health>().changeHealth(-damage);

				Vector3 knockDir = coll.gameObject.transform.position - gameObject.transform.position;
				knockDir = knockDir.normalized;
				coll.gameObject.GetComponent<Rigidbody>().AddForce(knockDir * knockBack);
			}

			Destroy (gameObject);
		}
		
	}
	
	public void fire() {
		if (isBalistic) {
			//gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * balisticImpulse);
			gameObject.transform.position = gameObject.transform.position + transform.forward * 1f;
		}

		if (shotgun) {
			for(int i = 0; i < spreadAmount; i++) {
				GameObject bullet = (GameObject) Instantiate(this.gameObject, transform.position, transform.rotation);
				bullet.GetComponent<Projectile>().shotgun = false;

				float arr = Random.Range(0f, spreadAngle);
				float theta = Random.Range(0f, 360f);

				float ranY = arr * Mathf.Sin(theta * Mathf.PI / 180f);
				float ranX = arr * Mathf.Cos(theta * Mathf.PI / 180f);

				//float shake = ranY;
				//float shake = (-1.0f * spreadAngle) + (((2.0f * spreadAngle) / (1.0f * spreadAmount)) * (i + 0.5f));
				//bullet.transform.localEulerAngles = new Vector3(bullet.transform.localEulerAngles.x, bullet.transform.localEulerAngles.y + shake, bullet.transform.localEulerAngles.z);

				bullet.transform.RotateAround(transform.position, transform.up, ranY);
				bullet.transform.RotateAround(transform.position, transform.right, ranX);

				bullet.GetComponent<Projectile>().fire();
			}
			Destroy(gameObject);
		}

		if (wave) {
			for(int i = 0; i < spreadAmount; i++) {
				GameObject bullet = (GameObject) Instantiate(this.gameObject, transform.position, transform.rotation);
				bullet.GetComponent<Projectile>().wave = false;
				bullet.GetComponent<Projectile>().isWave = true;
				bullet.GetComponent<Projectile>().life = life - 0.1f;
				bullet.GetComponent<Projectile>().parentWave = gameObject;


				float shake = (-1.0f * spreadAngle) + (((2.0f * spreadAngle) / (1.0f * spreadAmount)) * (i + 0.5f));

				bullet.transform.RotateAround(transform.position, transform.up, shake);

				
				bullet.GetComponent<Projectile>().fire();
			}

			gameObject.GetComponent<SphereCollider>().enabled = false;
			gameObject.GetComponent<MeshRenderer>().enabled = false;

			//Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(life > 0f) {
			life = life - 1.0f * Time.deltaTime;
			//transform.Translate(transform.forward * 1.0f * Time.deltaTime * velocity);
		
			
			Vector3 fMove = transform.forward * 1f;

			if(isBalistic) {
				//fMove = new Vector3(fMove.x, gameObject.GetComponent<Rigidbody> ().velocity.y, fMove.z);
				Vector3 dMove = Vector3.up * 1f * balisticImpulse;
				fMove = fMove + dMove;
				balisticImpulse -= gravityAmount * Time.deltaTime;
			}
			
			gameObject.GetComponent<Rigidbody> ().velocity = fMove * velocity;
		} else {
			Destroy(gameObject);
		}

		if (wave) {
			//transform.localScale = new Vector3(transform.localScale.x + expandRate * Time.deltaTime, transform.localScale.y, transform.localScale.z);
		}

		if (homing) {
			GameObject target = FindClosestEnemy ();



			if(target != null) {
				Vector3 aVect = transform.forward;
				Vector3 bVect = target.transform.position - transform.position;

				Vector3 cross = new Vector3(aVect.y * bVect.z - aVect.z * bVect.y, aVect.z * bVect.x - aVect.x * bVect.z, aVect.x * bVect.y - aVect.y * bVect.x);
					
				gameObject.transform.RotateAround(transform.position, cross, homeForce * Time.deltaTime);



				
				
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


