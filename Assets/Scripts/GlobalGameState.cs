using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameState : MonoBehaviour
{
	public bool isGameOver = false;
	public bool isGamePaused = false;
	public bool isInventoryOpen = false;
	public static GlobalGameState instance;
	public int progression = 0; // 0 on ei monstereita, 1 on marko, 2 on kummatki
	public int totalFishCaught = 0; //monta kalaa/itemi� kalastettu
	/* 	public int uID; */
	void Awake() //Make static singleton instance
	{
		if (instance != null)
			Destroy(gameObject);
		else
			instance = this;
		DontDestroyOnLoad(this);
	}
	/* 	void Start()
		{
			uID = Random.Range(0, 10001);
		} */
	public void Stop()
	{
		Time.timeScale = 0f;
		Debug.Log("Timescale is now 0");
	}

	public void Resume()
	{
		Time.timeScale = 1f;
		Debug.Log("Timescale is now 1");
	}

	public void ResetGame()
	{
		Resume();
		isGamePaused = false;
		isInventoryOpen = false;
		isGameOver = false;
	}
}

