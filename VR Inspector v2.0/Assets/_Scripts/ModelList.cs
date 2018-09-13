using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelList : MonoBehaviour {

    [SerializeField]
    private GameObject modelEntryPrefab;

    public void Add(GameObject model) {
        GameObject modelEntryObj = Instantiate(modelEntryPrefab, transform);
        ModelListEntry modelListEntry = modelEntryObj.GetComponent<ModelListEntry>();
        modelListEntry.UpdateValues(model);
    }

}
