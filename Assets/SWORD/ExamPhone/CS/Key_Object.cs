using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key_Object : MonoBehaviour
{
    Image Key_Image;            // 오브젝트의 현재 이미지

    public Sprite Input_Down;   // 버튼 눌린 스프라이트
    public Sprite Input_Up;     // 버튼 떼진 스프라이트

    void Awake()
    {
        Key_Image = GetComponent<Image>();
    }

    public IEnumerator Change_Sprite()
    {
        Key_Image.sprite = Input_Down;
        yield return new WaitForSeconds(0.1f);

        Key_Image.sprite = Input_Up;
        yield return new WaitForSeconds(0.1f);

        yield return null;
    }

    public void Call_Change_Sprite() { StartCoroutine(Change_Sprite()); }
}
