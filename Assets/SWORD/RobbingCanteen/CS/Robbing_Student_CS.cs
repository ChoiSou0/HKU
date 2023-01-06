using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robbing_Student_CS : MonoBehaviour
{

    bool is_Space = false; // 스페이스가 눌려있는지 여부
    float NowInterval; // 현재 허용 간격

    [SerializeField] GameObject TextArea;
    [SerializeField] GameObject Intan_Text;

    Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // 키보드 입력 간격 0.2초까지 허용
        if (Input.GetKeyDown(KeyCode.Space)) { 
            NowInterval = 0.2f;     // 키 입력 허용 범위 지정
            RS_Manager.RSM.Space_Count++; // 스페이스바 카운트 1 추가
            Intan_txt(); // 아이템 텍스트 띄우기
            anim.SetBool("Robbing",true); // 물건 터는 애니메이션 실행
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
            Debug.Log("발각됨");

            RS_Manager.RSM.Game_State = 'L';
        }
    }
}
