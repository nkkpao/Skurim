using UnityEngine;


[CreateAssetMenu]
public class ItemModel : ScriptableObject
{
    public int id;
    public string name;
    [TextArea]
    public string description;
    public Sprite icon;
    public static ItemModel CreateFromJson(string JsonString)
    {
        return JsonUtility.FromJson<ItemModel>(JsonString);
    }

}
