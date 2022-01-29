using UnityEngine;

public class CharacterStats : MonoBehaviour
{
	public string characterName;
	// Set the units max health
	public int maxHealth = 100;
	public int startingAttack = 10;
	public int attackRecoil = 200;
	public int currentHealth {get; private set;}
	public int attackDamage {get; private set;}
	
	// Set variables for different stats this has (damage, armor, etc)
	public Stat damage;
	public Stat armor;
	
	public Animator animator;
	private CharacterController2D controller;
  
	void Awake ()
	{
    controller = GetComponent<CharacterController2D>();
		// Set max health when created
		currentHealth = maxHealth;
    attackDamage = startingAttack;
	}
	
	void OnBecameInvisible() {
         Destroy(gameObject);
    }
	
	void Update ()
	{
		
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
		StateManager.instance.BattleEnd(characterName);
		//animator.SetBool("IsDead", true);
		GetComponent<Collider2D>().enabled = false;
		this.enabled = false;
		
	}
}
