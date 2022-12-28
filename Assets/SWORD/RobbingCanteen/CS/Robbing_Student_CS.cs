using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robbing_Student_CS : MonoBehaviour
{
    bool is_Space = false;
    void Start()
    {
        
    }

    void Update()
    {
        Input_Check();
    }

    void Input_Check()
    {
        if (Input.GetKeyDown(KeyCode.Space)) is_Space = true;

        if (Input.GetKeyUp(KeyCode.Space)) is_Space = false;

    }

    public void Caught_Check()
    {
        if (is_Space) Debug.Log("¹ß°¢µÊ");
    }
}
