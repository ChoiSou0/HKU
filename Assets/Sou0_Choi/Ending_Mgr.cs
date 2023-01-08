using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EndingTool;
using DG.Tweening;

public class Ending_Mgr : MonoBehaviour
{
    [SerializeField] private List<Sprite> EndingImageList = new List<Sprite>();
    [SerializeField] private Text GameResultText;
    [SerializeField] private Text ScoreText;
    [SerializeField] private Image EndingImage;

    private void Start()
    {
        StartCoroutine(SetSetting());
    }

    private IEnumerator SetSetting()
    {
        GameResultText.text = "";
        ScoreText.text = "";
        
        if (Ending.isClear)
        {
            GameResultText.DOText("클리어!", 0.5f).SetEase(Ease.OutQuad);
            switch (Ending.GameName)
            {

            }
        }
        else
        {
            GameResultText.DOText("게임오버!", 0.5f).SetEase(Ease.OutQuad);
            switch (Ending.GameName)
            {

            }
        }
        
        yield return new WaitForSecondsRealtime(0.5f);

        switch (Ending.GameName)
        {
            case "Hacking":
                ScoreText.DOText("남은 시간 : " + Mathf.Ceil(Ending.Score) + "초", 0.5f).SetEase(Ease.OutQuad);
                break;

            case "ExamPhone":
                ScoreText.DOText("성공 횟수 : " + Mathf.Ceil(Ending.Score) + "회", 0.5f).SetEase(Ease.OutQuad);
                break;

            case "RobbingCanteen":
                ScoreText.DOText("누른 횟수  : " + Mathf.Ceil(Ending.Score) + "번", 0.5f).SetEase(Ease.OutQuad);
                break;
        }

        yield break;
    }

    public void ClickReStart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Ending.GameName);
    }

    public void ClickExit()
    {
        Debug.Log("나가기");
    }

}

namespace EndingTool
{
    public class Ending : MonoBehaviour
    {
        public static string GameName;
        public static float Score;
        public static bool isClear;

        public static IEnumerator GoEnding(string gn, float s, bool c, Image Fade)
        {
            GameName = gn;
            Score = s;
            isClear = c;
            Fade.DOFade(1, 2).SetEase(Ease.OutQuad);
            yield return new WaitForSecondsRealtime(2);
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndingScene");
        }
    }
}
