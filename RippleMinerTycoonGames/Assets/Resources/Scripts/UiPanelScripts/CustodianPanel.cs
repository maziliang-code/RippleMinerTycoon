using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UI.Custodian
{
    public class CustodianPanel : BasePanel
    {
        UI_CustodianPanel m_Panel =new UI_CustodianPanel();
        List<Image> m_Tables = new List<Image>();
        List<CustodianItem> m_CustodianItem = new List<CustodianItem>();
        int type = 1;
        public override void OnEnter()
        {
            base.OnEnter();
            m_Panel.Reset(this);
            m_Panel.CloseBtn.onClick.AddListener(Close);
            m_Tables.Clear();
            m_Tables.Add(m_Panel.SelectMoney);
            m_Tables.Add(m_Panel.SelectInvestors);
            m_Panel.Money.onClick.AddListener(OnSelectMoney);
            m_Panel.Investors.onClick.AddListener(OnSelectInvestors);
            CustodianManager.Instance.FinshCustodianItem += FinshItems;
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
            m_CustodianItem.Clear();
            for (int i = 0; i < m_Panel.Items.content.transform.childCount; i++)
            {
                Transform transform = m_Panel.Items.content.transform.GetChild(i);
                Destroy(transform.gameObject);
            }
            foreach (var v in CustodianManager.Instance.GetDevelopToType(type))
            {
                GameObject item = UIManager.Instance.GetItem(UIPanelType.Item_CustodianItem).gameObject;
                item.transform.parent = m_Panel.Items.content.transform;
                item.transform.localScale = Vector3.one;
                item.transform.localPosition = Vector3.zero;
                item.SetActive(true);
                CustodianItem custodian = item.GetComponent<CustodianItem>();
                custodian.Init(v);
                m_CustodianItem.Add(custodian);
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            m_Panel.CloseBtn.onClick.RemoveListener(Close);
            m_Panel.Money.onClick.RemoveListener(OnSelectMoney);
            m_Panel.Investors.onClick.RemoveListener(OnSelectInvestors);
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
