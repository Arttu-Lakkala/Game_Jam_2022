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
  public float jumpRate = 1f;
  public float attackRate = 2f;
  public float attackRange = 0.5f;
  
  public LayerMask playerLayer;
  
  float nextJumpTime = 0f;
  float nextAttackTime = 0f;
  float nextMovementChange = 0f;
  
  //-1, 0, 1 based on wether we move away at or stay still
  int movement_state;
  
  
  float horizontalMove = 0f;
  bool jump = false;
  bool crouch = false;
  
  // Update is called once per frame
  void Awake()
  {
    Debug.Log("awake");
    //iniate pseudo randomnes
    Random.InitState(18);
    nextJumpTime = Random.Range(2, 20)/jumpRate;
    nextAttackTime = Random.Range(2, 20)/attackRate;
    nextMovementChange = Random.Range(1, 8);
    movement_state = (Random.Range(0, 3)-1);
  }
  
  
  
  
  void Update()
  {
      //is it time to jump
      if(Time.time >= nextJumpTime)
      {
        {
          jump = true;
          nextJumpTime = (Time.time +Random.Range(2, 20)/jumpRate);
        }
      }
      
      //is it time to attack
      if(Time.time >= nextAttackTime)
      {
        {
          Attack();
          nextAttackTime = (Time.time +Random.Range(2, 20)/attackRate);
        }
      }
      
      //is it time to change movement_state
      if(Time.time >= nextMovementChange)
      {
        movement_state = (Random.Range(0, 3)-1);
        nextMovementChange = (Time.time +Random.Range(1, 8));
        Debug.Log(movement_state);
      }
      
      
      // move towards player horizontaly
      if((self.position.x - target.position.x)>0)
      {
        horizontalMove = -1;
      }
      else if ((self.position.x - target.position.x)<0)
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
    controller.Move(horizontalMove*movement_state,crouch,jump);
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
