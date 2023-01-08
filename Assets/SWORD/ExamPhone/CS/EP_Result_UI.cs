using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class EP_Result_UI : MonoBehaviour
{
    float MoveSpeed = 300f;    // �̹��� �̵� �ӵ�

    void Start()
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.transform.position = new Vector2(Screen.width / 2, Screen.height / 2);

        // ������Ʈ ���� �̵�
        rect.transform.DOMove(new Vector3(Screen.width / 2, (Screen.height / 2) + MoveSpeed, 0), 1f).SetEase(Ease.InOutSine);

        // ������Ʈ ������ ����
        rect.transform.DOScale(new Vector3(1, 1, 1), 1f);

        Destroy(gameObject, 1f);
    }
}
