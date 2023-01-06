using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Up_Text : MonoBehaviour
{
    [SerializeField] string[] text;

    float MoveSpeed = 2;    // �ؽ�Ʈ �̵� �ӵ�
    float alphaSpeed = 2;   // ���İ� ��ȭ �ӵ� 

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
        // �ؽ�Ʈ ���� �������� ����
        int RN = Random.Range(0, text.Length);
        TMP.text = text[RN];

        // ������Ʈ �������� Ŀ���� ������ �־� ���� ������
        rectTransform.localScale = new Vector3(1, 1, 1);

        // ������Ʈ ���� �̵�
        transform.DOMoveY( MoveSpeed, 3f).SetEase(Ease.OutCirc);

        // �˹ٰ� �ʱ�ȭ
        alpha = TMP.color;

        // 3�ʵ� �ı��ϵ���
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        // ���İ� ����
        alpha.a = Mathf.Lerp(alpha.a, 0, alphaSpeed * Time.deltaTime);
        TMP.color = alpha;
    }
}
