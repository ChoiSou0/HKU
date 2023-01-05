using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EP_Manager : MonoBehaviour
{
    public enum Setting
    {
        Key_Image,
        Change_Image,
        UI,
        Develop
    };

    public Setting setting;

    //================< Key_Image >================
    public Image[] Key_Image;       // Ű �̹����� �� �� �̹���

    //================< Change_Image >================
    // 0 : �� / 1 : �Ʒ� / 2 : ���� / 3 : ������
    public Sprite[] Change_Image;    // ����Ű �̹���
    private int[] Key_Range = new int[5];

    //================< UI >================
    public TextMeshProUGUI Score_TMP;   // ���� ���� ǥ��
    public TextMeshProUGUI Time_TMP;    // ���� ���� ǥ��
    public float PlayTime;          // �÷��� Ÿ��

    //================< Develop >================
    public int NowKeyValue = 0; // ���� �̹��� ��ġ �� �� �� �� 
    public int ScoreCount = 0;  // ����

    void Start()
    {
        Random_Setting();
    }

    void Update()
    {
        Input_Check();
        UI_Setting();
    }

    void Random_Setting()
    {
        NowKeyValue = 0; // ���� ��ġ�� �ʱ�ȭ

        for (int i = 0; i < Key_Image.Length; i++)
            Key_Range[i] = Random.Range(0, 4);

        for (int i = 0; i < Key_Image.Length; i++)
            Key_Image[i].sprite = Change_Image[Key_Range[i]];
    }
    void Input_Check()
    {
        int InputKeyValue = 100;

        if      (Input.GetKeyDown(KeyCode.UpArrow))     InputKeyValue = 0;
        else if (Input.GetKeyDown(KeyCode.DownArrow))   InputKeyValue = 1;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))   InputKeyValue = 2;
        else if (Input.GetKeyDown(KeyCode.RightArrow))  InputKeyValue = 3;


        if(InputKeyValue == 100) return;

        // ���� �� ��ȯ
        if (Key_Range[NowKeyValue] == InputKeyValue)
        {
            // NowKeyValue�� 4�� �Ѿ��ٸ� 5���� ��� ���� ���̹Ƿ� Ű ��ġ ���� �ҷ�����
            if ( NowKeyValue >= 4 ) { Random_Setting(); ScoreCount++; }

            // �ƴ� �� ��ġ���� 1 �߰��ϰ� ��ȯ
            else { Debug.Log("����"); NowKeyValue++; return; }
        }

        else
        {
            // ���� �� Ű ��ġ ���� �ҷ�����
            Debug.Log("����");
            Random_Setting();
        }
    }


    void UI_Setting()
    {
        Score_TMP.text = "Score : " + ScoreCount;
        Time_Count();

    }
    void Time_Count()
    {
        PlayTime -= Time.deltaTime * 1;
        if ((int)PlayTime % 60 >= 10) { Time_TMP.text = ((int)PlayTime / 60).ToString() + " : " + ((int)PlayTime % 60).ToString(); }
        else Time_TMP.text = ((int)PlayTime / 60).ToString() + " : 0" + ((int)PlayTime % 60).ToString();
    }
}
