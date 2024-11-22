using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevelopManager :Singleton<DevelopManager>
{
    Dictionary<int, DevelopData> Develops = new Dictionary<int, DevelopData>();
}
