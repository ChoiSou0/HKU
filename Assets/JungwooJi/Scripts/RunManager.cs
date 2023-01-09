using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RunManager : MonoBehaviour
{
	public float Gamespeed;
	public int Distance;

	public TextMeshProUGUI DistanceText;

	public GameObject GameoverScreen;
	public bool IsGameover;

	public float JumpValue;
	public float JumpMinValue;
	public float JumpMaxValue;
	public bool JumpReady;

	public GameObject[] ObjectList;

	void Start()
	{
		Distance = 1000;
	}

	void Update()
	{
		DistanceText.text = Distance + "M";
	}
}
