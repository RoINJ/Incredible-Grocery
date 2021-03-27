using UnityEngine;
using UnityEngine.UI;

public class ToggleImageManager : MonoBehaviour
{
    private Toggle toggle;
    private Image image;
    
    private void Start()
    {
        toggle = GetComponent<Toggle>();
        image = GetComponent<Image>();
        
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool value)
    {
        var alpha = value
            ? 0.3f
            : 1f;

        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
    }
}
