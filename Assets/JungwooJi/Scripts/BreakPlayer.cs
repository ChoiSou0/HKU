using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPlayer : MonoBehaviour
{
	BreakManager GM;

	void Start()
	{
		GM = GameObject.Find("BreakManager").GetComponent<BreakManager>();
		StartCoroutine(HitboxOn());
	}

	void Update()
	{

	}

	IEnumerator HitboxOn()
	{
		while (true)
		{
			if (GM.IsGameover == false)
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{
					switch (Random.Range(0, 3))
					{
						case 0:
							this.GetComponent<Animator>().SetTrigger("Hook");
							break;
						case 1:
							this.GetComponent<Animator>().SetTrigger("Jab");
							break;
						case 2:
							this.GetComponent<Animator>().SetTrigger("Straight");
							break;
					}
					this.transform.GetChild(0).gameObject.SetActive(true);
					yield return new WaitForSeconds(0.1f);
					this.transform.GetChild(0).gameObject.SetActive(false);
				}
			}
			yield return new WaitForSeconds(0.05f);
		}
	}
}
