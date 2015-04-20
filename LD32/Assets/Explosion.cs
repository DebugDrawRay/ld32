using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public float lifeTime;
	public string enemyTag;
	public float damage;
	public float knockBack;

	public bool upKnock;
	public float upKnockForce;

	public bool slows;
	public float slowPercent;
	public float slowTime;
	public bool stuns;
	public float stunTime;

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

			if(enemyTag == "Player") {
				other.gameObject.GetComponent<Player>().knockback += knockDir * knockBack;
			} else {
				other.gameObject.GetComponent<Rigidbody>().AddForce(knockDir * knockBack);
			}

			if(upKnock) {
				Vector3 knockDir2 = Vector3.up;
				other.gameObject.GetComponent<Rigidbody>().AddForce(knockDir2 * upKnockForce);

				if(enemyTag == "Player") {
					other.gameObject.GetComponent<Player>().knockback += knockDir2 * upKnockForce;
				} else {
					other.gameObject.GetComponent<Rigidbody>().AddForce(knockDir2 * upKnockForce);
				}
			}

			if(stuns) {
				if(other.gameObject.GetComponent<RunMan>() != null) {
					other.gameObject.GetComponent<RunMan>().stunned = true;
					other.gameObject.GetComponent<RunMan>().stunTime = stunTime;
				}
				
				if(other.gameObject.GetComponent<Player>() != null) {
					other.gameObject.GetComponent<Player>().stunned = true;
					other.gameObject.GetComponent<Player>().stunTime = stunTime;
				}
			}
			
			if(slows) {
				if(other.gameObject.GetComponent<RunMan>() != null) {
					other.gameObject.GetComponent<RunMan>().moveNerf = slowPercent;
					other.gameObject.GetComponent<RunMan>().moveNerfTime = slowTime;
				}
				
				if(other.gameObject.GetComponent<Player>() != null) {
					other.gameObject.GetComponent<Player>().moveNerf = slowPercent;
					other.gameObject.GetComponent<Player>().moveNerfTime = slowTime;
				}
			}

		}
	}

}
