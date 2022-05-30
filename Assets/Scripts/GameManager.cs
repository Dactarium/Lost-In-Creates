using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
	public PlayerInputs playerInputs;

	public Enemy blue;
	public Enemy green;
	public Enemy orange;
	public Enemy purple;
	public Enemy sunFlower;
	public Enemy worm;

	private void OnEnable()
	{
		Events.OnDead += GameOver;
	}

	private void OnDisable()
	{
		Events.OnDead -= GameOver;
	}

	private void GameOver()
	{
		SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
	}
}
