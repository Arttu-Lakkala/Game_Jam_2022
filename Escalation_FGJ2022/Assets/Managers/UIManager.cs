using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField] GameObject deathPanel;
	[SerializeField] GameObject powerPanel;
	
	public void ToggleDeathPanel()
	{
		deathPanel.SetActive(!deathPanel.activeSelf);
	}
	
	public void TogglePowerPanel()
	{
		powerPanel.SetActive(!powerPanel.activeSelf);
	}

}
