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
            GameResultText.DOText("Ŭ����!", 0.5f).SetEase(Ease.OutQuad);
            switch (Ending.GameName)
            {

            }
        }
        else
        {
            GameResultText.DOText("���ӿ���!", 0.5f).SetEase(Ease.OutQuad);
            switch (Ending.GameName)
            {

            }
        }
        
        yield return new WaitForSecondsRealtime(0.5f);

        switch (Ending.GameName)
        {
            case "Hacking":
                ScoreText.DOText("���� �ð� : " + Mathf.Ceil(Ending.Score) + "��", 0.5f).SetEase(Ease.OutQuad);
                break;

            case "ExamPhone":
                ScoreText.DOText("���� Ƚ�� : " + Mathf.Ceil(Ending.Score) + "ȸ", 0.5f).SetEase(Ease.OutQuad);
                break;

            case "RobbingCanteen":
                ScoreText.DOText("���� Ƚ��  : " + Mathf.Ceil(Ending.Score) + "��", 0.5f).SetEase(Ease.OutQuad);
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
        Debug.Log("������");
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
