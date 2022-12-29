using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Teacher_CS))]
public class TeacherEditor : Editor
{
    Teacher_CS teacher;

    SerializedProperty Setting_Prop;

    private void OnEnable()
    {
        teacher = target as Teacher_CS;
    }
    private void Awake()
    {
        Setting_Prop = serializedObject.FindProperty("setting");
    }

    public override void OnInspectorGUI()
    {

        EditorGUILayout.PropertyField(Setting_Prop);

        if((Teacher_CS.Setting)  Setting_Prop.enumValueIndex == Teacher_CS.Setting.None)
        { }
        if ((Teacher_CS.Setting) Setting_Prop.enumValueIndex == Teacher_CS.Setting.Rotate_Cast)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.PrefixLabel("���� ���� ( �ּ� / �ִ� )");
            teacher.min_Time = EditorGUILayout.FloatField(teacher.min_Time, GUILayout.Width(100));
            teacher.max_Time = EditorGUILayout.FloatField(teacher.max_Time, GUILayout.Width(100));
            EditorGUILayout.EndHorizontal();


            teacher.Trun_Time = EditorGUILayout.FloatField("���ƺ��� ����", teacher.Trun_Time);
            teacher.See_Time  = EditorGUILayout.FloatField("�����ִ� �ð�", teacher.See_Time);
        }
        if ((Teacher_CS.Setting) Setting_Prop.enumValueIndex == Teacher_CS.Setting.Rotate_Warning)
        {
            teacher.Warning_Times = EditorGUILayout.IntField  ("��� �ݺ� Ƚ��", teacher.Warning_Times);
            teacher.Warning_sec   = EditorGUILayout.FloatField("��� �ð�",      teacher.Warning_sec  );
        }

        serializedObject.ApplyModifiedProperties();
    }
}
