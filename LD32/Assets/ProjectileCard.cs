using UnityEngine;
using System.Collections;

public class ProjectileCard : UsableCard {

	public GameObject projectile;

	public bool pageCard;
	public float fireDelay;
	public int fireAmount;

	public bool knightCard;
	public float knockUp;

	public bool queenCard;
	//public bool slows;
	public float slowPercent;
	public float slowTime;

	public bool kingCard;
	//public bool stuns;
	public float stunTime;

	public bool setOnFire;
	public float fireDamage;
	public float fireTime;

	public bool teleport;


	//team vars
	public string enemyTag;
	
	//basic vars
	public float life;
	public float velocity;
	public float damage;
	public float knockBack;
	
	public bool isBalistic; //not sure this is needed. I think if we add grav we'll get it anyway
	public float balisticImpulse;
	public float gravityAmount;
	
	//public List<string> statusEffects = new List<string>(); //this here tells the projectile what effects to 
	//apply. for now its just a list of stings because im not sure how effects will work


	
	
	//for shotgun effects.
	public bool shotgun;
	public bool wave;
	public int spreadAmount;
	public float spreadAngle;
	
	//for explosive effects
	public bool explosive;
	//public int exMag; //number of fragments
	//public GameObject frag; //what each fragment is
	public float radius; //not implimented yet. this is for an area explosion.
	public float explosionDamage;
	public float explosionKnock;
	public GameObject explosion;
	//probably need other fields like damage, effect, ect.
	
	//for homing effects
	public bool homing;
	public float homeDistance; //distance to see target and start homing
	public float homeForce;
	//public float homeAngle; //angle to see target and start homing (cone in front)
	//public float closeAngleFixed; //the rate at witch the projectile can turn
	
	public bool isWave;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void UseCard(GameObject user) {
		GameObject bullet = (GameObject) Instantiate(projectile, user.GetComponent<Player>().playCam.transform.position, user.GetComponent<Player>().playCam.transform.rotation);
		Physics.IgnoreCollision(bullet.GetComponent<Collider>(), user.GetComponent<Collider>());
		bullet.GetComponent<Projectile> ().user = user;
		//team vars
		bullet.GetComponent<Projectile>().enemyTag = user.GetComponent<Player>().enemyTag;
		
		//basic vars
		bullet.GetComponent<Projectile>().life = life;
		bullet.GetComponent<Projectile>().velocity = velocity;
		bullet.GetComponent<Projectile>().damage = damage + user.GetComponent<Player>().damageBoost;
		bullet.GetComponent<Projectile>().knockBack = knockBack;
		
		bullet.GetComponent<Projectile>().isBalistic = isBalistic; //not sure this is needed. I think if we add grav we'll get it anyway
		bullet.GetComponent<Projectile>().balisticImpulse = balisticImpulse;
		bullet.GetComponent<Projectile>().gravityAmount = gravityAmount;
		
		//public List<string> statusEffects = new List<string>(); //this here tells the projectile what effects to 
		//apply. for now its just a list of stings because im not sure how effects will work
		bullet.GetComponent<Projectile>().slows = false;
		bullet.GetComponent<Projectile>().slowPercent = slowPercent;
		bullet.GetComponent<Projectile>().slowTime = slowTime;
		bullet.GetComponent<Projectile>().stuns = false;
		bullet.GetComponent<Projectile>().stunTime = stunTime;
		
		
		//for shotgun effects.
		bullet.GetComponent<Projectile>().shotgun = shotgun;
		bullet.GetComponent<Projectile>().wave = wave;
		bullet.GetComponent<Projectile>().spreadAmount = spreadAmount;
		bullet.GetComponent<Projectile>().spreadAngle = spreadAngle;
		
		//for explosive effects
		bullet.GetComponent<Projectile>().explosive = explosive;
		//public int exMag; //number of fragments
		//public GameObject frag; //what each fragment is
		bullet.GetComponent<Projectile>().radius = radius; //not implimented yet. this is for an area explosion.
		bullet.GetComponent<Projectile>().explosionDamage = explosionDamage + user.GetComponent<Player>().damageBoost;
		bullet.GetComponent<Projectile>().explosionKnock = explosionKnock;
		//probably need other fields like damage, effect, ect.
		
		//for homing effects
		bullet.GetComponent<Projectile>().homing = homing;
		bullet.GetComponent<Projectile>().homeDistance = homeDistance; //distance to see target and start homing
		bullet.GetComponent<Projectile>().homeForce = homeForce;
		//public float homeAngle; //angle to see target and start homing (cone in front)
		//public float closeAngleFixed; //the rate at witch the projectile can turn
		
		bullet.GetComponent<Projectile>().isWave = isWave;
		bullet.GetComponent<Projectile> ().explosion = explosion;

		bullet.GetComponent<Projectile> ().setOnFire = setOnFire;
		bullet.GetComponent<Projectile> ().fireDamage = fireDamage;
		bullet.GetComponent<Projectile> ().fireTime = fireTime;

		bullet.GetComponent<Projectile> ().teleport = teleport;

		if (pageCard) {
			bullet.GetComponent<Projectile> ().fireDelay = fireDelay;
			bullet.GetComponent<Projectile> ().fireAmount = fireAmount;
			bullet.GetComponent<Projectile> ().isPage = true;
		}
		if (knightCard) {
			bullet.GetComponent<Projectile> ().upKnock = true;
			bullet.GetComponent<Projectile> ().upKnockForce = knockUp;
			bullet.GetComponent<Projectile>().fire();
		}
		if (queenCard) {
			bullet.GetComponent<Projectile> ().slows = true;
			bullet.GetComponent<Projectile> ().slowPercent = slowPercent;
			bullet.GetComponent<Projectile> ().slowTime = slowTime;
		}
		if (kingCard) {
			bullet.GetComponent<Projectile> ().stuns = true;
			bullet.GetComponent<Projectile> ().stunTime = stunTime;
		}

		bullet.GetComponent<Projectile>().fire();
	}

}
