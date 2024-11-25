using System;
using System.Collections;
using System.Collections.Generic;
using NPOI.POIFS.Properties;
using UnityEngine;
using UnityEngine.UIElements;
using static PlayerManager;
using static UnityEditor.Progress;
namespace UI.Main
{
    public class MainPanel : BasePanel
    {
        UI_MainPanel m_Panel=new UI_MainPanel();
        List<MineralItem> minerals = new List<MineralItem>();
        public override void OnEnter()
        {
            base.OnEnter();
            m_Panel.Reset(this);
            m_Panel.MultipleBtn.onClick.AddListener(OnMultiple);
            PlayerManager.Instance.FinshCurrency += FinshCurrency;
            Init();

        }

        private void OnMultiple()
        {
            PlayerManager.Instance.ChangeMultipleType();
            FinshItems();
        }

        public void Init()
        {
            FinshItems();
            FinshCurrency();
        }
        public void FinshCurrency() 
        {
            m_Panel.GoldCount.text = PlayerManager.Instance.GoldCount.ToString();
            m_Panel.DiamondCount.text = PlayerManager.Instance.DiamondCount.ToString();
            m_Panel.CurrencyCount.text = PlayerManager.Instance.CurrencyCount.ToString();
        }
        public void FinshItems() 
        {
            minerals.Clear();
            for (int i = 0; i < m_Panel.Items.content.transform.childCount; i++)
            {
                Transform  transform = m_Panel.Items.content.transform.GetChild(i);
                Destroy(transform.gameObject);
            }
            foreach (var v in MineManager.Instance.GetAllMineDatas())
            {
                GameObject item = UIManager.Instance.GetItem(UIPanelType.Item_MineralItem).gameObject;
                item.transform.parent = m_Panel.Items.content.transform;
                item.transform.localScale = Vector3.one;
                item.transform.localPosition = Vector3.zero;
                item.SetActive(true);
                MineralItem mineral= item.GetComponent<MineralItem>();
                mineral.Init(v);
                minerals.Add(mineral);
            }
            m_Panel.MultipleCount.text = PlayerManager.Instance.GetLvUpText();
        }
       
        public override void OnExit()
        {
            base.OnExit();
            m_Panel.MultipleBtn.onClick.RemoveListener(OnMultiple);
            PlayerManager.Instance.FinshCurrency -= FinshCurrency;
        }

        public override void OnPause()
        {
            base.OnPause();
        }

        public override void OnResume()
        {
            base.OnResume();
        }
    }
}
