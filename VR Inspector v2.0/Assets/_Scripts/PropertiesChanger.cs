using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertiesChanger : MonoBehaviour
{

    [SerializeField]
    private GameObject selection;

    [SerializeField]
    private List<Material> materials;
    [SerializeField]
    private Material outlineMaterial;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {

            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && hitInfo.transform.tag == "Transformable")
            {
                Transform target = hitInfo.transform;

                if (selection != target.gameObject)
                {
                    print("new selecction");
                }

                selection = target.gameObject;

                Renderer[] renderers = GetRenderers(selection);
                foreach (Renderer renderer in renderers)
                {
                    Material[] materialsBuffer = new Material[renderer.materials.Length + 1];
                    int i = 0;
                    for (; i < renderer.materials.Length; i++)
                    {
                        materialsBuffer[i] = renderer.materials[i];
                    }
                    materialsBuffer[i] = outlineMaterial;
                    renderer.materials = materialsBuffer;
                }
            }
            else if (selection != null)
            {
                RemoveOutline(selection);
                selection = null;
            }

        }
    }

    void AddOutline(GameObject gameObject)
    {

    }

    void RemoveOutline(GameObject gameObject)
    {

    }

    Renderer[] GetRenderers(GameObject gameObject)
    {
        Renderer[] renderers = gameObject.GetComponents<Renderer>();
        Renderer[] parentRenderers = gameObject.GetComponentsInParent<Renderer>();
        Renderer[] childRenderers = gameObject.GetComponentsInChildren<Renderer>();

        Renderer[] renderersBuffer = new Renderer[renderers.Length + parentRenderers.Length + childRenderers.Length];
        int i = 0;
        for (int j = 0; j < renderers.Length; j++, i++)
        {
            renderersBuffer[i] = renderers[j];
        }
        for (int j = 0; j < parentRenderers.Length; j++, i++)
        {
            renderersBuffer[i] = parentRenderers[j];
        }
        for (int j = 0; j < childRenderers.Length; j++, i++)
        {
            renderersBuffer[i] = childRenderers[j];
        }

        return renderersBuffer;
    }
}
