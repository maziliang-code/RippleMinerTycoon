using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExportUIScript : EditorWindow
{
    private static string exportString = "";
    private static Dictionary<string, string> uiTypeDic = new Dictionary<string, string>()
    {
        // 只读取以下标签的节点，不是以下标签的节点忽略自己但是会读取子节点，以_开头的忽略自己和子节点
        {"Btn","Button"},   // btn_按钮名
        {"Img","Image"},
        {"GameObj","GameObject"},
        {"Text","TextMeshProUGUI"},
        {"Input","InputField"},
        {"Slider","Slider"},
        {"Scroll","ScrollRect"},
        {"Item","BasePanel"},
        {"UI","View"}, // 类型为脚本，命名格式为 ui_脚本名
    };

    [MenuItem("Tools/快捷导出UI组件 #&%Q")]
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

        EditorGUILayout.LabelField("注意：命名规则", style);
        EditorGUILayout.Space(20);
        EditorGUILayout.LabelField("例 : Btn_你的命名", style);
        EditorGUILayout.LabelField("Btn,	Button", style1);
        EditorGUILayout.LabelField("Img,	Image", style1);
        EditorGUILayout.LabelField("GameObj,GameObject", style1);
        EditorGUILayout.LabelField("Text,	TextMeshProUGUI", style1);
        EditorGUILayout.LabelField("Input,	InputField", style1);
        EditorGUILayout.LabelField("Slider,	Slider", style1);
        EditorGUILayout.LabelField("Scroll,	ScrollRect", style1);
        EditorGUILayout.LabelField("UI,		View", style1);
        EditorGUILayout.LabelField("Item,		BasePanel", style1);
        EditorGUILayout.LabelField("类型为脚本，命名格式为 UI_脚本名", style);
        EditorGUILayout.Space(20);

        EditorGUILayout.LabelField("1. 需要先双击进入预制体", style);
        EditorGUILayout.LabelField("2. 选择想生成代码的节点", style);
        EditorGUILayout.LabelField("3. 如果不选择节点, 即按规则全生成", style);
        EditorGUILayout.Space(20);

        if (GUILayout.Button("导出脚本代码"))
        {
            ExportUIComp();
        }
    }
    private static void ExportUIComp()
    {
        var prefabStage = UnityEditor.SceneManagement.PrefabStageUtility.GetCurrentPrefabStage();
        if (prefabStage == null)
        {
            Debug.LogError("当前没有编辑预设, 请双击进入预制体, 再使用工具！");
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
        Debug.Log("已保存到剪贴板");
    }


    /// <summary>
    /// 导出ui组件列表文本，ui命名规范为 "{uiTypeDic中的前缀}_{任意名字}"
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
            bool forChild = true;       // 是否递归子节点
            bool ignore = false;      // 是否忽略当前节点
            string typeName = "";
            if (!uiTypeDic.TryGetValue(uiType, out typeName))
            {
                ignore = true;
                // Debug.LogWarning("未知的ui类型:" + uiType);
            }
            // 需要特殊处理的类型
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
                    Debug.LogError($"重复的属性名={name} path={path}");
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
                // Debug.LogWarning("未知的ui类型:" + uiType);
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
                case "": // 跳过
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
                    Debug.LogError($"重复的属性名={name} path={a_path}");
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