using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class EP_Result_UI : MonoBehaviour
{
    float MoveSpeed = 1.5f;    // 이미지 이동 속도
    float alphaSpeed = 1;   // 알파값 변화 속도 

    SpriteRenderer sprite;
    Color alpha;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        // 오브젝트 위로 이동
        transform.DOMove(new Vector3(0, MoveSpeed, 0), 1f).SetEase(Ease.InOutSine);

        // 오브젝트 스케일 조정
        transform.DOScale(new Vector3(1, 1, 1), 1f);

        alpha = sprite.color;
        Destroy(gameObject, 1f);
    }

    void Update()
    {
        // 알파값 변경
        //alpha.a = Mathf.Lerp(alpha.a, 0, alphaSpeed * Time.deltaTime);
        sprite.color = alpha;
    }
}
