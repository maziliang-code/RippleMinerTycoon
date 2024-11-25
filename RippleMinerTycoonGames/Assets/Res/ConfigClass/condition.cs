using System.Collections.Generic;	
public class conditions
{
	public List<condition> info;
	public condition GetInfoToId(int id)
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
public class condition
{
	public long id;
	///备注 
	public string notes;
	///类型 
	public int tpe;
	///参数 
	public int parameter;
	///对象 
	public int obj;
}
