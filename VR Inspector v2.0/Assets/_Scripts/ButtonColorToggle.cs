using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorToggle : MonoBehaviour {

    [SerializeField]
    private Color highlightedColor;
    private Color normalColor;

    [SerializeField]
    private List<Button> buttons;
    private Button selectedButton = null;

    private void Awake()
    {
        if (buttons.Count == 0)
            return;

        normalColor = buttons[0].colors.normalColor;
    }

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
