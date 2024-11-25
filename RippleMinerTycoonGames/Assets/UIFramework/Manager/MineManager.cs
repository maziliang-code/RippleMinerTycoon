using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MineManager :Singleton<MineManager>
{
    Dictionary<long, MineData> Mines = new Dictionary<long, MineData>();
    public void Init()
    {
        foreach (var v in DispositionManager.Instance.Mines.info)
        {
            MineData mineData = new MineData();
            mineData.Id = v.id;
            mineData.SetMine(v);
            if (v.unlock==0) 
            {
                mineData.IsLock = true;
            }
            else 
            {
                mineData.IsLock = false;
            }
            Mines.Add(v.id, mineData);
        }
    }
    public MineData GetMineData(long id) 
    {
        return Mines[id];
    }
    public List<MineData> GetAllMineDatas()
    {
        return Mines.Values.ToList();
    }
    public void SetLock(long id)
    {
        Mines.TryGetValue(id, out MineData  mineData);
        mineData.IsLock = true;
        PlayerManager.Instance.FinshCurrency?.Invoke();
    }
}
