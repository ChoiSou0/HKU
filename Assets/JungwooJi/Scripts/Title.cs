using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Title : MonoBehaviour
{
	private int Num;

	public GameObject ClickObj;

	public string[] Scenelist;

	bool BB;

	public RectTransform rect;

	void Start()
	{
		rect.transform.position = new Vector3(0, 2, 0);
		StartCoroutine(DoDongShil());
	}

	void Update()
	{
		MoveClick();
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SceneManager.LoadScene(Scenelist[Num + 2]);
		}
	}

	public void MoveClick()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			if (Num > -2)
			{
				Num -= 1;
			}
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			if (Num < 2)
			{
				Num += 1;
			}
		}
		ClickObj.GetComponent<RectTransform>().anchoredPosition = new Vector3(Num * 300, -170, 0);
	}

	public void Exitgame()
	{
		Application.Quit();
	}

	IEnumerator DoDongShil()
	{
		while (true)
		{
			if (BB) rect.transform.DOMoveY(2f, 1);
			else rect.transform.DOMoveY(3f, 1);

			BB = !BB;

			yield return new WaitForSeconds(1f);
		}
	}
}
