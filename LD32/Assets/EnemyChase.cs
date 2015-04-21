using UnityEngine;
using System.Collections;

public class EnemyChase : MonoBehaviour {
	public float activateRange;
	public bool activated;

	int wallMask = 1 << 10;

	public Transform target;

	void Start () {
		//target = playerT.position;
		//target = null;
	}

	// Update is called once per frame
	void Update () {
		if (!activated) {
			Vector3 distToP = target.position - transform.position;
			float disP = distToP.magnitude;
			
			if (disP < activateRange) {
				if (Physics.Raycast (transform.position, distToP, disP, wallMask)) {
					
				} else {
					activated = true;
				}
			}
			
		} else {
			GetComponent<NavMeshAgent> ().SetDestination (target.position);
		}

	}
}
