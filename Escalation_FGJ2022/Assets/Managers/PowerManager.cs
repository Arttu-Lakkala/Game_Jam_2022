using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PowerManager : MonoBehaviour
{	
	public static PowerManager instance;
	
	[SerializeField]
	private GameObject enemyPrefab;
	[SerializeField]
	private GameObject playerPrefab;
	[SerializeField]
	private GameObject playerTargetSpawn;
	[SerializeField]
	private GameObject enemyTargetSpawn;
	
	[SerializeField]
	private Text textBox1;
	[SerializeField]
	private Text textBox2;
	[SerializeField]
	private Text textBox3;
	
	private void Awake(){
		if(PowerManager.instance == null) instance = this;
			else Destroy(gameObject);
	}
		
	public void RandomizePowers() {
		Debug.Log("Powers are randomized!");
		textBox1.text = "SPEED +10";
		textBox2.text = "KNOCKBACK +10";
		textBox3.text = "DAMAGE +10";
		
	}
	
	public void ChoosePower(int choice){
		switch(choice)
		{
			case 1:
			Debug.Log("Power 1 chosen");
			MovePlayer();
			SpawnNewEnemy();
			LevelManager.instance.Power();
			Time.timeScale = 1;
			break;
			
			case 2:
			Debug.Log("Power 2 chosen");
			MovePlayer();
			SpawnNewEnemy();
			LevelManager.instance.Power();
			Time.timeScale = 1;
			break;
			
			case 3:
			Debug.Log("Power 3 chosen");
			MovePlayer();
			SpawnNewEnemy();
			LevelManager.instance.Power();
			Time.timeScale = 1;
			break;
		}
	}
	
	public void MovePlayer() {
		playerPrefab.transform.position = playerTargetSpawn.transform.position;
	}		
	
	public void SpawnNewEnemy() 
	{
		GameObject newEnemy = Instantiate(enemyPrefab, enemyTargetSpawn.transform.position, Quaternion.identity) as GameObject;
		//newEnemy.GetComponent<CharacterStats>().maxHealth = currentIncrease;
	}
}