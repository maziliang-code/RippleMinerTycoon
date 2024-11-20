using System.Collections.Generic;	
public class constants
{
	public List<constant> info;
}

[System.Serializable]
public class constant
{
	public long Id;
	///备注 
	public string notes;
	///参数 
	public string parameter;
}
