using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher_CS : MonoBehaviour
{
    public bool RandTime_Set;  // ���� �ð� ����
    public float min_Time; // ���� �ּ� �ð�
    public float max_Time; // ���� �ִ� �ð�


    public bool Active_Time;    // �ð� ���̱�
    public float Trun_Time;   // ���ƺ��� ����
    public float See_Time;    // �����ִ� �ð�
        
    bool On_Cast = true;
    void Start()
    {
        // �ٶ󺸴� �ð� ����
        Trun_Time = Random.Range(min_Time, max_Time);
    }

    void Update()
    {
        Cast();
        if (On_Cast) StartCoroutine(Trun_Teacher());
    }

    void Cast()
    {
        Debug.DrawRay(transform.position, transform.right * 10, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 20, LayerMask.GetMask("Robbing_Student"));

        // �浹�� ��ü�� �л��� �� ����
        if (hit.collider != null) hit.collider.gameObject.GetComponent<Robbing_Student_CS>().Caught_Check();
    }

    IEnumerator Trun_Teacher()
    {
        On_Cast = false;
        yield return new WaitForSeconds(Trun_Time);

        // ������ ȸ�� <-0
        transform.localEulerAngles = new Vector2(0, 180);

        yield return new WaitForSeconds(See_Time);

        // ������ ȸ�� 0->
        transform.localEulerAngles = new Vector2(0, 0);

        // �ٶ󺸴� �ð� ����
        Trun_Time = Random.Range(min_Time, max_Time);

        On_Cast = true;
        yield return null;
    }
}
