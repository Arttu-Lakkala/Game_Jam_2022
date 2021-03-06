using UnityEngine;

public class CharacterStats : MonoBehaviour
{
	public string characterName;
	// Set the units max health
	public int maxHealth = 100;
	public int startingAttack = 10;
	public int attackRecoil = 50;
	public int currentHealth;
	public int attackDamage;
	
	// Set variables for different stats this has (damage, armor, etc)
	public Stat damage;
	public Stat armor;
	public Animator animator;
	public AudioClip deathSound;
	private CharacterController2D controller;
  
	void Awake ()
	{
    controller = GetComponent<CharacterController2D>();
		// Set max health when created
		currentHealth = maxHealth;
    attackDamage = startingAttack;
	}
	
	void Update ()
	{
		if(Vector3.Distance(transform.position, Camera.main.transform.position) > 30)
            Destroy(gameObject);
	}
	
	public void TakeDamage (int damage)
	{
		
		//Reduce damage by armor (if more armor than damage, reduce to zero)
		damage -= armor.getValue();
		damage = Mathf.Clamp(damage, 0, int.MaxValue);
		currentHealth -= damage;
		
    
		//play hurt animation depending on enemy / player
		//animator.SetTrigger("Hurt");
		controller.HurtRecoil(attackRecoil);
		
		Debug.Log (transform.name + " takes " + damage +  " damage.");
		
    
		if (currentHealth <= 0)
		{
			Die();
		}
	}
	
	public virtual void Die ()
	{
		Debug.Log(transform.name + " died.");
		gameObject.GetComponent<AudioSource>().PlayOneShot(deathSound);
		StateManager.instance.BattleEnd(characterName);
		//animator.SetBool("IsDead", true);
		GetComponent<Collider2D>().enabled = false;
		
	}
}
