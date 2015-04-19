using UnityEngine;
using System.Collections;

public class StunArea : MonoBehaviour {

	public string enemyTag;
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
			//stunenemy
			Destroy(gameObject);
		}
	}
}
