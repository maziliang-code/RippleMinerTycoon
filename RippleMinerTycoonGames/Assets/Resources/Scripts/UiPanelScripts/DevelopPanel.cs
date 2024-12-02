using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UI.Develop
{
    public class DevelopPanel : BasePanel
    {
        UI_DevelopPanel m_Panel=new UI_DevelopPanel();
        List<Image> m_Tables = new List<Image>();
        List<DevelopItem> m_DevelopItems = new List<DevelopItem>();
        int type = 1;
        public override void OnEnter()
        {
            base.OnEnter();
            m_Panel.Reset(this);
            m_Panel.CloseBtn.onClick.AddListener(Close);
            m_Tables.Clear();
            m_Tables.Add(m_Panel.SelectMoney);
            m_Tables.Add(m_Panel.SelectInvestors);
            m_Tables.Add(m_Panel.SelectMegatoken);
            m_Panel.Money.onClick.AddListener(OnSelectMoney);
            m_Panel.Investors.onClick.AddListener(OnSelectInvestors);
            m_Panel.Megatoken.onClick.AddListener(OnSelectMegatoken);
            DevelopManager.Instance.FinshDevelopItem += FinshItems;
            Init();
        }

        private void OnSelectMoney()
        {
            foreach (var v in m_Tables) 
            {
                v.gameObject.SetActive(false);
            }
            m_Panel.SelectMoney.gameObject.SetActive(true);
            type = 1;
            FinshItems();
        }

        private void OnSelectMegatoken()
        {
            foreach (var v in m_Tables)
            {
                v.gameObject.SetActive(false);
            }
            m_Panel.SelectMegatoken.gameObject.SetActive(true);
            type = 5;
            FinshItems();
        }

        private void OnSelectInvestors()
        {
            foreach (var v in m_Tables)
            {
                v.gameObject.SetActive(false);
            }
            m_Panel.SelectInvestors.gameObject.SetActive(true);
            type = 4;
            FinshItems();
        }
        private void Init()
        {
            foreach (var v in m_Tables)
            {
                v.gameObject.SetActive(false);
            }
            m_Panel.SelectMoney.gameObject.SetActive(true);
            type = 1;
            FinshItems();
        }
        public void FinshItems()
        {
            m_DevelopItems.Clear();
            for (int i = 0; i < m_Panel.Items.content.transform.childCount; i++)
            {
                Transform transform = m_Panel.Items.content.transform.GetChild(i);
                Destroy(transform.gameObject);
            }
            foreach (var v in DevelopManager.Instance.GetDevelopToType(type))
            {
                GameObject item = UIManager.Instance.GetItem(UIPanelType.Item_DevelopItem).gameObject;
                item.transform.parent = m_Panel.Items.content.transform;
                item.transform.localScale = Vector3.one;
                item.transform.localPosition = Vector3.zero;
                item.SetActive(true);
                DevelopItem develop = item.GetComponent<DevelopItem>();
                develop.Init(v);
                m_DevelopItems.Add(develop);
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            m_Panel.CloseBtn.onClick.RemoveListener(Close);
            m_Panel.Money.onClick.RemoveListener(OnSelectMoney);
            m_Panel.Investors.onClick.RemoveListener(OnSelectInvestors);
            m_Panel.Megatoken.onClick.RemoveListener(OnSelectMegatoken);
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
