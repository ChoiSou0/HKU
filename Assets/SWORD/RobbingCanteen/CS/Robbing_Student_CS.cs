using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robbing_Student_CS : MonoBehaviour
{

    bool is_Space = false; // �����̽��� �����ִ��� ����
    float NowInterval; // ���� ��� ����


    Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Ű���� �Է� ���� 0.2�ʱ��� ���
        if (Input.GetKeyDown(KeyCode.Space)) { 
            NowInterval = 0.2f; 
            RS_Manager.RSM.Space_Count++;
            anim.SetBool("Robbing",true); 
        }

        if (NowInterval <= 0) { is_Space = false; anim.SetBool("Robbing", false); }
        else { is_Space = true; NowInterval -= Time.deltaTime; }

    }

    public void Caught_Check()
    {
        if (is_Space)
        {
            Debug.Log("�߰���");

            RS_Manager.RSM.Game_State = 'L';
        }
    }
}
