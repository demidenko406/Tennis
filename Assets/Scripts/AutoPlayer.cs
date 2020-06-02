using UnityEngine;
using System.Collections;

public class AutoPlayer : MonoBehaviour
{
	public Animator animator;
	public float speed = 1.75F;
	Transform ball;
	Rigidbody2D ballRig2D;
	public float topBound = 3F;
	public float bottomBound = -3F;
	void Start()
	{
		Time.timeScale = 1;
		InvokeRepeating("Move", .02F, .02F);
	}

	void Move()
	{
		animator.SetFloat("Speed", 0);
		if (ball == null)
		{
			ball = GameObject.FindGameObjectWithTag("Ball").transform;
		}
		ballRig2D = ball.GetComponent<Rigidbody2D>();
		if (ballRig2D.velocity.x > 0)
		{
			if (ball.position.y < this.transform.position.y - .3F)
			{
				transform.Translate(Vector3.down * speed * Time.deltaTime);
				animator.SetFloat("Speed", 0);
				animator.SetFloat("Speed", -1);
			}
			else if (ball.position.y > this.transform.position.y + .3F)
			{
				transform.Translate(Vector3.up * speed * Time.deltaTime);
				animator.SetFloat("Speed", 0);
				animator.SetFloat("Speed", 1);
			}

		}
		if (transform.position.y > topBound)
		{
			transform.position = new Vector3(transform.position.x, topBound, 0);
		}
		else if (transform.position.y < bottomBound)
		{
			transform.position = new Vector3(transform.position.x, bottomBound, 0);
		}
	}
}