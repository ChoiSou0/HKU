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

    // ���� ���� ����
    public char Game_State = 'R'; // R : ���� ������ , W : Ŭ���� , L : ���� ����


    public int Space_Count = 0; // �����̽��� ���� Ƚ��
    public float PlayTime; // �÷��� Ÿ��


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
