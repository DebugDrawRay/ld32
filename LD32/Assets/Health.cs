using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float health;
	public bool invul;
	public float invulTime;

	public bool burning;
	public float burnDamage;
	public float burnTime;

	public void changeHealth(float change) {
		if (gameObject.GetComponent<Player>() != null) {
			if(change < 0) {
				change += gameObject.GetComponent<Player>().defenseBoost;
				if(change > 0) {
					change = 0;
				}
			}
		}

		if (!invul || change > 0) {
			health += change;
		}
	}

	public void killEntity(){
		health = 0;
		//other stuff as necessary.
	}

    public float getHealth()
    {
        return health;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (invulTime <= 0f) {
			invul = false;
		} else {
			invulTime -= Time.deltaTime;
		}

		if (burnTime <= 0f) {
			burning = false;
		} else {
			burnTime -= Time.deltaTime;
		}

		if (burning) {
			changeHealth(-burnDamage * Time.deltaTime);
		}

		if (health <= 0f) {
			Destroy(gameObject);
		}
	}
}
