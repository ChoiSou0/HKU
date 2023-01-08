using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EndingTool;
using DG.Tweening;

[System.Serializable]
public class Clear
{
    public Tile ClearTile;
    public int ClearRotation;
}

public class StageClear : MonoBehaviour
{
    [SerializeField] private List<Clear> ClearList = new List<Clear>();
    [SerializeField] private int MaxComplete;
    [SerializeField] private int Complete;
    [SerializeField] private string CompleteSceneName;

    [SerializeField] private Image FadePanel;
    [SerializeField] private Image WarningPanel;
    [SerializeField] private Text CountDownText;
    [SerializeField] private Scrollbar TimeBar;
    [SerializeField] private float MaxTime;
    private bool TimeOn;
    private bool WarningOn = true;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        StartCoroutine(SetSetting());
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Warning();
        LimitTime();
    }

    public void Clear()
    {
        Complete = 0;

        for (int i = 0; i < ClearList.Count; i++)
        {
            if (ClearList[i].ClearTile.gameObject.transform.eulerAngles.z == ClearList[i].ClearRotation)
            {
                Complete++;
                
            }

        }
        Debug.Log(Complete);

        if (Complete == MaxComplete)
        {
            StartCoroutine(Ending.GoEnding("Hacking", (1 - TimeBar.size) * MaxTime, true, FadePanel));
        }
    }

    private void LimitTime()
    {
        if (TimeOn)
            TimeBar.size += Time.deltaTime / MaxTime;

        if (TimeBar.size >= 1)
        {
            WarningPanel.gameObject.SetActive(false);
            StartCoroutine(Ending.GoEnding("Hacking", (1 - TimeBar.size) * MaxTime, false, FadePanel));
        }

    }

    private void Warning()
    {
        if (WarningOn && TimeBar.size >= 0.9f)
        {
            WarningOn = false;
            WarningPanel.DOFade(0.7f, 0.5f).SetEase(Ease.OutQuad).SetLoops(-1, LoopType.Yoyo);
        }
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
        TimeOn = true;

        yield break;
    }

}
