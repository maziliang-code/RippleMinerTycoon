using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
namespace UI.Main
{
    public class MineralItem : BasePanel
    {
        Item_MineralItem m_Item =new Item_MineralItem();
        MineData m_MineData;
        public override void OnEnter()
        {
            base.OnEnter();
            m_Item.Reset(this);
            m_Item.Unlock.onClick.AddListener(OnLock);
            m_Item.Item.onClick.AddListener(OnItem);
            m_Item.LvUpBtn.onClick.AddListener(OnLvUp);
        }


        private void OnLvUp()
        {
            switch (PlayerManager.Instance.MultipleIndex)
            {
                case 1:
                    if (PlayerManager.Instance.GoldCount >= m_MineData.GetExpend(1))
                    {
                        MineManager.Instance.SetLevel(m_MineData.Id,1);
                    }; break;
                case 2:
                    if (PlayerManager.Instance.GoldCount >= m_MineData.GetExpend(10))
                    {
                        MineManager.Instance.SetLevel(m_MineData.Id, 10);
                    }
                    ; break;
                case 3:
                    if (PlayerManager.Instance.GoldCount >= m_MineData.GetExpend(100))
                    {
                        MineManager.Instance.SetLevel(m_MineData.Id, 100);
                    }; break;
                case 4:
                    if ( m_MineData.GetExpend(m_MineData.GetLevelToExpend())>0)
                    {
                        MineManager.Instance.SetLevel(m_MineData.Id, m_MineData.GetLevelToExpend());
                    }
                    break;
                case 5:
                    if (PlayerManager.Instance.GoldCount >= m_MineData.GetExpend(m_MineData.GetEqualOrder() - m_MineData.Level))
                    {
                        MineManager.Instance.SetLevel(m_MineData.Id, m_MineData.GetEqualOrder() - m_MineData.Level);
                    }
                    break;
            }
        }

        private void OnItem()
        {
            if (m_MineData.IsAgency)
            {
                return;
            }
            if (!m_MineData.IsAddItem) 
            {
                m_MineData.StartTimestamp = 0;
            }
            m_MineData.IsAddItem = true;
        }
        private void OnLock()
        {
            if (PlayerManager.Instance.GoldCount>= (ComputeStringFloat)m_MineData.Mine.unlock) 
            {
                PlayerManager.Instance.RemoveGold(m_MineData.Mine.unlock);
                MineManager.Instance.SetLock(m_MineData.Id);
                Init(MineManager.Instance.GetMineData(m_MineData.Id));
            }
        }

        public void Init(MineData mineData)
        {
            m_Item.Reset(this);
            m_MineData = mineData;
         
            if ((m_MineData.GetCD() / 1000.00f) < 1)
            {
                m_Item.CdText.gameObject.SetActive(false);
                m_Item.FillText.text = m_MineData.GetProduce().ToFigureString(true) + "/sec";
            }
            else
            {
                m_Item.CdText.text = (m_MineData.GetCD() / 1000.00f).ToString()+"s";
                m_Item.CdText.gameObject.SetActive(true);
                m_Item.FillText.text = m_MineData.GetProduce().ToFigureString(true);
            }
           
            Sprite sprite = Resources.Load<Sprite>("Sprite/MineItem/" + m_MineData.Mine.resource);
            m_Item.ItemIcon.sprite = sprite;
            m_Item.UnlockText.text = DispositionManager.Instance.Languages.GetInfoToId(m_MineData.Mine.name).language1; 
            m_Item.UnlockCount.text = ((ComputeStringFloat)(m_MineData.Mine.unlock)).ToFigureString(true);
            m_Item.Unlock.gameObject.SetActive(!mineData.IsLock);
            if (!mineData.IsLock)
            {
                if (PlayerManager.Instance.GoldCount < (ComputeStringFloat)m_MineData.Mine.unlock)
                {
                    Color color = m_Item.Unlock.image.color;
                    color.a = 0.5f;
                    m_Item.Unlock.image.color = color;
                }
                else
                {
                    Color color = m_Item.Unlock.image.color;
                    color.a = 0f;
                    m_Item.Unlock.image.color = color;
                }
            }
            m_Item.LvUpBtn.gameObject.SetActive(mineData.IsLock);
            m_Item.FillBg.gameObject.SetActive(mineData.IsLock);
            if (!mineData.IsAddItem)
            {
                m_Item.FillIcon.fillAmount = 0;
            }
            else
            {
                float fillAmount = (float)(m_MineData.StartTimestamp / (m_MineData.GetCD() / 1000.00f));
                m_Item.FillIcon.fillAmount = fillAmount;
            }
            m_Item.LvText.text = m_MineData.Level+"/"+m_MineData.GetEqualOrder();
            m_Item.LvUpText.text = PlayerManager.Instance.GetLvUpText();
            switch (PlayerManager.Instance.MultipleIndex)
            {
                case 1: m_Item.LvUpUnlock.gameObject.SetActive(false); m_Item.MultipleText.text = mineData.GetExpend(1).ToFigureString(); break;
                case 2: m_Item.LvUpUnlock.gameObject.SetActive(false); m_Item.MultipleText.text = mineData.GetExpend(10).ToFigureString(); break;
                case 3: m_Item.LvUpUnlock.gameObject.SetActive(false); m_Item.MultipleText.text = mineData.GetExpend(100).ToFigureString(); break;
                case 4:
                    m_Item.MultipleText.text = mineData.GetExpend(m_MineData.GetLevelToExpend()).ToFigureString();
                    if (m_MineData.GetLevelToExpend() != 0)
                    {
                        m_Item.LvUpUnlock.gameObject.SetActive(false);
                    }
                    else
                    {
                        m_Item.LvUpUnlock.gameObject.SetActive(true);
                    }
                   break;
                case 5: m_Item.LvUpUnlock.gameObject.SetActive(false); m_Item.MultipleText.text = m_MineData.GetExpend(m_MineData.GetEqualOrder() - m_MineData.Level).ToFigureString() ; break;
            }
        }
        private void Update()
        {
            if (!m_MineData.IsLock)
            {
                return;
            }
            if (m_MineData.IsAgency)
            {
                m_MineData.StartTimestamp += Time.deltaTime;
                float fillAmount = (float)(m_MineData.StartTimestamp / (m_MineData.GetCD() / 1000.00f));
                m_Item.FillIcon.fillAmount = fillAmount;
                if (fillAmount >= 1)
                {
                    PlayerManager.Instance.ChangeGold(m_MineData.GetProduce());
                    m_Item.FillIcon.fillAmount = 0;
                    m_MineData.StartTimestamp = 0;
                }
                return;
            }
            if (m_MineData.IsAddItem)
            {
                m_MineData.StartTimestamp += Time.deltaTime;
                float fillAmount=(float)(m_MineData.StartTimestamp / (m_MineData.GetCD()/1000.00f));
                m_Item.FillIcon.fillAmount = fillAmount;
                if(fillAmount>=1)
                {
                    m_Item.FillIcon.fillAmount = 0;
                    m_MineData.IsAddItem = false;
                    PlayerManager.Instance.ChangeGold(m_MineData.GetProduce());
                }
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
            m_Item.LvUpBtn.onClick.RemoveListener(OnLvUp);
        }
    }
}
