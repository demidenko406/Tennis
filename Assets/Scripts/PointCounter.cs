using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointCounter : MonoBehaviour
{
	public GameObject rightBound;
	public GameObject leftBound;
	Text text;
	void Start()
	{
		text = GetComponent<Text>();
		text.text = rightBound.GetComponent<BoundController>().enemyScore + "\t" +
			leftBound.GetComponent<BoundController>().playerScore;
	}
	void Update()
	{
		text.text = rightBound.GetComponent<BoundController>().enemyScore + "\t" +
			leftBound.GetComponent<BoundController>().playerScore;
	}
}