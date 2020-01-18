using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour {
    public List<InteriorItem> objects = new List<InteriorItem>();

    public InteriorItem CreateInteriorItem(InteriorItem.ItemType itemType, Vector3 position) {
        InteriorItem interiorItem = GetObjectByType(itemType);
        GameObject newObject = Instantiate(interiorItem.gameObject, position, Quaternion.identity);
        return newObject.GetComponent<InteriorItem>();
    }

    private InteriorItem GetObjectByType(InteriorItem.ItemType type) {
        return objects.Find(o => o.type == type);
    }
    
}
