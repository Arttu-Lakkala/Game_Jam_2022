using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDie : MonoBehaviour
{
	public void Die() 
	{
		LevelManager.instance.GameOver();
		gameObject.SetActive(false);
	}
}
