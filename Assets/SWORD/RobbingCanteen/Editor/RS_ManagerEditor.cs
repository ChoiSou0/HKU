using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RS_Manager))]
public class RS_ManagerEditor : Editor
{
    RS_Manager RSM;

    SerializedProperty Setting_Prop;
    SerializedProperty Game_State_Prop;
    SerializedProperty Time_Text_Prop;
    SerializedProperty Space_Count_Text_Prop;
   
    private void OnEnable()
    {
        RSM = target as RS_Manager;
    }

    private void Awake()
    {
        Setting_Prop = serializedObject.FindProperty("setting");
        Game_State_Prop = serializedObject.FindProperty("Game_State");
        Time_Text_Prop = serializedObject.FindProperty("Time_Text");
        Space_Count_Text_Prop = serializedObject.FindProperty("Space_Count_Text");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(Setting_Prop);

        if ((RS_Manager.Setting)Setting_Prop.enumValueIndex == RS_Manager.Setting.None)
        {
            EditorGUILayout.PropertyField(Game_State_Prop);
        }

        if ((RS_Manager.Setting)Setting_Prop.enumValueIndex == RS_Manager.Setting.numSet)
        {
            RSM.Space_Count = EditorGUILayout.IntField("스페이스바 누른 횟수", RSM.Space_Count);
            RSM.PlayTime = EditorGUILayout.FloatField("플레이 타임", RSM.PlayTime);
        }

        if ((RS_Manager.Setting)Setting_Prop.enumValueIndex == RS_Manager.Setting.TMP)
        {
            EditorGUILayout.PropertyField(Time_Text_Prop);
            EditorGUILayout.PropertyField(Space_Count_Text_Prop);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
