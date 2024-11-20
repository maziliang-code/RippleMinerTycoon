using System.Collections.Generic;	
public class mines
{
	public List<mine> info;
}

[System.Serializable]
public class mine
{
	public long Id;
	///备注 
	public string notes;
	///名字 
	public int name;
	///资源 
	public string resource;
	///解锁消耗 
	public string unlock;
	///产出 
	public string produce;
	///消耗（/1000） 
	public string expend;
	///生产时间（/1000） 
	public int cd;
	///升阶变化数 
	public int effectuate;
}
