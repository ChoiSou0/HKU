using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

using EndingTool;
public class EP_Manager : MonoBehaviour
{
    public enum Setting
    {
        Set_Object,
        UI,
        Develop
    };

    public Setting setting;

    //================< Set_Object >================
    public GameObject Instan_Pos;       // 키 생성할 위치
    public GameObject Reslut_Pos;       // 키 결과 생성 위치
    public GameObject[] Set_Object;     // 키 오브젝트
    public GameObject Great;    // 성공 시 나타나는 이미지
    public GameObject Miss;     // 실패 시 나타나는 이미지
    //================< Key_Object >================
    GameObject[] Key_Object = new GameObject[5];     // 키 오브젝트

    //================< Change_Image >================
    // 0 : 위 / 1 : 아래 / 2 : 왼쪽 / 3 : 오른쪽
    int[] Key_Range = new int[5]; // 카드를 지정하는 랜덤값 배열

    //================< UI >================
    public TextMeshProUGUI Score_TMP;   // 현재 점수 표기
    public TextMeshProUGUI Time_TMP;    // 현재 시간 표기 텍스트
    public Image Time_IMG;              // 현재 시간 표기 이미지
    public float PlayTime;              // 플레이 타임
    public float SetPlayTime;           // 플레이 타임 저장

    public Image FadePanel;             // 페이드 판넬
    public Text CountDownText;          // 페이드 숫자
    bool TimeOn = false;                // 게임 시작 판정

    //================< Develop >================
    public int NowKeyValue = 0; // 현재 이미지 위치 ■ □ □ □ 
    public int ScoreCount = 0;  // 점수
    public bool Is_Over = false; // 게임 오버 확인

    Animator P_Anim; // 플레이어 애니메이션

    void Awake()
    {
        P_Anim = GameObject.Find("Player").GetComponent<Animator>();
        SetPlayTime = PlayTime;
    }
    void Start()
    {
        StartCoroutine(SetSetting());

        Random_Setting();
    }

    void Update()
    {
        if (TimeOn && !Is_Over)
        {
            Input_Check();
            UI_Setting();
        }

        if (PlayTime <= 0 && !Is_Over)
        {
            Is_Over = true;
            StartCoroutine(Ending.GoEnding("ExamPhone", ScoreCount, true, FadePanel));
        }
    }

    void Random_Setting()
    {
        NowKeyValue = 0; // 현재 위치값 초기화

        for (int i = 0; i < Key_Object.Length; i++)
            Key_Range[i] = Random.Range(0, 4);

        for (int i = 0; i < 5; i++)
        {
            Key_Object[i] = Instantiate(Set_Object[Key_Range[i]], Instan_Pos.transform.position, Quaternion.identity);
            Key_Object[i].transform.SetParent(Instan_Pos.transform);
        }
    }

    void Object_Destroy()
    {
        for (int i = 0; i < Key_Object.Length; i++) Destroy(Key_Object[i]);
        Random_Setting();
    }

    void Input_Check()
    {
        int InputKeyValue = 100;

        // 몰폰 애니메이션 실행
        if (Input.anyKeyDown) P_Anim.SetTrigger("ING");

        if (Input.GetKeyDown(KeyCode.UpArrow)) InputKeyValue = 0;
        else if (Input.GetKeyDown(KeyCode.DownArrow)) InputKeyValue = 1;
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) InputKeyValue = 2;
        else if (Input.GetKeyDown(KeyCode.RightArrow)) InputKeyValue = 3;


        if (InputKeyValue == 100) return;

        // 성공 시 반환
        if (Key_Range[NowKeyValue] == InputKeyValue)
        {
            Key_Object[NowKeyValue].GetComponent<Key_Object>().Call_Change_Sprite();
            Debug.Log("성공"); NowKeyValue++;

            // NowKeyValue가 4를 넘었다면 5개를 모두 맞춘 것이므로 키 배치 새로 불러오기
            if (NowKeyValue > 4)
            {
                P_Anim.SetTrigger("Success");
                ScoreCount++;
                Invoke("Object_Destroy", 0.2f);

                GameObject Result = Instantiate(Great, transform.position = new Vector3(0, -1, 0), Quaternion.identity);
                Result.transform.SetParent(Reslut_Pos.transform);
            }
        }

        else
        {
            // 실패 시 키 배치 새로 불러오기
            Debug.Log("실패");

            P_Anim.SetTrigger("Failed");
            Object_Destroy();

            GameObject Result = Instantiate(Miss);
            Result.transform.SetParent(Reslut_Pos.transform);
        }
    }

    void UI_Setting()
    {
        if (!Is_Over)
        {
            // 점수 UI
            Score_TMP.text = "Score : " + ScoreCount;

            // 시간 UI
            PlayTime -= Time.deltaTime * 1;
            if ((int)PlayTime % 60 >= 10) { Time_TMP.text = ((int)PlayTime / 60).ToString() + " : " + ((int)PlayTime % 60).ToString(); }
            else Time_TMP.text = ((int)PlayTime / 60).ToString() + " : 0" + ((int)PlayTime % 60).ToString();

            Time_IMG.fillAmount = PlayTime / SetPlayTime;
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

        yield return new WaitForSecondsRealtime(0.5f);
        TimeOn = true;

        yield break;
    }
}
