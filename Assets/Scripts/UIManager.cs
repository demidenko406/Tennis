using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
	GameObject[] pauseObjects, finishObjects;
	public BoundController rightBound;
	public BoundController leftBound;
	public bool isFinished;
	public bool playerWon, enemyWon;

	void Start()
	{
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		finishObjects = GameObject.FindGameObjectsWithTag("ShowOnFinish");
		hideFinished();
	}

	void Update()
	{

		if (rightBound.enemyScore >= 7 && !isFinished)
		{
			isFinished = true;
			enemyWon = true;
			playerWon = false;
		}
		else if (leftBound.playerScore >= 7 && !isFinished)
		{
			isFinished = true;
			enemyWon = false;
			playerWon = true;
		}

		if (isFinished)
		{
			showFinished();
		}

		if (Input.GetKeyDown(KeyCode.P) && !isFinished)
		{
			if (Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			}
			else if (Time.timeScale == 0)
			{
				Time.timeScale = 1;
				hidePaused();
			}
		}


		if (Time.timeScale == 0 && !isFinished)
		{
			foreach (GameObject g in pauseObjects)
			{
				if (g.name == "PauseText")
					g.SetActive(true);
			}
		}
		else
		{
			foreach (GameObject g in pauseObjects)
			{
				if (g.name == "PauseText")
					g.SetActive(false);
			}
		}
	}

	public void Reload()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	public void pauseControl()
	{
		if (Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showPaused();
		}
		else if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
			hidePaused();
		}
	}

	public void showPaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(true);
		}
	}

	public void hidePaused()
	{
		foreach (GameObject g in pauseObjects)
		{
			g.SetActive(false);
		}
	}

	public void showFinished()
	{
		foreach (GameObject g in finishObjects)
		{
			g.SetActive(true);
		}
	}

	public void hideFinished()
	{
		foreach (GameObject g in finishObjects)
		{
			g.SetActive(false);
		}
	}

	public void LoadLevel(string level)
	{
		Application.LoadLevel(level);
	}
}