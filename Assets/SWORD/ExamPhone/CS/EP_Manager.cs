using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public GameObject[] Set_Object;     // Ű ������Ʈ

    //================< Key_Object >================
    GameObject[] Key_Object = new GameObject[5];     // Ű ������Ʈ

    //================< Change_Image >================
    // 0 : �� / 1 : �Ʒ� / 2 : ���� / 3 : ������
    //public Sprite[] Change_Image;    // ����Ű �̹���
    private int[] Key_Range = new int[5];

    //================< UI >================
    public TextMeshProUGUI Score_TMP;   // ���� ���� ǥ��
    public TextMeshProUGUI Time_TMP;    // ���� ���� ǥ��
    public float PlayTime;              // �÷��� Ÿ��

    //================< Develop >================
    public int NowKeyValue = 0; // ���� �̹��� ��ġ �� �� �� �� 
    public int ScoreCount = 0;  // ����

    void Awake()
    {
        //Instan_Pos = GameObject.Find("Border");
    }
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
            if ( NowKeyValue > 4 ) { Invoke("Object_Destroy", 0.2f); ScoreCount++; }
        }

        else
        {
            // ���� �� Ű ��ġ ���� �ҷ�����
            Debug.Log("����");
            Object_Destroy();
        }
    }

    void UI_Setting()
    {
        // ���� UI
        Score_TMP.text = "Score : " + ScoreCount;

        // �ð� UI
        PlayTime -= Time.deltaTime * 1;
        if ((int)PlayTime % 60 >= 10) { Time_TMP.text = ((int)PlayTime / 60).ToString() + " : " + ((int)PlayTime % 60).ToString(); }
        else Time_TMP.text = ((int)PlayTime / 60).ToString() + " : 0" + ((int)PlayTime % 60).ToString();
    }
}
