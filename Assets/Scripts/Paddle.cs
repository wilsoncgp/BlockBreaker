using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
	public bool autoPlay = false;
	
	private Ball ball;

	float minPositionX = 0.5f;
	float maxPositionX = 15.5f;

	// Use this for initialization
	void Start ()
	{
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!autoPlay)
		{
			MoveWithMouse();
		}
		else
		{
			AutoPlay();
		}
	}
	
	void MoveWithMouse()
	{
		float mousePosInBlocks = Mathf.Clamp(Input.mousePosition.x / Screen.width * 16, minPositionX, maxPositionX);
		Vector3 paddlePos = new Vector3(mousePosInBlocks, this.transform.position.y, 0f);
		this.transform.position = paddlePos;
	}
	
	void AutoPlay()
	{
		float mousePosInBlocks = Mathf.Clamp(ball.transform.position.x, minPositionX, maxPositionX);
		Vector3 paddlePos = new Vector3(mousePosInBlocks, this.transform.position.y, 0f);
		this.transform.position = paddlePos;
	}
}
