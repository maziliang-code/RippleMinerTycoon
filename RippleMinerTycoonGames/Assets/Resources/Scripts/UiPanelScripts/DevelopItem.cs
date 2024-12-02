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
            if ((ComputeStringFloat)m_DevelopData.develop.expendquantity<=PlayerManager.Instance.GetCurrencyCount(m_DevelopData.develop.expend)) 
            {
                DevelopManager.Instance.SetIsUnlock(m_DevelopData.id);
                PlayerManager.Instance.SetCurrencyCount(m_DevelopData.develop.expend, (ComputeStringFloat)(m_DevelopData.develop.expendquantity));              
            }
        }

        public void Init(DevelopData develop) 
        {
            m_DevelopData = develop;
            Sprite sprite = Resources.Load<Sprite>("Sprite/MineItem/" + m_DevelopData.develop.resource);
            m_Item.DevelImage.sprite = sprite;
            Sprite sprites = Resources.Load<Sprite>("Sprite/Common/" + DispositionManager.Instance.Props.GetInfoToId(m_DevelopData.develop.expend).icon);
            m_Item.CurrencyImage.sprite = sprites;
            m_Item.DevelName.text = DispositionManager.Instance.Languages.GetInfoToId(m_DevelopData.develop.name).language1;
            m_Item.CurrencyCount.text =((ComputeStringFloat) m_DevelopData.develop.expendquantity).ToFigureString(true);
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
