using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/PackageTable", fileName = "PackageTable")]
public class PackageTable : ScriptableObject
{
    public List<PackageTableItem> DataList=new List<PackageTableItem>();

}

[System.Serializable]
public class PackageTableItem
{
    public int id;
    public int categrory;
    public int type;
    public string name;
    public string description;
    public string imagePath;
}