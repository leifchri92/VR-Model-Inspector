using UnityEngine;
using UnityEngine.UI;

public class ModelListEntry : MonoBehaviour {
    
    public GameObject model;
    public string title;

    [SerializeField]
    private Text titleText;

    public void UpdateValues(GameObject model)
    {
        this.model = model;
        this.title = model.name;
        titleText.text = this.title;
    }
}
