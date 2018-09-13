using UnityEngine;
using RuntimeGizmos;

public class ModifyPanel : MonoBehaviour {

    // Modify tools
    [SerializeField]
    private TransformGizmo transformGizmoScript;
    [SerializeField]
    private PropertiesChanger propertiesChangerScript;

    [SerializeField]
    private GameObject modifyPanelExtra;
    [SerializeField]
    private GameObject transformPanel;
    [SerializeField]
    private GameObject materialsPanel;
    [SerializeField]
    private GameObject lightsPanel;

    public void OnClickTransformButton() {
        propertiesChangerScript.enabled = false;

        bool isEnabled = transformGizmoScript.enabled;
        transformGizmoScript.enabled = !isEnabled;
        transformPanel.transform.SetAsLastSibling();
        modifyPanelExtra.SetActive(!isEnabled);
    }

    public void OnClickPropertiesButton() {
        transformGizmoScript.enabled = false;

        propertiesChangerScript.enabled = !propertiesChangerScript.enabled;
    }
}
