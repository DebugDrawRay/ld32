using UnityEngine;
using System.Collections;

public class BirdBullet : MonoBehaviour {
	public float speed;
	public float damageValue;

	public Vector3 direct;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Rigidbody> ().velocity = direct * speed * Time.deltaTime;
	}

	void OnTriggerEnter (Collider other){
		if (other.tag == "Player") {
			//if(confused) {
			//	gameObject.GetComponent<Health>().changeHealth(-10);
			//}
			
			other.GetComponent<Health>().changeHealth(-damageValue);
			Vector3 forceDir = other.transform.position - transform.position;
			forceDir.Normalize();
			forceDir = 100 * forceDir;
			other.GetComponent<Player>().knockback += new Vector3(forceDir.x, 0.5f, forceDir.z);
		}
	}
}
