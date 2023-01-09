using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPlayer : MonoBehaviour
{
	public RunManager GM;

	void Start()
	{
		GM = GameObject.Find("RunManager").GetComponent<RunManager>();
		GM.JumpValue = GM.JumpMinValue;
	}

	void Update()
	{
		if (GM.IsGameover == false)
		{
			PlayerMove();
		}
	}

	private void PlayerMove()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			StartCoroutine(JumpScale());
		}
		if (GM.JumpReady == true)
		{
			if (Input.GetKeyUp(KeyCode.Space))
			{
				GM.JumpReady = false;
				StopAllCoroutines();
				if (GM.JumpValue > GM.JumpMaxValue)
				{
					GM.JumpValue = GM.JumpMaxValue;
				}
				this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, GM.JumpValue, 0);
				GM.JumpValue = GM.JumpMinValue;
			}
		}
	}

	IEnumerator JumpScale()
	{
		while (true)
		{
			GM.JumpValue += 0.2f;
			yield return new WaitForSeconds(0.005f);
		}
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "floor")
		{
			GM.JumpReady = true;
		}
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "spike")
		{
			GM.Distance -= 100;
			if (GM.Distance <= 0)
			{
				GM.Gamespeed = 0;
				GameObject.Find("Player").GetComponent<Animator>().speed = 0;
				GM.GameoverScreen.SetActive(true);
				GM.IsGameover = true;
			}
		}
	}
}
