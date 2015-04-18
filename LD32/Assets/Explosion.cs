using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public float lifeTime;
	public string enemyTag;
	public float damage;
	public float knockBack;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		lifeTime -= Time.deltaTime * 1f;

		if (lifeTime < 0) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == enemyTag) {
			other.gameObject.GetComponent<Health>().changeHealth(-damage);

			Vector3 knockDir = other.gameObject.transform.position - gameObject.transform.position;
			knockDir = knockDir.normalized;
			
			other.gameObject.GetComponent<Rigidbody>().AddForce(knockDir * knockBack);
		}
	}

}
