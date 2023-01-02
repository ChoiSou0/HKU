using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public int HorizontalNum;
    public int VerticalNum;
    public int TurnVec;
    public int ClearRotation;
    public Sprite On;
    public Sprite Off;

    private Image image;

    private void Start()
    {
        image = gameObject.GetComponent<Image>();   
    }

    private void Update()
    {
        if (gameObject.transform.eulerAngles.z == ClearRotation)
        {
            image.sprite = On;
        }
        else
        {
            image.sprite = Off;
        }

    }
}
