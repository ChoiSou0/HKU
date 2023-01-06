using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class EP_Result_UI : MonoBehaviour
{
    float MoveSpeed = 1.5f;    // �̹��� �̵� �ӵ�
    float alphaSpeed = 1;   // ���İ� ��ȭ �ӵ� 

    SpriteRenderer sprite;
    Color alpha;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        // ������Ʈ ���� �̵�
        transform.DOMove(new Vector3(0, MoveSpeed, 0), 1f).SetEase(Ease.InOutSine);

        // ������Ʈ ������ ����
        transform.DOScale(new Vector3(1, 1, 1), 1f);

        alpha = sprite.color;
        Destroy(gameObject, 1f);
    }

    void Update()
    {
        // ���İ� ����
        //alpha.a = Mathf.Lerp(alpha.a, 0, alphaSpeed * Time.deltaTime);
        sprite.color = alpha;
    }
}
