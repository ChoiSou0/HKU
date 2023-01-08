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
    public GameObject Instan_Pos;       // Ű ������ ��ġ
    public GameObject Reslut_Pos;       // Ű ��� ���� ��ġ
    public GameObject[] Set_Object;     // Ű ������Ʈ
    public GameObject Great;    // ���� �� ��Ÿ���� �̹���
    public GameObject Miss;     // ���� �� ��Ÿ���� �̹���
    //================< Key_Object >================
    GameObject[] Key_Object = new GameObject[5];     // Ű ������Ʈ

    //================< Change_Image >================
    // 0 : �� / 1 : �Ʒ� / 2 : ���� / 3 : ������
    int[] Key_Range = new int[5]; // ī�带 �����ϴ� ������ �迭

    //================< UI >================
    public TextMeshProUGUI Score_TMP;   // ���� ���� ǥ��
    public TextMeshProUGUI Time_TMP;    // ���� �ð� ǥ�� �ؽ�Ʈ
    public Image Time_IMG;              // ���� �ð� ǥ�� �̹���
    public float PlayTime;              // �÷��� Ÿ��
    public float SetPlayTime;           // �÷��� Ÿ�� ����

    public Image FadePanel;             // ���̵� �ǳ�
    public Text CountDownText;          // ���̵� ����
    bool TimeOn = false;                // ���� ���� ����

    //================< Develop >================
    public int NowKeyValue = 0; // ���� �̹��� ��ġ �� �� �� �� 
    public int ScoreCount = 0;  // ����
    public bool Is_Over = false; // ���� ���� Ȯ��

    Animator P_Anim; // �÷��̾� �ִϸ��̼�

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
        if(TimeOn && !Is_Over)
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
        NowKeyValue = 0; // ���� ��ġ�� �ʱ�ȭ

        for (int i = 0; i < Key_Object.Length; i++)
            Key_Range[i] = Random.Range(0, 4);

        for (int i = 0; i < 5; i++)
        {
            Key_Object[i] = Instantiate(Set_Object[ Key_Range[i] ], Instan_Pos.transform.position, Quaternion.identity);
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

        // ���� �ִϸ��̼� ����
        if (Input.anyKeyDown) P_Anim.SetTrigger("ING");

        if      (Input.GetKeyDown(KeyCode.UpArrow))     InputKeyValue = 0;
        else if (Input.GetKeyDown(KeyCode.DownArrow))   InputKeyValue = 1;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))   InputKeyValue = 2;
        else if (Input.GetKeyDown(KeyCode.RightArrow))  InputKeyValue = 3;


        if(InputKeyValue == 100) return;

        // ���� �� ��ȯ
        if (Key_Range[NowKeyValue] == InputKeyValue)
        {
            Key_Object[NowKeyValue].GetComponent<Key_Object>().Call_Change_Sprite();
            Debug.Log("����"); NowKeyValue++;

            // NowKeyValue�� 4�� �Ѿ��ٸ� 5���� ��� ���� ���̹Ƿ� Ű ��ġ ���� �ҷ�����
            if ( NowKeyValue > 4 ) 
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
            // ���� �� Ű ��ġ ���� �ҷ�����
            Debug.Log("����");

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
            // ���� UI
            Score_TMP.text = "Score : " + ScoreCount;

            // �ð� UI
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
