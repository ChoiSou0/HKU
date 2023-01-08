using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher_CS : MonoBehaviour
{
    public enum Setting
    {
        None,
        Rotate_Cast,
        Rotate_Warning
    };

    // ===========< ������ ȸ�� �� Ž�� >=========
    public float min_Time;      // ���� �ּ� �ð�
    public float max_Time;      // ���� �ִ� �ð�

    public float Trun_Time;   // ���ƺ��� ����
    public float See_Time;    // �����ִ� �ð�

    // =============< ȸ�� ��� ���� >============
    public int Warning_Times;   // ��� �ݺ� Ƚ��
    public float Warning_sec;   // ��� ���̴� �ð�


    // ����
    public Setting setting;

    GameObject Warning_Obj;
    bool IsRight = true;    // ���� �� ������
    bool On_Cast = false;   // ���� �� ���� �߻�

    private void Awake()
    {
        Warning_Obj = GameObject.Find("Warning");
        Warning_Obj.SetActive(false);

        //StartCoroutine(Trun_Warning());
    }

    void Start()
    {
        // �ٶ󺸴� �ð� ����
        Trun_Time = Random.Range(min_Time, max_Time);
    }

    void Update()
    {
        if (RS_Manager.RSM.TimeOn)
        {
            if (On_Cast) Cast(); // ȸ�� ������ ���� ���� ���

            if (IsRight) StartCoroutine(Trun_Teacher());
        }
    }

    void Cast()
    {
        Debug.DrawRay(transform.position, transform.right * -10, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, -10, LayerMask.GetMask("Robbing_Student"));

        // �浹�� ��ü�� �л��� �� ����
        if (hit.collider != null) hit.collider.gameObject.GetComponent<Robbing_Student_CS>().Caught_Check();
    }
    
    IEnumerator Trun_Teacher()
    {
        bool Active = true;
        IsRight = false;

        yield return new WaitForSeconds(Trun_Time);

        // ������ Ƚ����ŭ ��� �ݺ�
        for (int i = 0; i < Warning_Times * 2; i++, Active = !Active)
        {
            Warning_Obj.SetActive(Active);
            yield return new WaitForSeconds( (Warning_sec / Warning_Times) * 0.5f );
        }

        // ������ ȸ�� <-0
        transform.localEulerAngles = new Vector2(0, 180);
        On_Cast = true;

        // ��� �����̴� �ð� ������ �� ����
        yield return new WaitForSeconds(See_Time + ((Warning_sec / Warning_Times) * 0.5f));

        // ������ ȸ�� 0->
        transform.localEulerAngles = new Vector2(0, 0);

        // �ٶ󺸴� �ð� ����
        Trun_Time = Random.Range(min_Time, max_Time);

        IsRight = true;
        On_Cast = false;
        yield return null;
    }   // ȸ�� ��� + ȸ��
}
