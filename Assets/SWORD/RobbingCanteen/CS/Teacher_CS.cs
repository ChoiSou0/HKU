using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher_CS : MonoBehaviour
{
    public bool RandTime_Set;  // 랜덤 시간 설정
    public float min_Time; // 랜덤 최소 시간
    public float max_Time; // 랜덤 최대 시간


    public bool Active_Time;    // 시간 보이기
    public float Trun_Time;   // 돌아보는 간격
    public float See_Time;    // 보고있는 시간
        
    bool On_Cast = true;
    void Start()
    {
        // 바라보는 시간 조정
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

        // 충돌한 물체가 학생일 때 실행
        if (hit.collider != null) hit.collider.gameObject.GetComponent<Robbing_Student_CS>().Caught_Check();
    }

    IEnumerator Trun_Teacher()
    {
        On_Cast = false;
        yield return new WaitForSeconds(Trun_Time);

        // 선생님 회전 <-0
        transform.localEulerAngles = new Vector2(0, 180);

        yield return new WaitForSeconds(See_Time);

        // 선생님 회전 0->
        transform.localEulerAngles = new Vector2(0, 0);

        // 바라보는 시간 조정
        Trun_Time = Random.Range(min_Time, max_Time);

        On_Cast = true;
        yield return null;
    }
}
