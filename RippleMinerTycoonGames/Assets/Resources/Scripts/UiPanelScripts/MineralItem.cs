using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
namespace UI.Main
{
    public class MineralItem : BasePanel
    {
        Item_MineralItem m_Item =new Item_MineralItem();
        MineData m_MineData;
        bool IsAddItem=false;
        public float StartTimestamp = 0;
        public override void OnEnter()
        {
            base.OnEnter();
            m_Item.Reset(this);
            m_Item.Unlock.onClick.AddListener(OnLock);
            m_Item.Item.onClick.AddListener(OnItem);
        }

        private void OnItem()
        {
            IsAddItem = true;
        }

        private void OnLock()
        {
            if (PlayerManager.Instance.GoldCount>= m_MineData.Mine.unlock) 
            {
                PlayerManager.Instance.ChangeGold(-m_MineData.Mine.unlock);
                MineManager.Instance.SetLock(m_MineData.Id);
                Init(MineManager.Instance.GetMineData(m_MineData.Id));
            }
        }

        public void Init(MineData mineData)
        {
            m_MineData = mineData;
            m_Item.UnlockCount.text = m_MineData.Mine.unlock.ToString();
            m_Item.Unlock.gameObject.SetActive(!mineData.IsLock);
            m_Item.LvUpBtn.gameObject.SetActive(mineData.IsLock);
            m_Item.FillBg.gameObject.SetActive(mineData.IsLock);
            m_Item.FillIcon.fillAmount = 0;
            m_Item.LvText.text = m_MineData.Level+"/"+m_MineData.GetEqualOrder();
            m_Item.LvUpText.text = PlayerManager.Instance.GetLvUpText();
            switch (PlayerManager.Instance.MultipleIndex)
            {
                case 1: m_Item.MultipleText.text = mineData.GetExpend(1).ToString(); break;
                case 2: m_Item.MultipleText.text = mineData.GetExpend(10).ToString(); break;
                case 3: m_Item.MultipleText.text = mineData.GetExpend(100).ToString(); break;
                case 4: m_Item.MultipleText.text = "MAX"; break;
                case 5:m_Item.MultipleText.text = "NEXT"; break;
            }
           
        }
        private void Update()
        {
            if (IsAddItem) 
            {

            } 
        }
        public override void OnExit()
        {
            base.OnExit();
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
            m_Item.Unlock.onClick.RemoveListener(OnLock);
            m_Item.Item.onClick.RemoveListener(OnItem);
        }
    }
}
