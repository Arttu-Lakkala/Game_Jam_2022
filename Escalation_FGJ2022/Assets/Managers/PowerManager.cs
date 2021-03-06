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
	[SerializeField]
	private Text textBox4;
	
	private int enemyCurrentSpeed;
	private int enemyCurrentRecoil;
	private int enemyCurrentAttack;
	private int enemyCurrentHealth;
	
	private void Awake(){
		if(PowerManager.instance == null) instance = this;
			else Destroy(gameObject);
			
		enemyCurrentSpeed = 10;
		enemyCurrentRecoil = enemyPrefab.GetComponent<CharacterStats>().attackRecoil;
		enemyCurrentAttack = enemyPrefab.GetComponent<CharacterStats>().startingAttack;
		enemyCurrentHealth = enemyPrefab.GetComponent<CharacterStats>().maxHealth;
	}
		
	public void RandomizePowers() {
		Debug.Log("Powers are randomized!");
		textBox1.text = "SPEED +10";
		textBox2.text = "KNOCKBACK +10";
		textBox3.text = "DAMAGE +10";
		textBox4.text = "HEALTH +10";
		
	}
	
	public void ChoosePower(int choice){
		switch(choice)
		{
			case 1:
			Debug.Log("Power 1 chosen");
			//playerPrefab.GetComponent<CharacterStats>().characterSpeed += 10;
			MovePlayer();
			SpawnNewEnemy(1);
			LevelManager.instance.Power();
			Time.timeScale = 1;
			break;
			
			case 2:
			Debug.Log("Power 2 chosen");
			playerPrefab.GetComponent<CharacterStats>().attackRecoil += 10;
			MovePlayer();
			SpawnNewEnemy(2);
			LevelManager.instance.Power();
			Time.timeScale = 1;
			break;
			
			case 3:
			Debug.Log("Power 3 chosen");
			playerPrefab.GetComponent<CharacterStats>().attackDamage += 10;
			MovePlayer();
			SpawnNewEnemy(3);
			LevelManager.instance.Power();
			Time.timeScale = 1;
			break;
			
			case 4:
			Debug.Log("Power 4 chosen");
			MovePlayer();
			playerPrefab.GetComponent<CharacterStats>().maxHealth += 10;
			playerPrefab.GetComponent<CharacterStats>().currentHealth += 10;
			SpawnNewEnemy(4);
			LevelManager.instance.Power();
			Time.timeScale = 1;
			break;
		}
	}
	
	public void MovePlayer() {
		playerPrefab.transform.position = playerTargetSpawn.transform.position;
	}		
	
	public void SpawnNewEnemy(int choice) 
	{
		GameObject newEnemy = Instantiate(enemyPrefab, enemyTargetSpawn.transform.position, Quaternion.identity) as GameObject;
		switch(choice)
		{
			case 1:
			Debug.Log("Speed boost");
			break;
			
			case 2:
			newEnemy.GetComponent<CharacterStats>().attackRecoil = enemyCurrentRecoil+20;
			enemyCurrentRecoil = newEnemy.GetComponent<CharacterStats>().attackRecoil;
			break;
			
			case 3:
			newEnemy.GetComponent<CharacterStats>().attackDamage = enemyCurrentAttack+20;
			enemyCurrentAttack = newEnemy.GetComponent<CharacterStats>().attackDamage;
			break;
			
			case 4:
			newEnemy.GetComponent<CharacterStats>().maxHealth = enemyCurrentHealth+20;
			newEnemy.GetComponent<CharacterStats>().currentHealth = enemyCurrentHealth+20;
			enemyCurrentHealth = newEnemy.GetComponent<CharacterStats>().maxHealth;
			break;
		}
	}
}
