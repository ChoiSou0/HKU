using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robbing_Student_CS : MonoBehaviour
{

    bool is_Space = false; // 스페이스가 눌려있는지 여부
    float NowInterval; // 현재 허용 간격

    void Start()
    {
        
    }

    void Update()
    {
        // 키보드 입력 간격 0.2초까지 허용
        if (Input.GetKeyDown(KeyCode.Space)) { NowInterval = 0.2f; RS_Manager.RSM.Space_Count++; }

        if (NowInterval <= 0) is_Space = false;
        else { is_Space = true; NowInterval -= Time.deltaTime; }

    }

    public void Caught_Check()
    {
        if (is_Space)
        {
            Debug.Log("발각됨");

            RS_Manager.RSM.Game_State = 'L';
        }
    }
}
