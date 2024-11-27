using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using LitJson;

public class UIManager
{
    readonly string panelPrefabPath = Application.dataPath + @"/Resources/UIPanelPrefab";
    //单例模式
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new UIManager();
            return _instance;
        }
    }

    private Transform canvasTransform;
    public Transform CanvasTransform
    {
        get
        {
            if (canvasTransform == null)
                canvasTransform = GameObject.Find("Canvas").transform;
            return canvasTransform;
        }
    }

    private UIManager()
    {
        //自动解析Json文件并赋值给panelList
        //并使用prefab文件夹下的信息对panelList进行更新,再写入json文件
        UIPanelInfoSaveInJson();

    }

    //列表储存UIPanel(UIPanelType,UIPanelPath)
    private List<UIPanel> panelList;

    //字典储存 面板类型:实例化面板 键值对
    private Dictionary<UIPanelType, BasePanel> panelDict;

    //栈储存当前页面的面板
    private Stack<BasePanel> panelStack;

    //把指定类型的panel入栈,并显示在场景中
    public void PushPanel(UIPanelType type)
    {
        if (panelStack == null)
            panelStack = new Stack<BasePanel>();

        //判断栈里是否有其他panel,若有,则把原栈顶panel暂停(OnPause)
        if (panelStack.Count > 0)
        {
            BasePanel topPanel = panelStack.Peek();
            topPanel.OnPause();
        }

        BasePanel panel = GetPanel(type);

        //把指定类型的panel入栈并进入场景(OnEnter)
        panelStack.Push(panel);
        panel.OnEnter();
    }

    //把栈顶panel出栈,并从场景中消失
    public void PopPanel()
    {
        if (panelStack == null)
            panelStack = new Stack<BasePanel>();

        if (panelStack.Count <= 0) return;

        BasePanel topPanel = panelStack.Pop();
        topPanel.OnExit();

        if (panelStack.Count <= 0) return;

        BasePanel topPanel2 = panelStack.Peek();
        topPanel2.OnResume();
    }


    public void UIPanelInfoSaveInJson()
    {
        DirectoryInfo folder = new DirectoryInfo(panelPrefabPath);

        panelList = ReadJsonFile();//读取现有json里的UIPanelList

       

        //WriteJsonFile(jsonPath, panelList);//把更新后的UIPanelList写入Json
//#if UNITY_EDITOR
//        AssetDatabase.Refresh();//刷新资源
//#endif
    }
    //给出面板类型 返回实例化面板的BasePanel组件()
    public BasePanel GetItem(UIPanelType type)
    {
        string path = panelList.SearchPanelForType(type).UIPanelPath;
        if (path == null)
            throw new Exception("找不到该UIPanelType的Prefab");

        if (Resources.Load(path) == null)
            throw new Exception("找不到该Path的Prefab");
        GameObject instPanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
        instPanel.GetComponent<BasePanel>().OnEnter();
        return instPanel.GetComponent<BasePanel>();
    }

    //给出面板类型 返回实例化面板的BasePanel组件()
    public BasePanel GetPanel(UIPanelType type)
    {
        if (panelDict == null)
            panelDict = new Dictionary<UIPanelType, BasePanel>();

        BasePanel panel = panelDict.TryGetValue(type);

        //在现有字典里没有找到
        //只能去json里找type对应的prefab的路径并加载
        //再加进字典里以便下次在字典中查找
        if (panel == null)
        {
            string path = panelList.SearchPanelForType(type).UIPanelPath;
            if (path == null)
                throw new Exception("找不到该UIPanelType的Prefab");

            if (Resources.Load(path) == null)
                throw new Exception("找不到该Path的Prefab");

            GameObject instPanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            instPanel.transform.SetParent(CanvasTransform, false);

            panelDict.Add(type, instPanel.GetComponent<BasePanel>());

            return instPanel.GetComponent<BasePanel>();
        }

        return panel;
    }

    //读取指定路径的json文件并返回List<UIPanel>列表
    public List<UIPanel> ReadJsonFile()
    {
      string path=  "UIPanelPrefab/";
        List<UIPanel> list = new List<UIPanel>();
        list.Add(new UIPanel(UIPanelType.UI_MainPanel, path + "UI_MainPanel"));
        list.Add(new UIPanel(UIPanelType.Item_MineralItem, path + "Item_MineralItem"));
        list.Add(new UIPanel(UIPanelType.Item_DevelopItem, path + "Item_DevelopItem"));
        list.Add(new UIPanel(UIPanelType.UI_DevelopPanel, path + "UI_DevelopPanel"));
        list.Add(new UIPanel(UIPanelType.UI_CustodianPanel, path + "UI_CustodianPanel"));
        list.Add(new UIPanel(UIPanelType.Item_CustodianItem, path + "Item_CustodianItem"));
        list.Add(new UIPanel(UIPanelType.UI_SellPanel, path + "UI_SellPanel"));
        return list;
    }

   

}
