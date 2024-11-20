using System.Collections.Generic;	
public class conditions
{
	public List<condition> info;
}

[System.Serializable]
public class condition
{
	public long Id;
	///备注 
	public string notes;
	///类型 
	public int tpe;
	///参数 
	public int parameter;
	///对象 
	public int object;
}
