using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EP_Manager))]
public class EP_ManagerEditor : Editor
{
    EP_Manager EPM;

    // 시작 열거형
    SerializedProperty Setting_Prop;

    //================< Key_Image >================
    SerializedProperty Instan_Pos_Prop;
    SerializedProperty Set_Object_Prop;

    //================< UI >================
    SerializedProperty Score_Prop;
    SerializedProperty Time_Prop;
    SerializedProperty PlayTime_Prop;

    //================< Develop >================
    SerializedProperty NowKeyValue_Prop;


    private void OnEnable()
    {
        EPM = target as EP_Manager;
    }

    private void Awake()
    {
        Setting_Prop = serializedObject.FindProperty("setting");
        Instan_Pos_Prop = serializedObject.FindProperty("Instan_Pos");
        Set_Object_Prop = serializedObject.FindProperty("Set_Object");
        NowKeyValue_Prop = serializedObject.FindProperty("NowKeyValue");
        Score_Prop = serializedObject.FindProperty("Score_TMP");
        Time_Prop = serializedObject.FindProperty("Time_TMP");
        PlayTime_Prop = serializedObject.FindProperty("PlayTime");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(Setting_Prop);

        if ((EP_Manager.Setting)Setting_Prop.enumValueIndex == EP_Manager.Setting.Set_Object)
        {
            EditorGUILayout.PropertyField(Instan_Pos_Prop);
            EditorGUILayout.PropertyField(Set_Object_Prop);
        }

        if ((EP_Manager.Setting)Setting_Prop.enumValueIndex == EP_Manager.Setting.UI)
        {
            EditorGUILayout.PropertyField(Score_Prop);
            EditorGUILayout.PropertyField(Time_Prop);
            EditorGUILayout.PropertyField(PlayTime_Prop);
        }

        if ((EP_Manager.Setting)Setting_Prop.enumValueIndex == EP_Manager.Setting.Develop)
            EditorGUILayout.PropertyField(NowKeyValue_Prop);

        serializedObject.ApplyModifiedProperties();
    }
}
