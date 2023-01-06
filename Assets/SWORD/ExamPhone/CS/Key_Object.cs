using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key_Object : MonoBehaviour
{
    Image Key_Image;            // ������Ʈ�� ���� �̹���

    public Sprite Input_Down;   // ��ư ���� ��������Ʈ
    public Sprite Input_Up;     // ��ư ���� ��������Ʈ

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

    public void Call_Change_Sprite() { StartCoroutine( Change_Sprite() ); }
}
