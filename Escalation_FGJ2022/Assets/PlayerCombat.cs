using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
	
	public Animator animator;
  public AudioClip hit1;
  public AudioClip hit2;
	
	//Where the attack originates
	public Transform attackPoint;
	//Area of attack and damage
	public float attackRange = 0.5f;
	
	//Cooldown between each attack
	public float attackRate = 2f;
	float nextAttackTime = 0f;
	
	public LayerMask enemyLayers;
  private AudioClip playNext;


    // Update is called once per frame
    void Update()
    {
		if(Time.time >= nextAttackTime)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Attack();
				nextAttackTime = Time.time + 1f / attackRate;
			}
		}
    }
	
	void Attack()
	{
		//Play attack anim
		//animator.SetTrigger("Attack");
		//Detect enemy in range
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
		//Deal damage
		foreach (Collider2D enemy in hitEnemies)
		{
      playNext = hit2;
      enemy.GetComponent<AudioSource>().PlayOneShot(playNext);
			enemy.GetComponent<CharacterStats>().TakeDamage(gameObject.GetComponent<CharacterStats>().attackDamage);
			Debug.Log("hit an enemy");
		}
	}
	
	void OnDrawGizmosSelected()
	{
		//Draw a helping circle in editor to see where the strike hits
		if(attackPoint == null)
			return;
		Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}
}
