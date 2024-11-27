using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevelopManager :Singleton<DevelopManager>
{
    Dictionary<long, DevelopData> Develops = new Dictionary<long, DevelopData>();
    public delegate void EventFinshDevelopItem();
    public EventFinshDevelopItem FinshDevelopItem;
    public void Init() 
    {
        foreach (var v in DispositionManager.Instance.Develops.info)
        {
            DevelopData developData = new DevelopData();
            developData.id = v.id;
            developData.IsLock = false;
            developData.develop = v;
            Develops.Add(developData.id, developData);
        }
    }
    List<DevelopData> DevelopDatas = new List<DevelopData>();
    public void SetIsUnlock(long id) 
    {
        if (Develops.TryGetValue(id,out DevelopData developData)) 
        {
            developData.IsLock = true;
        }
        FinshDevelopItem?.Invoke();
    }
    public List<DevelopData> GetDevelopToType(int type) 
    {
        DevelopDatas.Clear();
        foreach (var v in Develops.Values) 
        {
            if (v.IsLock==false&&v.develop.expend==type) 
            {
                DevelopDatas.Add(v);
            }
        }
        return DevelopDatas;
    }
    public long GetMinesAddLevel()
    {
        long level = 0;
        foreach (var v in Develops.Values)
        {
            if (v.IsLock)
            {
                if (v.develop.effect[0] == 3)
                {
                    level += v.develop.effect[1];
                }
            }
        }
        return level;
    }
    Dictionary<long, float> mineParDic = new Dictionary<long, float>();
    public float GetMinesAddParToId(long id) 
    {
        mineParDic.Clear();
        foreach (var v in Develops.Values) 
        {
            if (v.IsLock) 
            {
                if (v.develop.effect[0]==1) 
                {
                    if (v.develop.mines[0] == -1)
                    {
                        foreach (var j in DispositionManager.Instance.Mines.info)
                        {
                            if (mineParDic.ContainsKey(j.id))
                            {
                                mineParDic[j.id] += v.develop.effect[1];
                            }
                            else
                            {
                                mineParDic.Add(j.id, v.develop.effect[1]);
                            }
                        }
                    }
                    else
                    {
                        foreach (var j in v.develop.mines)
                        {
                            if (mineParDic.ContainsKey(j))
                            {
                                mineParDic[j] += v.develop.effect[1];
                            }
                            else
                            {
                                mineParDic.Add(j, v.develop.effect[1]);
                            }
                        }
                    }
                }
            }
        }
        if (mineParDic.ContainsKey(id))
            return mineParDic[id];
        else
        return 0;
    }
}
