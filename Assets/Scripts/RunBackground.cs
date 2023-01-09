using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunBackground : MonoBehaviour
{
	private bool IsCreate;
	public RunManager GM;

	void Start()
	{
		GM = GameObject.Find("RunManager").GetComponent<RunManager>();
	}

	void Update()
	{
		this.transform.localPosition = new Vector3(this.transform.localPosition.x - (GameObject.Find("RunManager").GetComponent<RunManager>().Gamespeed * Time.deltaTime), this.transform.localPosition.y, this.transform.localPosition.z);
		if (this.transform.localPosition.x <= 50 && IsCreate == false)
		{
			IsCreate = true;
			GameObject TempBackground = Instantiate(Resources.Load("Prefeb/Background"), new Vector3(this.transform.position.x + 17.77778f, this.transform.position.y, this.transform.position.z), Quaternion.identity, GameObject.Find("BackCanvas").transform) as GameObject;
			switch (Random.Range(0, 5))
			{
				case 0: //Chair
					GameObject temp1 = Instantiate(GM.ObjectList[0], new Vector3(TempBackground.transform.position.x, 0, 0), Quaternion.identity, TempBackground.transform);
					temp1.GetComponent<RectTransform>().anchoredPosition = new Vector3(temp1.GetComponent<RectTransform>().anchoredPosition.x, -381, 0);
					break;
				case 1: //Desk
					GameObject temp2 = Instantiate(GM.ObjectList[1], new Vector3(TempBackground.transform.position.x, 0, 0), Quaternion.identity, TempBackground.transform);
					temp2.GetComponent<RectTransform>().anchoredPosition = new Vector3(temp2.GetComponent<RectTransform>().anchoredPosition.x, -396, 0);
					break;
				case 2: //Mop
					GameObject temp3 = Instantiate(GM.ObjectList[2], new Vector3(TempBackground.transform.position.x, 0, 0), Quaternion.identity, TempBackground.transform);
					temp3.GetComponent<RectTransform>().anchoredPosition = new Vector3(temp3.GetComponent<RectTransform>().anchoredPosition.x, -325, 0);
					break;
				case 3: //Shoes
					GameObject temp4 = Instantiate(GM.ObjectList[3], new Vector3(TempBackground.transform.position.x, 0, 0), Quaternion.identity, TempBackground.transform);
					temp4.GetComponent<RectTransform>().anchoredPosition = new Vector3(temp4.GetComponent<RectTransform>().anchoredPosition.x, -437, 0);
					break;
				case 4: //Trash
					GameObject temp5 = Instantiate(GM.ObjectList[4], new Vector3(TempBackground.transform.position.x, 0, 0), Quaternion.identity, TempBackground.transform);
					temp5.GetComponent<RectTransform>().anchoredPosition = new Vector3(temp5.GetComponent<RectTransform>().anchoredPosition.x, -324, 0);
					break;
			}
		}
		if (this.transform.localPosition.x <= -1920)
		{
			Destroy(this.gameObject);
		}
	}
}
