using System.Collections.Generic;	
public class languages
{
	public List<language> info;
	public language GetInfoToId(int id)
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
public class language
{
	public long id;
	///备注 
	public string notes;
	///中文 
	public string language1;
	///英语 
	public string language2;
	///德语 
	public string language3;
	///法语 
	public string language4;
	///俄语 
	public string language5;
	///日语 
	public string language6;
	///韩语 
	public string language7;
}
