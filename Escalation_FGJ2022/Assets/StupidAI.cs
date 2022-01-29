using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidAI : MonoBehaviour
{
  [SerializeField] private Transform target;
  [SerializeField] private Transform self;
  public CharacterController2D controller;
  
  float horizontalMove = 0f;
  float reaction_dist = 1.5f;
  bool jump = false;
  bool crouch = false;
  // Update is called once per frame
  void Update()
  {
     // move towards player horizonttaly
     Debug.Log(self.position.x - target.position.x);
      if((self.position.x - target.position.x)>reaction_dist)
      {
        horizontalMove = -1;
      }
      else if ((self.position.x - target.position.x)<(-reaction_dist))
      {
        horizontalMove = 1;
      }
  }
  void FixedUpdate ()
  {
    //move char
    controller.Move(horizontalMove,crouch,jump);
  }      
}
