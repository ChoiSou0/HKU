using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EP_Manager))]
public class EP_ManagerEditor : Editor
{
    // 시작 열거형
    SerializedProperty Setting_Prop;

    //================< Key_Image >================
    SerializedProperty Instan_Pos_Prop;
    SerializedProperty Reslut_Pos_Prop;
    SerializedProperty Set_Object_Prop;
    SerializedProperty Great_Prop;
    SerializedProperty Miss_Prop;

    //================< UI >================
    SerializedProperty Score_Prop;
    SerializedProperty Time_Prop;
    SerializedProperty Time_IMG_Prop;
    SerializedProperty PlayTime_Prop;
    SerializedProperty FadePanel_Prop;
    SerializedProperty CountDownText_Prop;

    //================< Develop >================
    SerializedProperty NowKeyValue_Prop;

    private void Awake()
    {
        Setting_Prop = serializedObject.FindProperty("setting");

        Instan_Pos_Prop = serializedObject.FindProperty("Instan_Pos");
        Reslut_Pos_Prop = serializedObject.FindProperty("Reslut_Pos");
        Set_Object_Prop = serializedObject.FindProperty("Set_Object");
        Great_Prop = serializedObject.FindProperty("Great");
        Miss_Prop = serializedObject.FindProperty("Miss");

        Score_Prop = serializedObject.FindProperty("Score_TMP");
        Time_Prop = serializedObject.FindProperty("Time_TMP");
        Time_IMG_Prop = serializedObject.FindProperty("Time_IMG");
        PlayTime_Prop = serializedObject.FindProperty("PlayTime");
        FadePanel_Prop = serializedObject.FindProperty("FadePanel");
        CountDownText_Prop = serializedObject.FindProperty("CountDownText");

        NowKeyValue_Prop = serializedObject.FindProperty("NowKeyValue");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(Setting_Prop);

        if ((EP_Manager.Setting)Setting_Prop.enumValueIndex == EP_Manager.Setting.Set_Object)
        {
            EditorGUILayout.PropertyField(Instan_Pos_Prop);
            EditorGUILayout.PropertyField(Reslut_Pos_Prop);
            EditorGUILayout.PropertyField(Set_Object_Prop);
            EditorGUILayout.PropertyField(Great_Prop);
            EditorGUILayout.PropertyField(Miss_Prop);
        }

        if ((EP_Manager.Setting)Setting_Prop.enumValueIndex == EP_Manager.Setting.UI)
        {
            EditorGUILayout.PropertyField(Score_Prop);
            EditorGUILayout.PropertyField(Time_Prop);
            EditorGUILayout.PropertyField(Time_IMG_Prop);
            EditorGUILayout.PropertyField(PlayTime_Prop);
            EditorGUILayout.PropertyField(FadePanel_Prop);
            EditorGUILayout.PropertyField(CountDownText_Prop);
        }

        if ((EP_Manager.Setting)Setting_Prop.enumValueIndex == EP_Manager.Setting.Develop)
            EditorGUILayout.PropertyField(NowKeyValue_Prop);

        serializedObject.ApplyModifiedProperties();
    }
}
