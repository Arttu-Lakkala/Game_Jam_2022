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
  public AudioClip hit1;
  public AudioClip hit2;
  
  public LayerMask playerLayer;
  
  float nextJumpTime = 0f;
  float nextAttackTime = 0f;
  float nextMovementChange = 0f;
  
  //-1, 0, 1 based on wether we move away at or stay still
  int movement_state;
  bool jump = false;
  bool crouch = false;
  private AudioClip playNext;
  
  // Update is called once per frame
  void Awake()
  {
    //iniate pseudo randomnes
    Random.InitState(50);
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
      }
  }
  
   void FixedUpdate()
  {
    //move char
    controller.Move(movement_state,crouch,jump);
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
      //deal damage
			enemy.GetComponent<CharacterStats>().TakeDamage(gameObject.GetComponent<CharacterStats>().attackDamage);
			//select sound                {
      if(Random.Range(0, 2)>1)
      {
        playNext = hit1;
      }
      else
      {
        playNext = hit2;
      }
      enemy.GetComponent<AudioSource>().PlayOneShot(playNext);
      Debug.Log("Hit Player");
		}
	}
  
}
