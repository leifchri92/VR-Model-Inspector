using UnityEngine;
using UnityEngine.UI;

public class ModelListEntry : MonoBehaviour {
    
    public GameObject model;
    public string title;

    [SerializeField]
    private Text titleText;

	private ModelsPanel modelsPanel;

	void Start() {
		modelsPanel = (ModelsPanel)GameObject.FindObjectOfType(typeof(ModelsPanel));
	}

    public void UpdateValues(GameObject model)
    {
        this.model = model;
        this.title = model.name;
        titleText.text = this.title;
    }

	public void DeleteModel() {
		modelsPanel.DoDeleteModel (gameObject);
	}

	public void OnSelect(Button button) {
		if (!gameObject.GetComponent<Light> ())
			return;
		
		transform.parent.GetComponent<ButtonColorToggle> ().SelectButton (button);

		modelsPanel.selectedModel = model;
		modelsPanel.ShowModelControlPanel ();
	}
}
