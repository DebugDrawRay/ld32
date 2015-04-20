using UnityEngine;
using System.Collections;

public class StunArea : MonoBehaviour {

	public string enemyTag;
	public float lifeTime;
	public float stunTime;
	
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
			if(other.gameObject.GetComponent<RunMan>() != null) {
				other.gameObject.GetComponent<RunMan>().stunned = true;
				other.gameObject.GetComponent<RunMan>().stunTime = stunTime;
			}

			if(other.gameObject.GetComponent<EnemyChaseBird>() != null) {
				other.gameObject.GetComponent<EnemyChaseBird>().stunned = true;
				other.gameObject.GetComponent<EnemyChaseBird>().stunTime = stunTime;
			}

			if(other.gameObject.GetComponent<Player>() != null) {
				other.gameObject.GetComponent<Player>().stunned = true;
				other.gameObject.GetComponent<Player>().stunTime = stunTime;
			}

			if(other.gameObject.GetComponent<PlayerMulti>() != null) {
				other.gameObject.GetComponent<PlayerMulti>().stunned = true;
				other.gameObject.GetComponent<PlayerMulti>().stunTime = stunTime;
			}

			Destroy(gameObject);
		}
	}
}
