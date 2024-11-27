using System;
using System.Collections.Generic;
using UI.Custodian;
using UI.Develop;
using UI.SellPanel;
using UnityEngine;
using UnityEngine.UIElements;
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
            m_Panel.DevelopPanel.onClick.AddListener(OnDevelopPanel);
            m_Panel.CustodianPanel.onClick.AddListener(OnCustodianPanel);
            m_Panel.SellPanel.onClick.AddListener(OnSellPanel);
            PlayerManager.Instance.FinshCurrency += FinshCurrency;
            MineManager.Instance.FinshMine += FinshMine;
            Init();
        }

        private void OnSellPanel()
        {
            UIManager.Instance.PushPanel(UIPanelType.UI_SellPanel);
        }

        private void OnCustodianPanel()
        {
            UIManager.Instance.PushPanel(UIPanelType.UI_CustodianPanel);
        }

        private void OnDevelopPanel()
        {
            UIManager.Instance.PushPanel(UIPanelType.UI_DevelopPanel);
        }

        private void FinshMine(MineData mineData)
        {
            FinshItems();
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
            m_Panel.GoldCount.text = string.Format("{0:0.###}", PlayerManager.Instance.GoldCount);
            m_Panel.DiamondCount.text = string.Format("{0:0.###}", PlayerManager.Instance.DiamondCount);
            m_Panel.CurrencyCount.text = string.Format("{0:0.###}", PlayerManager.Instance.CurrencyCount);
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
            m_Panel.CustodianPanel.onClick.RemoveListener(OnCustodianPanel);
            m_Panel.MultipleBtn.onClick.RemoveListener(OnMultiple);
            m_Panel.DevelopPanel.onClick.RemoveListener(OnDevelopPanel);
            m_Panel.SellPanel.onClick.RemoveListener(OnSellPanel);
            PlayerManager.Instance.FinshCurrency -= FinshCurrency;
            MineManager.Instance.FinshMine -= FinshMine;
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
