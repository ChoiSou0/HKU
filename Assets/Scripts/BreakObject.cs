using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakObject : MonoBehaviour
{
	BreakManager GM;

	private int Rotatespeed;

	public Sprite BreakImage;

	void Start()
	{
		GM = GameObject.Find("BreakManager").GetComponent<BreakManager>();
		Rotatespeed = Random.Range(80, 101);
	}

	void Update()
	{
		transform.Rotate(new Vector3(0, 0, -Rotatespeed * Time.deltaTime));
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "Hitbox")
		{
			this.GetComponent<Image>().sprite = BreakImage;
			GM.Score += 100;
			GM.ScoreText.text = "Score : " + GM.Score.ToString();
			this.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(3.0f, 4.0f), -10, 0);
			Rotatespeed += 500;
			collision.gameObject.SetActive(false);
		}
		else if (collision.gameObject.name == "Player")
		{
			GM.Health -= 10;
			GM.HealthBar.value = GM.Health;
			//GM.HealthText.text = GM.Health.ToString();
			this.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(2.0f, 3.0f), -10, 0);
			Rotatespeed += 500;
			StartCoroutine(Hit());
			//Destroy(this.gameObject);
		}
	}

	IEnumerator Hit()
	{
		GM.HitScreen.SetActive(true);
		yield return new WaitForSeconds(0.1f);
		GM.HitScreen.SetActive(false);
	}
}
