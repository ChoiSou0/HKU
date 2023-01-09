using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Title : MonoBehaviour
{
	private int Num;

	public string[] Scenelist;
	public string[] GameList;

	public RectTransform rect;

	public GameObject Gamename;
	public GameObject Finger;
	public GameObject FingerText;
	private Vector3 Scale;
	private Vector3 Location;

	void Start()
	{
		Scale = Gamename.transform.localScale;
		Location = rect.transform.localPosition;
		rect.transform.position = new Vector3(0, 2, 0);
		StartCoroutine(DoDongShil());
		StartCoroutine(DokiDoki());
	}

	void Update()
	{
		MoveClick();
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
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
		Finger.GetComponent<RectTransform>().anchoredPosition = new Vector3(Num * 300, -170, 0);
		FingerText.GetComponent<RectTransform>().anchoredPosition = new Vector3(Num * 300, 230, 0);
		FingerText.GetComponent<TextMeshProUGUI>().text = GameList[Num + 2];
	}

	public void Exitgame()
	{
		Application.Quit();
	}

	IEnumerator DoDongShil()
	{
		while (true)
		{
			for (int i = 0; i < 25; i++)
			{
				rect.anchoredPosition = new Vector3(Location.x, Location.y - i * 3f, Location.z);
				yield return new WaitForSeconds(0.02f);
			}
			for (int i = 25; i > 0; i--)
			{
				rect.anchoredPosition = new Vector3(Location.x, Location.y - i * 3f, Location.z);
				yield return new WaitForSeconds(0.02f);
			}
		}
	}

	IEnumerator DokiDoki()
	{
		while (true)
		{
			for (int i = 0; i < 25; i++)
			{
				Gamename.transform.localScale = Scale * (1 + i * 0.01f);
				Finger.transform.localScale = Scale * (1 + i * 0.005f);
				yield return new WaitForSeconds(0.02f);
			}
			for (int i = 25; i > 0; i--)
			{
				Gamename.transform.localScale = Scale * (1 + i * 0.01f);
				Finger.transform.localScale = Scale * (1 + i * 0.005f);
				yield return new WaitForSeconds(0.02f);
			}
		}
	}
}
