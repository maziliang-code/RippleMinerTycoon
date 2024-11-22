using System.Collections.Generic;	
public class mines
{
	public List<mine> info;
	public mine GetInfoToId(int id)
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
public class mine
{
	public long id;
	///备注 
	public string notes;
	///名字 
	public int name;
	///资源 
	public string resource;
	///解锁消耗 
	public int unlock;
	///产出（公式：y=ax+b;参数：a，b；x为等级） 
	public int[] produce;
	///消耗（/1000；公式：y=ax^（c+d（x-1）+b）+b；参数：a，b，c，d；x为等级） 
	public int[] expend;
	///生产时间（/1000） 
	public int cd;
	///升阶变化数(升阶后读取数值，并将数值减一，数值小于零则产出翻倍) 
	public int effectuate;
	///升阶（公式为累加，最后一位循环） 
	public int[] levelup;
}
