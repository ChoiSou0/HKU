using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Up_Text : MonoBehaviour
{
    [SerializeField] string[] text;

    float MoveSpeed = 2;    // 텍스트 이동 속도
    float alphaSpeed = 2;   // 알파값 변화 속도 

    TextMeshProUGUI TMP;
    Color alpha;

    private RectTransform rectTransform;
    private void Awake()
    {
        TMP = GetComponent<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        // 텍스트 내용 랜덤으로 지정
        int RN = Random.Range(0, text.Length);
        TMP.text = text[RN];

        // 오브젝트 스케일이 커지는 문제가 있어 따로 조정함
        rectTransform.localScale = new Vector3(1, 1, 1);

        // 오브젝트 위로 이동
        transform.DOMoveY( MoveSpeed, 3f).SetEase(Ease.OutCirc);

        // 알바값 초기화
        alpha = TMP.color;

        // 3초뒤 파괴하도록
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        // 알파값 변경
        alpha.a = Mathf.Lerp(alpha.a, 0, alphaSpeed * Time.deltaTime);
        TMP.color = alpha;
    }
}
