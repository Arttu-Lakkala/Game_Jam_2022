using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    // Update is called once per frame
    void Update()
    {
       //get horisontal movement based on movespeed
      horizontalMove = Input.GetAxisRaw ("Horizontal");
      if(Input.GetAxisRaw ("Vertical")>0)
      {
        jump= true;
        crouch = false;
      }
      else if(Input.GetAxisRaw ("Vertical")<0)
      {
        crouch = true;
        jump = false;
      }
      else
      {
        jump = false;
        crouch = false;
      }
    }
    
    void FixedUpdate ()
    {
      //move char
      controller.Move(horizontalMove,crouch,jump);
    }
}
