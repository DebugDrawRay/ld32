using UnityEngine;
using System.Collections;

public class EnemyChaseBird : MonoBehaviour {
	public float activateRange;
	public bool activated;

	public float maxRangeForShoot;
	public float shootAquireTime;
	public float currentShootAquireTime;

	public GameObject projectile;

	public float targetChangeTime;
	public float currentChangeTime;
	public float targetRange;
	public float curX;
	public float curZ;

	public float baseH;
	public float bobRate;
	public float valueToS;

	public float movementSpeed;

	public Vector3 target;
	public Transform playerT;

	public bool stunned;
	public float stunTime;
	
	public float moveNerf;
	public float moveNerfTime;
	
	public bool reversed;
	public float reversedTime;
	
	public bool confused;
	public float confuseTime;

	int wallMask = 1 << 10;

	void Start () {
		//target = playerT.position;
		target = transform.position;
	}

	// Update is called once per frame
	void Update () {
		GetComponent<NavMeshAgent> ().SetDestination (target);

		if (stunTime <= 0f) {
			stunned = false;
		} else {
			stunTime -= Time.deltaTime;
		}
		
		if (moveNerfTime <= 0f) {//
			moveNerf = 0f;
		} else {
			moveNerfTime -= Time.deltaTime;
		}
		
		if (reversedTime <= 0f) {
			reversed = false;
		} else {
			reversedTime -= Time.deltaTime;
		}

		if (confuseTime <= 0) {//
			confused = false;
		} else {
			confuseTime -= Time.deltaTime;
		}


		valueToS = valueToS + Time.deltaTime * bobRate;

		if (valueToS > 3600f) {
			valueToS = 0f;
		}

		gameObject.GetComponent<NavMeshAgent> ().baseOffset = baseH + Mathf.Sin (valueToS * Mathf.PI / 180f);

		if (!activated) {
			Vector3 distToP = playerT.position - transform.position;
			float disP = distToP.magnitude;

			if(disP < activateRange) {
				if(Physics.Raycast(transform.position, distToP, disP, wallMask)) {

				} else {
					activated = true;
				}
			}

		} else {
			if (currentChangeTime > targetChangeTime) {
				curX = Random.Range (-targetRange, targetRange);
				curZ = Random.Range (-targetRange, targetRange);

				currentChangeTime = 0;
			} else {
				currentChangeTime += Time.deltaTime;
			}

			if (Mathf.Abs (target.x - transform.position.x) < 0.5 && Mathf.Abs (target.z - transform.position.z) < 0.5) {
				curX = Random.Range (-targetRange, targetRange);
				curZ = Random.Range (-targetRange, targetRange);
			
				currentChangeTime = 0;
			}

			target = new Vector3 (playerT.transform.position.x + curX, playerT.transform.position.y, playerT.transform.position.z + curZ);

			//first we get the distance
			Vector3 disPlay = playerT.position - transform.position;
			float distToPlayer = disPlay.magnitude;

			if (distToPlayer < maxRangeForShoot) {
				currentShootAquireTime += Time.deltaTime;

				if (currentShootAquireTime > shootAquireTime) {
					//shoot
					if (confused) {
						gameObject.GetComponent<Health> ().changeHealth (-10);
					}

					GameObject bulle = (GameObject)Instantiate (projectile, transform.position, transform.rotation);
					Physics.IgnoreCollision (bulle.GetComponent<Collider> (), gameObject.GetComponent<Collider> ());

					Vector3 bullmove = playerT.position - transform.position;

					bullmove = bullmove.normalized;

					bulle.GetComponent<BirdBullet> ().direct = bullmove;

					currentShootAquireTime = 0;
				}
			}

			GetComponent<NavMeshAgent> ().SetDestination (target);

			GetComponent<NavMeshAgent> ().speed *= (movementSpeed - moveNerf);

			if (reversed) {
				GetComponent<NavMeshAgent> ().speed = -GetComponent<NavMeshAgent> ().speed;
			}
		
			if (stunned) {
				GetComponent<NavMeshAgent> ().speed = 0f;
			}
		}
	}
}
