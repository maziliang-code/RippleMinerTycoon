using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExportUIScript : EditorWindow
{
    private static string exportString = "";
    private static Dictionary<string, string> uiTypeDic = new Dictionary<string, string>()
    {
        // ֻ��ȡ���±�ǩ�Ľڵ㣬�������±�ǩ�Ľڵ�����Լ����ǻ��ȡ�ӽڵ㣬��_��ͷ�ĺ����Լ����ӽڵ�
        {"Btn","Button"},   // btn_��ť��
        {"Img","Image"},
        {"GameObj","GameObject"},
        {"Text","TextMeshProUGUI"},
        {"Input","InputField"},
        {"Slider","Slider"},
        {"Scroll","ScrollRect"},
        {"Item","BasePanel"},
        {"UI","View"}, // ����Ϊ�ű���������ʽΪ ui_�ű���
    };

    [MenuItem("Tools/��ݵ���UI��� #&%Q")]
    private static void ShowWindow()
    {
        GetWindow(typeof(ExportUIScript));
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.red;
        style.fontSize = 18;
        GUIStyle style1 = new GUIStyle();
        style1.normal.textColor = Color.white;
        style1.fontSize = 15;

        EditorGUILayout.LabelField("ע�⣺��������", style);
        EditorGUILayout.Space(20);
        EditorGUILayout.LabelField("�� : Btn_�������", style);
        EditorGUILayout.LabelField("Btn,	Button", style1);
        EditorGUILayout.LabelField("Img,	Image", style1);
        EditorGUILayout.LabelField("GameObj,GameObject", style1);
        EditorGUILayout.LabelField("Text,	TextMeshProUGUI", style1);
        EditorGUILayout.LabelField("Input,	InputField", style1);
        EditorGUILayout.LabelField("Slider,	Slider", style1);
        EditorGUILayout.LabelField("Scroll,	ScrollRect", style1);
        EditorGUILayout.LabelField("UI,		View", style1);
        EditorGUILayout.LabelField("Item,		BasePanel", style1);
        EditorGUILayout.LabelField("����Ϊ�ű���������ʽΪ UI_�ű���", style);
        EditorGUILayout.Space(20);

        EditorGUILayout.LabelField("1. ��Ҫ��˫������Ԥ����", style);
        EditorGUILayout.LabelField("2. ѡ�������ɴ���Ľڵ�", style);
        EditorGUILayout.LabelField("3. �����ѡ��ڵ�, ��������ȫ����", style);
        EditorGUILayout.Space(20);

        if (GUILayout.Button("�����ű�����"))
        {
            ExportUIComp();
        }
    }
    private static void ExportUIComp()
    {
        var prefabStage = UnityEditor.SceneManagement.PrefabStageUtility.GetCurrentPrefabStage();
        if (prefabStage == null)
        {
            Debug.LogError("��ǰû�б༭Ԥ��, ��˫������Ԥ����, ��ʹ�ù��ߣ�");
            return;
        }
        exportString = "";

        GameObject basePrebabModal = AssetDatabase.LoadAssetAtPath(prefabStage.assetPath, typeof(GameObject)) as GameObject;

        exportString += "\n#region ui component\n";

        ExportUICompList(basePrebabModal.transform, "");

        exportString += "\npublic void Reset(BasePanel basePanel)\n" +
                        "{\n";
        ExportResetFunc(basePrebabModal.transform, "");

        exportString += "}\n";

        exportString += "\n#endregion\n";

        GUIUtility.systemCopyBuffer = exportString;
        Debug.Log(exportString);
        Debug.Log("�ѱ��浽������");
    }


    /// <summary>
    /// ����ui����б��ı���ui�����淶Ϊ "{uiTypeDic�е�ǰ׺}_{��������}"
    /// </summary>
    private static void ExportUICompList(Transform transform, string path = "")
    {
        var len = transform.childCount;
        for (var i = 0; i < len; i++)
        {
            var childTrans = transform.GetChild(i);
            var name = childTrans.name;
            var uiTypeArr = name.Split('_');
            string uiType = uiTypeArr[0];
            bool forChild = true;       // �Ƿ�ݹ��ӽڵ�
            bool ignore = false;      // �Ƿ���Ե�ǰ�ڵ�
            string typeName = "";
            if (!uiTypeDic.TryGetValue(uiType, out typeName))
            {
                ignore = true;
                // Debug.LogWarning("δ֪��ui����:" + uiType);
            }
            // ��Ҫ���⴦�������
            switch (uiType)
            {
                case "UI":
                    typeName = uiTypeArr[1];
                    forChild = false;
                    break;
                case "Scroll":
                    forChild = false;
                    break;
                case "":        // _name 
                    ignore = true;
                    forChild = false;
                    break;
                case "Item":
                    forChild = false; break;
            }

            if (!ignore)
            {
                string targetStr = $"[SerializeField] private {typeName} {name};\n";
                targetStr+= $"public {typeName} {uiTypeArr[1]}"+"{get =>"+ $"{ name};"
                + "}\n";
                if (exportString.IndexOf(targetStr) == -1)
                {
                    exportString += targetStr;
                }
                else
                {
                    Debug.LogError($"�ظ���������={name} path={path}");
                }

            }
            if (forChild)
            {
                ExportUICompList(childTrans, path + "/" + name);
            }

        }
    }

    private static void ExportResetFunc(Transform a_trans, string a_path)
    {
        var len = a_trans.childCount;
        for (var i = 0; i < len; i++)
        {
            var childTrans = a_trans.GetChild(i);
            var name = childTrans.name;
            var uiTypeArr = name.Split('_');
            string uiType = uiTypeArr[0];
            bool forChild = true;
            bool ignore = false;
            string typeName = "";
            if (!uiTypeDic.TryGetValue(uiType, out typeName))
            {
                ignore = true;
                // Debug.LogWarning("δ֪��ui����:" + uiType);
            }
            switch (uiType)
            {
                case "UI":
                    typeName = uiTypeArr[1];
                    forChild = false;
                    break;
                case "Scroll":
                    forChild = false;
                    break;
                case "": // ����
                    ignore = true;
                    forChild = false;
                    break;
                case "Item":
                    forChild = false; break;
            }

            if (!ignore)
            {
                string targetStr;

                if (a_path == "")
                {
                    if (uiType == "GameObj")
                    {
                        targetStr = $"{name} = basePanel.transform.Find(\"{name}\").gameObject;\n";
                    }
                    else
                    {
                        targetStr = $"{name} = basePanel.transform.Find(\"{name}\").GetComponent<{typeName}>();\n";
                    }
                }
                else
                {
                    if (uiType == "GameObj")
                    {
                        targetStr = $"{name} = basePanel.transform.Find(\"{a_path}/{name}\").gameObject;\n";
                    }
                    else
                    {
                        targetStr = $"{name} = basePanel.transform.Find(\"{a_path}/{name}\").GetComponent<{typeName}>();\n";
                    }
                }

                if (exportString.IndexOf(targetStr) == -1)
                {
                    exportString += targetStr;
                }
                else
                {
                    Debug.LogError($"�ظ���������={name} path={a_path}");
                }
            }
            if (forChild)
            {
                if (a_path == "")
                {
                    ExportResetFunc(childTrans, name);
                }
                else
                {
                    ExportResetFunc(childTrans, a_path + "/" + name);
                }
            }
        }
    }
}