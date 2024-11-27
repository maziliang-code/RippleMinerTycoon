using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
namespace UI.Develop
{
    public class DevelopItem : BasePanel
    {
        Item_DevelopItem m_Item =new Item_DevelopItem();
        DevelopData m_DevelopData = new DevelopData();
        public override void OnEnter()
        {
            base.OnEnter();
            m_Item.Reset(this);
            m_Item.BuyBtn.onClick.AddListener(OnBuyDevelop);
        }

        private void OnBuyDevelop()
        {
            if (m_DevelopData.develop.expendquantity<=PlayerManager.Instance.GetCurrencyCount(m_DevelopData.develop.expend)) 
            {
                PlayerManager.Instance.SetCurrencyCount(m_DevelopData.develop.expend, -m_DevelopData.develop.expendquantity);
                DevelopManager.Instance.SetIsUnlock(m_DevelopData.id);
            }
        }

        public void Init(DevelopData develop) 
        {
            m_DevelopData = develop;
            m_Item.DevelName.text = DispositionManager.Instance.Languages.GetInfoToId(m_DevelopData.develop.name).language1;
            m_Item.CurrencyCount.text = m_DevelopData.develop.expendquantity.ToString();
        }
        private void Update()
        {
            
        }
        public override void OnExit()
        {
            base.OnExit();
            m_Item.BuyBtn.onClick.RemoveListener(OnBuyDevelop);
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
