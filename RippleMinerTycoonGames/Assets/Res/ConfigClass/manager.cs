using System.Collections.Generic;	
public class managers
{
	public List<manager> info;
	public manager GetInfoToId(int id)
	{
		foreach (var v in info)
		{
			if (v.id==id) 
			{
				return v; 
			}
		}
		return null; 
	}
}

[System.Serializable]
public class manager
{
	public long id;
	///备注 
	public string notes;
	///名字 
	public int name;
	///描述 
	public int desc;
	///资源 
	public string resource;
	///效果 
	public int[] effect;
	///生效矿产组（-1为全部） 
	public int[] mines;
	///消耗类型（道具id） 
	public int expend;
	///消耗数量 
	public string expendquantity;
}
