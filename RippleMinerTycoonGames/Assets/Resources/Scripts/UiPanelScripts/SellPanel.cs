using System;
using System.Collections;
using System.Collections.Generic;
using UI.Develop;
using UI.SellPanel;
using UnityEngine;
namespace UI.SellPanel
{
    public class SellPanel : BasePanel
    {
        UI_SellPanel m_Panel = new UI_SellPanel();
        public override void OnEnter()
        {
            base.OnEnter();
            m_Panel.Reset(this);
            m_Panel.CloseBtn.onClick.AddListener(Close);
            m_Panel.BuyBtn.onClick.AddListener(OnBuyBtn);
            m_Panel.ClaimBtn.onClick.AddListener(OnClaimBtn);
        }

        private void OnClaimBtn()
        {
            PlayerManager.Instance.SellAllMines();
        }

        private void OnBuyBtn()
        {
            PlayerManager.Instance.SellAllMines(true);
        }

        public override void OnExit()
        {
            base.OnExit();
            m_Panel.BuyBtn.onClick.RemoveListener(OnBuyBtn);
            m_Panel.ClaimBtn.onClick.RemoveListener(OnClaimBtn);
            m_Panel.CloseBtn.onClick.RemoveListener(Close);
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

