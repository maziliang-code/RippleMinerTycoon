using System.Collections.Generic;	
public class advertisements
{
	public List<advertisement> info;
}

[System.Serializable]
public class advertisement
{
	public long Id;
	///备注 
	public string notes;
	///名字 
	public int name;
	///描述 
	public int desc;
	///图标 
	public string icon;
	///资源 
	public string resource;
	///类型 
	public int type;
	///参数 
	public string parameter;
	///冷却时间 
	public int cd;
	///每日次数 
	public int number;
	///条件表id 
	public int[] condition;
	///条件关系（0是与，1是或，或关系优先级以此降低） 
	public int relationship;
}
