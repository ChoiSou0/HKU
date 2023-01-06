using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robbing_Student_CS : MonoBehaviour
{

    bool is_Space = false; // �����̽��� �����ִ��� ����
    float NowInterval; // ���� ��� ����

    [SerializeField] GameObject TextArea;
    [SerializeField] GameObject Intan_Text;

    Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Ű���� �Է� ���� 0.2�ʱ��� ���
        if (Input.GetKeyDown(KeyCode.Space)) { 
            NowInterval = 0.2f;     // Ű �Է� ��� ���� ����
            RS_Manager.RSM.Space_Count++; // �����̽��� ī��Ʈ 1 �߰�
            Intan_txt(); // ������ �ؽ�Ʈ ����
            anim.SetBool("Robbing",true); // ���� �ʹ� �ִϸ��̼� ����
        }

        if (NowInterval <= 0) { is_Space = false; anim.SetBool("Robbing", false); }
        else { is_Space = true; NowInterval -= Time.deltaTime; }
    }

    void Intan_txt()
    {
        GameObject TX_ogj = Instantiate(Intan_Text, TextArea.transform.position, Quaternion.identity);
        TX_ogj.transform.SetParent(TextArea.transform);
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
