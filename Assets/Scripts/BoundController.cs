using UnityEngine;
using System.Collections;

public class BoundController : MonoBehaviour
{

	public Transform enemy;
	public int enemyScore;
	public int playerScore;

	void Start()
	{
		enemyScore = 0;
		playerScore = 0;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Ball")
		{
			if (other.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
			{
				enemyScore++;
			}
			else
			{
				playerScore++;
			}
			Destroy(other.gameObject);
			enemy.position = new Vector3(-6, 0, 0);
			Time.timeScale = 0;
		}
	}
}