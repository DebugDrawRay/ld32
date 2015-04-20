using UnityEngine;
using System.Collections;

public class EnemyChaseBird : MonoBehaviour {
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

	public Vector3 target;
	public Transform playerT;
	

	void Start () {
		target = playerT.position;
	}

	// Update is called once per frame
	void Update () {

		valueToS = valueToS + Time.deltaTime * bobRate;

		if (valueToS > 3600f) {
			valueToS = 0f;
		}

		gameObject.GetComponent<NavMeshAgent> ().baseOffset = baseH + Mathf.Sin (valueToS * Mathf.PI / 180f);

		if (currentChangeTime > targetChangeTime) {
			curX = Random.Range(-targetRange, targetRange);
			curZ = Random.Range(-targetRange, targetRange);

			currentChangeTime = 0;
		} else {
			currentChangeTime += Time.deltaTime;
		}

		if (Mathf.Abs (target.x - transform.position.x) < 0.1 && Mathf.Abs (target.z - transform.position.z) < 0.1) {
			curX = Random.Range(-targetRange, targetRange);
			curZ = Random.Range(-targetRange, targetRange);
			
			currentChangeTime = 0;
		}

		target = new Vector3 (playerT.transform.position.x + curX, playerT.transform.position.y, playerT.transform.position.z + curZ);

		//first we get the distance
		Vector3 disPlay = playerT.position - transform.position;
		float distToPlayer = disPlay.magnitude;

		if (distToPlayer < maxRangeForShoot) {
			currentShootAquireTime += Time.deltaTime;

			if(currentShootAquireTime > shootAquireTime) {
				//shoot
				GameObject bulle = (GameObject) Instantiate(projectile, transform.position, transform.rotation);
				Vector3 bullmove = playerT.position - transform.position;

				bullmove = bullmove.normalized;

				bulle.GetComponent<BirdBullet>().direct = bullmove;

				currentShootAquireTime = 0;
			}
		}

		GetComponent<NavMeshAgent> ().SetDestination (target);
	}
}
