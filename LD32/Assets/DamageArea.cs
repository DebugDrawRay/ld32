using UnityEngine;
using System.Collections;

public class DamageArea : MonoBehaviour {

	public string enemyTag;
	public float damage;
	public float lifeTime;
	public int ownerNum;

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

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == enemyTag) {
			other.GetComponent<Health>().changeHealth(-damage * Time.deltaTime);

			if(other.GetComponent<PlayerMulti>() != null) {
				other.GetComponent<PlayerMulti>().lastDamageFrom = ownerNum;
			}
		}
	}

}
