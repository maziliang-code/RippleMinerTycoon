using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MineManager :Singleton<MineManager>
{
    Dictionary<long, MineData> Mines = new Dictionary<long, MineData>();
    public delegate void EventFinshMine();
    public EventFinshMine FinshMine;
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
    public void SetMinesAgency(List<long> ids) 
    {
        foreach (var v in Mines.Values) 
        {
            v.IsAgency = false;
        }
        foreach (var v in ids) 
        {
            if (Mines.ContainsKey(v)) 
            {
                Mines[v].IsAgency=true;
            }
        }
        PlayerManager.Instance.FinshCurrency?.Invoke();
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
    public void SetLevel(long id, long level)
    {
        Mines.TryGetValue(id, out MineData mineData);
        PlayerManager.Instance.RemoveGold(mineData.GetExpend(level));
        mineData.SetAddLevel(level);
        FinshMine?.Invoke();
    }
    public void InitMines() 
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
            if (Mines.ContainsKey(v.id)) 
            {
                Mines[v.id] = mineData;
            }
        }
        FinshMine?.Invoke();
    }

}
