using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class MineData
{
    public long Level=0;
    public long Id;
    public bool IsLock;
    private mine m_mine;

    public mine Mine { get => m_mine;  }

    public void SetMine(mine mineData) 
    {
        m_mine = mineData;
    }
    public int GetEqualOrderIndex() 
    {
        int[] levelUps = Mine.levelup;
        int index = 0;
        long maxNumber = 0;
        while (maxNumber < Level + 1)
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
            return index-1;
        }
        return index;
    }
    //public float GetEffectuate() 
    //{
    //    float effectuate= m_mine.effectuate;
    //     int equalOrderIndex = GetEqualOrderIndex();
    //    for (var) 
    //    {
    //    }
    //}
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
    public string GetExpend(int lvCount) 
    {
       int[] coefficients= m_mine.expend;
        long level = Level+1;
        double expends = 0;
        for (int i=0;i< lvCount;i++) 
        {
            expends+= (coefficients[0] / 1000.000f) * Math.Pow(level - 1, (coefficients[2] / 1000.000f + (coefficients[3] / 1000.000f * (level - 1)))) + coefficients[1] / 1000.000f;
            level += 1;
        }
        string expend = expends.ToString("#0.000");
        return expend;
    }
    //public float GetEffectuate() 
    //{
    //    m_mine.effectuate
    //}
}
