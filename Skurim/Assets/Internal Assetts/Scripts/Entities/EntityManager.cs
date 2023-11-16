using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public static EntityManager instance;
    public List<ScriptableEntity> entities;

    private void Awake()
    {
        instance = this;
        entities = Resources.LoadAll<ScriptableEntity>("Entities").ToList();
    }
    // Start is called before the first frame update
    public ScriptableEntity GetEntity(string Name)
    {
        for(int i = 0; i < entities.Count; i++) 
        {
            if (entities[i].Name == Name) 
            { 
                return entities[i];
            }
        }
        return null;
    }
}
