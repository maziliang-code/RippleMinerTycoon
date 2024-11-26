using System.Collections.Generic;	
public class constants
{
	public List<constant> info;
	public constant GetInfoToId(int id)
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
public class constant
{
	public long id;
	///备注 
	public string notes;
	///参数 
	public long[] parameter;
}
