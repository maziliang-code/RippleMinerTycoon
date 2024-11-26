using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using LitJson;
using UnityEngine;

public class DispositionManager
{
    private static DispositionManager _instance;
    public static DispositionManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new DispositionManager();
            return _instance;
        }
    }
    advertisements m_Advertisements;
    public advertisements Advertisements { get => m_Advertisements; }

    conditions m_Conditions;
    public conditions Conditions { get => m_Conditions; }

    constants m_Constants;
    public constants Constants { get => m_Constants; }

    develops m_Develops;
    public develops Develops { get => m_Develops; }

    languages m_Languages;
    public languages Languages { get => m_Languages; }
    managers m_Managers;
    public managers Managers { get => m_Managers; }

    mines m_Mines;
    public mines Mines { get => m_Mines; }

    props m_Props;
    public props Props { get => m_Props; }
    public void Init()
    {
        ReadAdvertisementsJsonFile();
        ReadConditionsJsonFile();
        ReadConstantsJsonFile();
        ReadDevelopsJsonFile();
        ReadPropsJsonFile();
        ReadMinesJsonFile();
        ReadManagersJsonFile();
        ReadLanguagesJsonFile();
    }
    public void ReadPropsJsonFile()
    {
        string jsonPath = "Json/"+"prop";
        m_Props = new props();
        m_Props.info = JsonMapper.ToObject<List<prop>>(Resources.Load<TextAsset>(jsonPath).ToString());
    }
    public void ReadMinesJsonFile()
    {
        string jsonPath = "Json/" + "mine";
        m_Mines = new mines();
        m_Mines.info = JsonMapper.ToObject<List<mine>>(Resources.Load<TextAsset>(jsonPath ).ToString());
    }

    public void ReadManagersJsonFile()
    {
        string jsonPath = "Json/" + "manager";
        m_Managers = new managers();
        m_Managers.info = JsonMapper.ToObject<List<manager>>(Resources.Load<TextAsset>(jsonPath).ToString());
    }

    public void ReadLanguagesJsonFile()
    {
        string jsonPath = "Json/" + "language";
        m_Languages = new languages();
        m_Languages.info = JsonMapper.ToObject<List<language>>(Resources.Load<TextAsset>(jsonPath).ToString());
    }
    public void ReadDevelopsJsonFile()
    {
        string jsonPath = "Json/" + "develop";
        m_Develops = new develops();
        m_Develops.info = JsonMapper.ToObject<List<develop>>(Resources.Load<TextAsset>(jsonPath).ToString());
    }

    public void ReadConstantsJsonFile()
    {
        string jsonPath = "Json/" + "constant";
        m_Constants = new constants();
        m_Constants.info = JsonMapper.ToObject<List<constant>>(Resources.Load<TextAsset>(jsonPath).ToString());
    }

    public void ReadConditionsJsonFile()
    {
        string jsonPath = "Json/" + "condition";
        m_Conditions = new conditions();
        m_Conditions.info = JsonMapper.ToObject<List<condition>>(Resources.Load<TextAsset>(jsonPath ).ToString());
    }

    public void ReadAdvertisementsJsonFile()
    {
        string jsonPath = "Json/" + "advertisement";
        m_Advertisements = new advertisements();
        m_Advertisements.info = JsonMapper.ToObject<List<advertisement>>(Resources.Load<TextAsset>(jsonPath).ToString());
    }
}
