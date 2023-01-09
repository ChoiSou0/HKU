using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BreakManager : MonoBehaviour
{
	public int Score;
	public int Health;

	public TextMeshProUGUI ScoreText;
	public TextMeshProUGUI HealthText;
	public Slider HealthBar;

	public Sprite[] ImageList;
	public Sprite[] BreakImageList;

	public GameObject HitScreen;

	void Start()
	{
		StartCoroutine(ObjectCreate());
	}

	void Update()
	{

	}

	IEnumerator ObjectCreate()
	{
		while (true)
		{
			GameObject temp = Instantiate(Resources.Load("prefeb/Object"), new Vector3(0, 0, 0), Quaternion.identity, GameObject.Find("Canvas").transform) as GameObject;
			temp.GetComponent<RectTransform>().anchoredPosition = new Vector3(1050, 0, 0);
			int tempnum = Random.Range(0, 5);
			temp.GetComponent<Image>().sprite = ImageList[tempnum];
			temp.GetComponent<BreakObject>().BreakImage = BreakImageList[tempnum];
			temp.GetComponent<Rigidbody2D>().velocity = new Vector3(-11, 7, 0);
			yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
		}
	}
}
