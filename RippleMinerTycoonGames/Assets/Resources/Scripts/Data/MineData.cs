using System;
using UnityEngine;

public class MineData
{
    public long m_Level=0;
    public long Level 
    {
        get 
        {
            return m_Level+DevelopManager.Instance.GetMinesAddLevel();
        }
    }
    public long Id;
    public bool IsLock;
    public float StartTimestamp =0;
    public bool IsAddItem = false;
    private mine m_mine;
    public bool IsAgency =false;
    public mine Mine { get => m_mine;  }

    public void SetAddLevel(long level) 
    {
        m_Level += level;
    }
    public ComputeStringFloat Getlevelpar() 
    {
        int effectuate = m_mine.effectuate;
        int[] levelpar = m_mine.levelpar;
        ComputeStringFloat maxLevelPar = 0;
        int equalOrderIndex = GetEqualOrderIndex();
        for (int i = effectuate; i < equalOrderIndex; i++)
        {
            maxLevelPar += levelpar[0]/1000 + (i - 1) * levelpar[1] / 1000;
        }
        maxLevelPar += DevelopManager.Instance.GetMinesAddParToId(Id);
        if (maxLevelPar==0) 
        {
            maxLevelPar = 1;
        }
        return maxLevelPar;
    }
    public void SetMine(mine mineData) 
    {
        m_mine = mineData;
    }
    public int GetEqualOrderIndex() 
    {
        int[] levelUps = Mine.levelup;
        int index = 0;
        long maxNumber = 0;
        while (maxNumber < Level)
        {
            if (index <levelUps.Length)
            {
                maxNumber += levelUps[index];
                index++;
            }
            else
            {
                maxNumber += levelUps[levelUps.Length - 1];
                index++;
            }
        }
        return index;
    }
    public float GetCD()
    {
        float effectuate = m_mine.effectuate;
        float cd= m_mine.cd;
        int equalOrderIndex = GetEqualOrderIndex();
        for (int i=0;i< equalOrderIndex;i++)
        {
            if (i<= effectuate) 
            {
                cd /= (m_mine.levelpar[0]/1000);
            }
        }
        return cd;
    }
    public ComputeStringFloat GetProduce()
    {
        long[] produce = m_mine.produce;
        return (ComputeStringFloat)(produce[0] * Level + produce[1]) * Getlevelpar();
    }
    public long GetEqualOrder() 
    {
        int[] levelUps=  Mine.levelup;
        int index = 0;
        long maxNumber = 0;
        while (maxNumber<Level+1) 
        {
            if (index < levelUps.Length)
            {
                maxNumber += levelUps[index];
                index++;
            }
            else
            {
                maxNumber += levelUps[levelUps.Length-1];
            }
        }
        return maxNumber;
    }
    public ComputeStringFloat GetExpend(long lvCount) 
    {
       long[] coefficients= m_mine.expend;
        long level = Level+1;
        ComputeStringFloat expends = 0;
        for (int i=0;i< lvCount;i++) 
        {
            expends+=new ComputeStringFloat(((coefficients[0] / 1000.00f) * Math.Pow(level - 1, (coefficients[2] / 1000.00f*Math.Pow(level - 1, coefficients[4] / 1000.00f) + (coefficients[3] / 1000.00f))) + coefficients[1] / 1000.00f).ToString());
           
           level += 1;
        }
      
        return expends;
    }
    public long GetLevelToExpend() 
    {

        long[] coefficients = m_mine.expend;
        long level = Level + 1;
        long addlevel = 0;
        ComputeStringFloat expends = 0;
        while (PlayerManager.Instance.GoldCount>= expends) 
        {
            expends += (ComputeStringFloat)((coefficients[0] / 1000.000f) * Math.Pow(level - 1, (coefficients[2] / 1000.000f * Math.Pow(level - 1, coefficients[4] / 1000.000f) + (coefficients[3] / 1000.000f ))) + coefficients[1] / 1000.000f);
            level += 1;
            addlevel += 1;
        }
        return addlevel - 1;
    }
}
