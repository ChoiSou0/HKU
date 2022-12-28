using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Teacher_CS))]
public class TeacherEditor : Editor
{
    Teacher_CS teacher;

    SerializedProperty RandTime_Set_Prop;
    SerializedProperty ActiveTime_Prop;

    private void OnEnable()
    {
        teacher = target as Teacher_CS;
    }
    private void Awake()
    {
        RandTime_Set_Prop = serializedObject.FindProperty("RandTime_Set");
        ActiveTime_Prop = serializedObject.FindProperty("Active_Time");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(RandTime_Set_Prop);
        EditorGUILayout.PropertyField(ActiveTime_Prop);

        if(RandTime_Set_Prop.boolValue)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.PrefixLabel("랜덤 범위 ( 최소 / 최대 )");
            teacher.min_Time = EditorGUILayout.FloatField(teacher.min_Time);
            teacher.max_Time = EditorGUILayout.FloatField(teacher.max_Time);

            EditorGUILayout.EndHorizontal();
        }

        if (ActiveTime_Prop.boolValue)
        {
            teacher.Trun_Time = EditorGUILayout.FloatField("돌아보는 간격", teacher.Trun_Time); 
            teacher.See_Time  = EditorGUILayout.FloatField("보고있는 시간", teacher.See_Time); 
        }

        serializedObject.ApplyModifiedProperties();
    }
}
