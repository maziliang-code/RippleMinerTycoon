using System.Collections.Generic;	
public class props
{
	public List<prop> info;
}

[System.Serializable]
public class prop
{
	public long Id;
	///备注 
	public string notes;
	///名字 
	public int name;
	///小图标 
	public string icon;
	///大图标 
	public string resource;
	///类型 
	public int type;
}
