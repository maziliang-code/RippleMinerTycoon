using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UI.Develop;
using UnityEngine;
using UnityEngine.Tilemaps;
namespace UI.Custodian
{
    public class CustodianItem : BasePanel
    {
        Item_CustodianItem m_Item =new Item_CustodianItem();
        CustodianData m_CustodianData = new CustodianData();
        public override void OnEnter()
        {
            base.OnEnter();
            m_Item.Reset(this);
            m_Item.BuyBtn.onClick.AddListener(OnBuyCustodian);
        }

        private void OnBuyCustodian()
        {
            if (m_CustodianData.Custodian.expendquantity<=PlayerManager.Instance.GetCurrencyCount(m_CustodianData.Custodian.expend)) 
            {
                PlayerManager.Instance.SetCurrencyCount(m_CustodianData.Custodian.expend, -m_CustodianData.Custodian.expendquantity);
                CustodianManager.Instance.SetIsUnlock(m_CustodianData.id);
            }
        }

        public void Init(CustodianData custodian) 
        {
            m_CustodianData = custodian;
            m_Item.DevelName.text = DispositionManager.Instance.Languages.GetInfoToId(m_CustodianData.Custodian.name).language1;
            m_Item.CurrencyCount.text = m_CustodianData.Custodian.expendquantity.ToString();
        }
        private void Update()
        {
            
        }
        public override void OnExit()
        {
            base.OnExit();
            m_Item.BuyBtn.onClick.RemoveListener(OnBuyCustodian);
        }

        public override void OnPause()
        {
            base.OnPause();
        }

        public override void OnResume()
        {
            base.OnResume();
        }

        public override void OnClose()
        {
            base.OnClose();
        }
    }
}
