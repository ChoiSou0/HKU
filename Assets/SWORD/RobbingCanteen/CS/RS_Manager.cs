using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RS_Manager : MonoBehaviour
{
    public static RS_Manager RSM = null;

    public enum Setting
    {
        None,
        numSet,
        TMP,
    };

    public Setting setting;

    // 현재 게임 상태
    public char Game_State = 'R'; // R : 게임 진행중 , W : 클리어 , L : 게임 오버


    public int Space_Count = 0; // 스페이스바 누른 횟수
    public float PlayTime; // 플레이 타임


    public TextMeshProUGUI Time_Text;
    public TextMeshProUGUI Space_Count_Text;
    
    private void Awake()
    {
        RSM = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
        Time_Count();
        Space_Count_Text.text = "Point : " + Space_Count;


        if (Game_State == 'W')
        { }

        if (Game_State == 'L')
        { }


    }

    void Time_Count()
    {
        if (Game_State == 'R') PlayTime -= Time.deltaTime * 1;

        if ((int)PlayTime % 60 >= 10) { Time_Text.text = ((int)PlayTime / 60).ToString() + " : " + ((int)PlayTime % 60).ToString(); }
        else Time_Text.text = ((int)PlayTime / 60).ToString() + " : 0" + ((int)PlayTime % 60).ToString();
    }
}
