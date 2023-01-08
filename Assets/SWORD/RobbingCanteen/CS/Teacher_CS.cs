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

    // ===========< 선생님 회전 및 탐지 >=========
    public float min_Time;      // 랜덤 최소 시간
    public float max_Time;      // 랜덤 최대 시간

    public float Trun_Time;   // 돌아보는 간격
    public float See_Time;    // 보고있는 시간

    // =============< 회전 경고 관리 >============
    public int Warning_Times;   // 경고 반복 횟수
    public float Warning_sec;   // 경고 보이는 시간


    // 내부
    public Setting setting;

    GameObject Warning_Obj;
    bool IsRight = true;    // 참일 때 오른쪽
    bool On_Cast = false;   // 참일 때 레이 발사

    private void Awake()
    {
        Warning_Obj = GameObject.Find("Warning");
        Warning_Obj.SetActive(false);

        //StartCoroutine(Trun_Warning());
    }

    void Start()
    {
        // 바라보는 시간 조정
        Trun_Time = Random.Range(min_Time, max_Time);
    }

    void Update()
    {
        if (RS_Manager.RSM.TimeOn)
        {
            if (On_Cast) Cast(); // 회전 상태일 때만 레이 쏘기

            if (IsRight) StartCoroutine(Trun_Teacher());
        }
    }

    void Cast()
    {
        Debug.DrawRay(transform.position, transform.right * -10, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, -10, LayerMask.GetMask("Robbing_Student"));

        // 충돌한 물체가 학생일 때 실행
        if (hit.collider != null) hit.collider.gameObject.GetComponent<Robbing_Student_CS>().Caught_Check();
    }
    
    IEnumerator Trun_Teacher()
    {
        bool Active = true;
        IsRight = false;

        yield return new WaitForSeconds(Trun_Time);

        // 정해진 횟수만큼 경고 반복
        for (int i = 0; i < Warning_Times * 2; i++, Active = !Active)
        {
            Warning_Obj.SetActive(Active);
            yield return new WaitForSeconds( (Warning_sec / Warning_Times) * 0.5f );
        }

        // 선생님 회전 <-0
        transform.localEulerAngles = new Vector2(0, 180);
        On_Cast = true;

        // 경고 깜빡이는 시간 보정이 들어간 것임
        yield return new WaitForSeconds(See_Time + ((Warning_sec / Warning_Times) * 0.5f));

        // 선생님 회전 0->
        transform.localEulerAngles = new Vector2(0, 0);

        // 바라보는 시간 조정
        Trun_Time = Random.Range(min_Time, max_Time);

        IsRight = true;
        On_Cast = false;
        yield return null;
    }   // 회전 경고 + 회전
}
