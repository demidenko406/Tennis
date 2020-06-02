using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour
{
	public UIManager uiManager;
	private Text text;

	void Start()
	{
		text = GetComponent<Text>();
	}

	void Update()
	{

	}
}