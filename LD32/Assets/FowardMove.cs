using UnityEngine;
using System.Collections;

public class FowardMove : MonoBehaviour {

	public float speed;
	public float lifeTime;

	void Start() {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("EnemyUnit");

		foreach (GameObject em in enemies) {
			if(em.GetComponent<EnemyChase>() != null) {
				em.GetComponent<EnemyChase>().target = transform;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (lifeTime <= 0) {
			GameObject[] enemies = GameObject.FindGameObjectsWithTag ("EnemyUnit");

			foreach (GameObject em in enemies) {
				if(em.GetComponent<EnemyChase>() != null) {
					em.GetComponent<EnemyChase>().target = GameObject.Find("Player").transform;
				}
			}

			Destroy (gameObject);
		} else {
			lifeTime -= Time.deltaTime;
		}

		gameObject.GetComponent<Rigidbody> ().velocity = transform.forward * speed;
	
	}
}
