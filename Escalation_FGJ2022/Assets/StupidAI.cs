using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidAI : MonoBehaviour
{
  
  [SerializeField] private Transform target;
  [SerializeField] private Transform self;
  
  public Animator animator;
	
	//Where the attack originates
	public Transform attackPoint;
  
  public CharacterController2D controller;
  public float reaction_dist = 1.5f;
  public float jumpRate = 1f;
  public float attackRate = 2f;
  public float attackRange = 0.5f;
  
  public LayerMask playerLayer;
  
  float nextJumpTime = 0f;
  float nextAttackTime = 0f;
  
  float horizontalMove = 0f;
  bool jump = false;
  bool crouch = false;
  float action_number;
  // Update is called once per frame
  void Awake()
  {
    Debug.Log("awake");
    //iniate pseudo randomnes
    Random.InitState(18);
    nextJumpTime = Random.Range(2, 20)/jumpRate;
    nextAttackTime = Random.Range(2, 20)/attackRate;
  }
  
  
  
  
  void Update()
  {
      //is it time to jump
      if(Time.time >= nextJumpTime)
      {
        {
          Debug.Log("jumped");
          jump = true;
          nextJumpTime = (Time.time +Random.Range(2, 20)/jumpRate);
        }
      }
      
      //is it time to attack
      if(Time.time >= nextAttackTime)
      {
        {
          Debug.Log("attacked");
          Attack();
          nextAttackTime = (Time.time +Random.Range(2, 20)/attackRate);
        }
      }
      
      
      // move towards player horizontaly
      if((self.position.x - target.position.x)>reaction_dist)
      {
        horizontalMove = -1;
      }
      else if ((self.position.x - target.position.x)<(-reaction_dist))
      {
        horizontalMove = 1;
      }
      else
      {
        horizontalMove = 0;
      }
  }
   void FixedUpdate()
  {
    //move char
    controller.Move(horizontalMove,crouch,jump);
    if (jump==true)
    {
      jump = false;
    }
  }
  void Attack()
	{
		//Play attack anim
		//animator.SetTrigger("Attack");
		//Detect enemy in range
		Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
		//Deal damage
		foreach (Collider2D enemy in hitEnemies)
		{
			enemy.GetComponent<CharacterStats>().TakeDamage(gameObject.GetComponent<CharacterStats>().attackDamage);
			Debug.Log("Hit Player");
		}
	}  
}
