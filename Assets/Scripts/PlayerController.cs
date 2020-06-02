using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public Animator animator;
	public float speed = 10;
	public float topBound = 3F;
	public float bottomBound = -3F;
	void Start()
	{
		Time.timeScale = 0;
	}
	void Update()
	{

	}
	void FixedUpdate()
	{
		float movementSpeedY = speed * Input.GetAxis("Vertical") * Time.deltaTime;
		transform.Translate(0, movementSpeedY, 0);
		animator.SetFloat("Speed", movementSpeedY);
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