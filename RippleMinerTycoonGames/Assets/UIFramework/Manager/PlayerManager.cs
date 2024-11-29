using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum MultipleType 
{
    Multiple_1=1,
    Multiple_2= 10,
    Multiple_3 = 100,
    All=0,
    NextEqualOrder=-1,
}
public class PlayerManager : Singleton<PlayerManager>
{
    public ComputeStringFloat GoldCount = "311111111";
    public ComputeStringFloat DiamondCount = 0;
    public ComputeStringFloat CurrencyCount = 0;
    public int MultipleIndex =1;
    public delegate void EventFinshCurrency();
    public EventFinshCurrency FinshCurrency;
    public ComputeStringFloat GetCurrencyCount(int type) 
    {
        switch (type) 
        {
            case 1:
                return GoldCount;
            case 2:
                return DiamondCount;
            case 3:
                return CurrencyCount;
        }
        return 0;
    }
    public void SetCurrencyCount(int type, ComputeStringFloat currency)
    {
        switch (type)
        {
            case 1:
                ChangeGold(currency);break;
            case 2:
                ChangeDiamond(currency); break;
            case 3:
                ChangeCurrency(currency); break;
        }
        FinshCurrency?.Invoke();
    }
    public void RemoveGold(ComputeStringFloat gold)
    {
        GoldCount=GoldCount -gold;
        FinshCurrency?.Invoke();
    }
    public void RemoveCurrency(ComputeStringFloat currency)
    {
        CurrencyCount= CurrencyCount -currency;
        FinshCurrency?.Invoke();
    }
    public void RemoveDiamond(ComputeStringFloat diamond)
    {
        DiamondCount= DiamondCount - diamond;
        FinshCurrency?.Invoke();
    }
    public void ChangeGold(ComputeStringFloat gold)
    {
        GoldCount = GoldCount +gold;
        FinshCurrency?.Invoke();
    }
    public void ChangeCurrency(ComputeStringFloat currency)
    {
        CurrencyCount = CurrencyCount + currency;
        FinshCurrency?.Invoke();
    }
    public void ChangeDiamond(ComputeStringFloat diamond)
    {
        DiamondCount = DiamondCount + diamond;
        FinshCurrency?.Invoke();
    }
    public void ChangeMultipleType() 
    {
        MultipleIndex++;
        if (MultipleIndex>5) 
        {
            MultipleIndex = 1;
        }
    }
    public string GetLvUpText()
    {
        switch (PlayerManager.Instance.MultipleIndex)
        {
            case 1: return "X" + (int)MultipleType.Multiple_1;
            case 2: return "X" + (int)MultipleType.Multiple_2;
            case 3: return "X" + (int)MultipleType.Multiple_3; 
            case 4: return "满级成长";
            case 5: return "升级到下一等阶"; 
        }
        return "";
    }
    public void SellAllMines(bool IsStart=false) 
    {
        long sellConstant= DispositionManager.Instance.Constants.GetInfoToId(3).parameter[0];
        ComputeStringFloat Sellcount = 0;
        foreach (var v in MineManager.Instance.GetAllMineDatas()) 
        {
            if (v.IsLock) 
            {
                Sellcount += v.GetProduce() / v.GetCD();
            }
        }
        if (Sellcount> sellConstant*0.01f  && !IsStart)
        {
            GoldCount = 0;
            ChangeDiamond(Sellcount/ sellConstant);
            MineManager.Instance.InitMines();
            DevelopManager.Instance.InitDevelopToGold();
            CustodianManager.Instance.InitCustodians();
        }
        else if (Sellcount > sellConstant * 0.01f && IsStart)
        {
            GoldCount = 0;
            ChangeDiamond(Sellcount);
        }
    }
}
