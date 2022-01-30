using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
	public static StateManager instance;
	
	private void Awake(){
		if(StateManager.instance == null) instance = this;
			else Destroy(gameObject);
	}
    public void ReloadCurrentScene() {
		Time.timeScale = 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	
	public void ChangeSceneByName(string name) {
		if(name != null) {
			Time.timeScale = 1;
			SceneManager.LoadScene(name);
		}
	}
	
	public void BattleEnd(string deadCharacter)
	{
		Debug.Log("something died");
		if(deadCharacter == "Player") 
		{
			Time.timeScale = 0;
			LevelManager.instance.GameOver();
		}
		else
		{
			Time.timeScale = 0;
			LevelManager.instance.Power();
			PowerManager.instance.RandomizePowers();
		}
	}
}
