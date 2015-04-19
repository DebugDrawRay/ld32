using UnityEngine;
using System.Collections;

public class EnemyChase : MonoBehaviour {
	public Transform target;

	// Update is called once per frame
	void Update () {
		GetComponent<NavMeshAgent> ().SetDestination (target.position);
	}
}
