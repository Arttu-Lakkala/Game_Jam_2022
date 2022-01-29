using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
	public static StateManager instance;
	[SerializeField]
	private GameObject enemyPrefab;
	[SerializeField]
	private GameObject playerPrefab;
	[SerializeField]
	private GameObject targetSpawn;
	public int enemyIncrease;
	private int currentIncrease;
	
	private void Awake(){
		if(StateManager.instance == null) instance = this;
			else Destroy(gameObject);
	}
    public void ReloadCurrentScene() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	
	public void ChangeSceneByName(string name) {
		if(name != null) {
			SceneManager.LoadScene(name);
		}
	}
	
	public void BattleEnd(string deadCharacter)
	{
		if(deadCharacter == "Player") 
		{
			LevelManager.instance.GameOver();
		}
		else
		{
			currentIncrease = currentIncrease + enemyIncrease;
			//display enemy bonus
			//display your bonus
			//let player choose
			//then spawn a new enemy
			SpawnNewEnemy();
		}
	}
	
	public void SpawnNewEnemy() 
	{
		GameObject newEnemy = Instantiate(enemyPrefab, targetSpawn.transform.position, Quaternion.identity) as GameObject;
		//newEnemy.GetComponent<CharacterStats>().maxHealth = currentIncrease;
	}
}
