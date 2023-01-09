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

    // 현재 게임 상태
    public char Game_State = 'R'; // R : 게임 진행중 , W : 클리어 , L : 게임 오버


    public int Space_Count = 0; // 스페이스바 누른 횟수
    public float PlayTime;  // 플레이 타임
    float SetPlayTime;      // 플레이 타임 저장


    public TextMeshProUGUI Time_Text;
    public Image Time_IMG;
    public TextMeshProUGUI Space_Count_Text;


    public Image FadePanel;             // 페이드 판넬
    public Text CountDownText;          // 페이드 숫자
    public bool TimeOn = false;                // 게임 시작 판정

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
        if (PlayTime <= 0 && Game_State != 'W') { Game_State = 'W'; }

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
