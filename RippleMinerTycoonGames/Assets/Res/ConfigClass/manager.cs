using System.Collections.Generic;	
public class managers
{
	public List<manager> info;
}

[System.Serializable]
public class manager
{
	public long Id;
	///备注 
	public string notes;
	///名字 
	public int name;
	///描述 
	public int desc;
	///资源 
	public string resource;
	///效果 
	public string effect;
	///生效矿产组（-1为全部） 
	public string mines;
	///消耗类型（道具id） 
	public string expend;
	///消耗数量 
	public string expendquantity;
}
