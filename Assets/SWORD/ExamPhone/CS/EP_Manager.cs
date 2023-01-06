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
    public GameObject Instan_Pos;       // 키 생성할 위치
    public GameObject[] Set_Object;     // 키 오브젝트

    //================< Key_Object >================
    GameObject[] Key_Object = new GameObject[5];     // 키 오브젝트

    //================< Change_Image >================
    // 0 : 위 / 1 : 아래 / 2 : 왼쪽 / 3 : 오른쪽
    //public Sprite[] Change_Image;    // 방향키 이미지
    private int[] Key_Range = new int[5];

    //================< UI >================
    public TextMeshProUGUI Score_TMP;   // 현재 점수 표기
    public TextMeshProUGUI Time_TMP;    // 현재 점수 표기
    public float PlayTime;              // 플레이 타임

    //================< Develop >================
    public int NowKeyValue = 0; // 현재 이미지 위치 ■ □ □ □ 
    public int ScoreCount = 0;  // 점수

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
        NowKeyValue = 0; // 현재 위치값 초기화

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

        // 성공 시 반환
        if (Key_Range[NowKeyValue] == InputKeyValue)
        {
            Key_Object[NowKeyValue].GetComponent<Key_Object>().Call_Change_Sprite();
            Debug.Log("성공"); NowKeyValue++;

            // NowKeyValue가 4를 넘었다면 5개를 모두 맞춘 것이므로 키 배치 새로 불러오기
            if ( NowKeyValue > 4 ) { Invoke("Object_Destroy", 0.2f); ScoreCount++; }
        }

        else
        {
            // 실패 시 키 배치 새로 불러오기
            Debug.Log("실패");
            Object_Destroy();
        }
    }

    void UI_Setting()
    {
        // 점수 UI
        Score_TMP.text = "Score : " + ScoreCount;

        // 시간 UI
        PlayTime -= Time.deltaTime * 1;
        if ((int)PlayTime % 60 >= 10) { Time_TMP.text = ((int)PlayTime / 60).ToString() + " : " + ((int)PlayTime % 60).ToString(); }
        else Time_TMP.text = ((int)PlayTime / 60).ToString() + " : 0" + ((int)PlayTime % 60).ToString();
    }
}
