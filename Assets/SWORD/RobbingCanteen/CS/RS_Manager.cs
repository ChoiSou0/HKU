using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

using EndingTool;

public class RS_Manager : MonoBehaviour
{
    public static RS_Manager RSM = null;

    public enum Setting
    {
        None,
        numSet,
        UI,
    };

    public Setting setting;

    // ���� ���� ����
    public char Game_State = 'R'; // R : ���� ������ , W : Ŭ���� , L : ���� ����


    public int Space_Count = 0; // �����̽��� ���� Ƚ��
    public float PlayTime;  // �÷��� Ÿ��
    float SetPlayTime;      // �÷��� Ÿ�� ����


    public TextMeshProUGUI Time_Text;
    public Image Time_IMG;
    public TextMeshProUGUI Space_Count_Text;


    public Image FadePanel;             // ���̵� �ǳ�
    public Text CountDownText;          // ���̵� ����
    public bool TimeOn = false;                // ���� ���� ����

    private void Awake()
    {
        RSM = this;
    }
    void Start()
    {
        SetPlayTime = PlayTime;

        StartCoroutine(SetSetting());
    }

    void Update()
    {
        if (TimeOn)
        {
            Time_Count();
            Space_Count_Text.text = "Score : " + Space_Count;

            if (Game_State == 'W')
            { StartCoroutine(Ending.GoEnding("RobbingCanteen", Space_Count, true, FadePanel)); }

            if (Game_State == 'L')
            { StartCoroutine(Ending.GoEnding("RobbingCanteen", Space_Count, false, FadePanel)); }
        }
    }

    void Time_Count()
    {
        if (Game_State == 'R') PlayTime -= Time.deltaTime * 1;

        if ((int)PlayTime % 60 >= 10) { Time_Text.text = ((int)PlayTime / 60).ToString() + " : " + ((int)PlayTime % 60).ToString(); }
        else Time_Text.text = ((int)PlayTime / 60).ToString() + " : 0" + ((int)PlayTime % 60).ToString();

        Time_IMG.fillAmount = PlayTime / SetPlayTime;
    }

    IEnumerator SetSetting()
    {
        FadePanel.color = new Color(0, 0, 0, 1);

        FadePanel.DOFade(0, 1.5f).SetEase(Ease.OutQuad);
        yield return new WaitForSecondsRealtime(1f);

        CountDownText.DOText("3", 1).SetEase(Ease.OutQuad);
        yield return new WaitForSecondsRealtime(1f);

        CountDownText.DOText("2", 1).SetEase(Ease.OutQuad);
        yield return new WaitForSecondsRealtime(1f);

        CountDownText.DOText("1", 1).SetEase(Ease.OutQuad);
        yield return new WaitForSecondsRealtime(1f);

        CountDownText.DOText("Start!", 0.1f).SetEase(Ease.OutQuad);
        CountDownText.DOFade(0, 2f).SetEase(Ease.OutQuad);

        yield return new WaitForSecondsRealtime(0.5f);
        TimeOn = true;

        yield break;
    }
}
