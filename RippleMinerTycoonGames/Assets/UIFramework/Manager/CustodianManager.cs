using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustodianManager : Singleton<CustodianManager>
{
    Dictionary<long, CustodianData> Custodians = new Dictionary<long, CustodianData>();
    public delegate void EventFinshCustodianItem();
    public EventFinshCustodianItem FinshCustodianItem;
    public void Init()
    {
        foreach (var v in DispositionManager.Instance.Managers.info)
        {
            CustodianData custodianData = new CustodianData();
            custodianData.id = v.id;
            custodianData.IsLock = false;
            custodianData.Custodian = v;
            Custodians.Add(custodianData.id, custodianData);
        }
    }
    List<CustodianData> CustodianDatas = new List<CustodianData>();
    public void InitCustodians() 
    {
        foreach (var v in Custodians.Values) 
        {
            if (v.Custodian.expend==1) 
            {
                v.IsLock = false;
            }
        }
        SetAgencys();
        FinshCustodianItem?.Invoke();
    }
    public void SetIsUnlock(long id)
    {
        if (Custodians.TryGetValue(id, out CustodianData custodianData))
        {
            custodianData.IsLock = true;
        }
        SetAgencys();
        FinshCustodianItem?.Invoke();
    }
    public List<CustodianData> GetDevelopToType(int type)
    {
        CustodianDatas.Clear();
        foreach (var v in Custodians.Values)
        {
            if (v.IsLock == false && v.Custodian.expend == type)
            {
                CustodianDatas.Add(v);
            }
        }
        return CustodianDatas;
    }
    List<long> Agencys = new List<long>();
    public void SetAgencys()
    {
        Agencys.Clear();
        foreach (var v in Custodians.Values) 
        {
            if (v.IsLock) 
            {
                if (v.Custodian.mines[0] == -1)
                {
                    foreach (var j in DispositionManager.Instance.Mines.info)
                    {
                        if (!Agencys.Contains(j.id))
                        {
                            Agencys.Add(j.id);
                        }
                    }
                }
                else 
                {
                    foreach (var j in v.Custodian.mines)
                    {
                        Agencys.Add(j);
                    }
                }
            }
        }
        MineManager.Instance.SetMinesAgency(Agencys);
    }
}
