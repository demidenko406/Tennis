using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
	public float speed = 3.5F;
	private Vector2 spawnDir;
	Rigidbody2D rig2D;
	void Start()
	{
		rig2D = this.gameObject.GetComponent<Rigidbody2D>();
		int rand = Random.Range(1, 4);
		if (rand == 1)
		{
			spawnDir = new Vector2(1, 1);
		}
		else if (rand == 2)
		{
			spawnDir = new Vector2(1, -1);
		}
		else if (rand == 3)
		{
			spawnDir = new Vector2(-1, -1);
		}
		else if (rand == 4)
		{
			spawnDir = new Vector2(-1, 1);
		}
		rig2D.velocity = (spawnDir * speed);

	}
	void Update()
	{

	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Enemy")
		{
			float y = launchAngle(transform.position,
								col.transform.position,
								col.collider.bounds.size.y);

			Vector2 d = new Vector2(1, y).normalized;
			rig2D.velocity = d * speed * 1.5F;
		}
		
		if (col.gameObject.tag == "Player")
		{
			float y = launchAngle(transform.position,
								col.transform.position,
								col.collider.bounds.size.y);
			Vector2 d = new Vector2(-1, y).normalized;
			rig2D.velocity = d * speed * 1.5F;
		}
	}
	float launchAngle(Vector2 ballPos, Vector2 paddlePos,
					float paddleHeight)
	{
		return (ballPos.y - paddlePos.y) / paddleHeight;
	}
}