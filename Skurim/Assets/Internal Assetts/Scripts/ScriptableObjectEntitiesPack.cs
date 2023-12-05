using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New SEntity pack", menuName = "SEntity pack")]
public class ScriptableObjectEntitiesPack : MonoBehaviour
{
    public Faction faction;
    public List<ScriptableEntity> entities;

}
