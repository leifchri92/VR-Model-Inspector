using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorToggle : MonoBehaviour {

    [SerializeField]
    private Color highlightedColor;
	[SerializeField]
    private Color normalColor;

	public List<Button> buttons;
    private Button selectedButton = null;

    public void SelectButton(Button selectedButton) {
        if (this.selectedButton == null) {
            this.selectedButton = selectedButton;
        } else if (this.selectedButton == selectedButton) {
            this.selectedButton = null;
        } else {
            this.selectedButton = selectedButton;
        }

        foreach (Button button in buttons) {
            ColorBlock colorBlock = button.colors;
            if (button == this.selectedButton)
            {
                colorBlock.normalColor = highlightedColor;
            }
            else
            {
                colorBlock.normalColor = normalColor;
            }
            button.colors = colorBlock;
        }
    }
}
