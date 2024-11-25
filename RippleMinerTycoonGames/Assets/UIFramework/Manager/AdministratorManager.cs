using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AdministratorManager : Singleton<AdministratorManager>
{
    Dictionary<long, AdministratorData> Administrators = new Dictionary<long, AdministratorData>();
    public void Init() 
    {
        foreach (var v in DispositionManager.Instance.Advertisements.info) 
        {
            AdministratorData administrator = new AdministratorData();
            administrator.id = v.id;
            Administrators.Add(v.id, administrator); 
        }
    }
    public List<AdministratorData> GetAllAdministratorDatas() 
    {
        return Administrators.Values.ToList();
    }
    public void SetLock(long id) 
    {
        Administrators.TryGetValue(id,out AdministratorData administrator);
        administrator.IsLock = true;
    }
}
