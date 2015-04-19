using UnityEngine;
using System.Collections;

public class InstantDamge : MonoBehaviour {

	public string enemyTag;
	public float damage;
	public float lifeTime;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (lifeTime <= 0) {
			Destroy (gameObject);
		} else {
			lifeTime -= Time.deltaTime;
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == enemyTag) {
			other.GetComponent<Health>().changeHealth(-damage * Time.deltaTime);
			Destroy(gameObject);
		}
	}
	
}
