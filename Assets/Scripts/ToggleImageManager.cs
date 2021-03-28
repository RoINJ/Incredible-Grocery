using UnityEngine;
using UnityEngine.UI;

public class ToggleImageManager : MonoBehaviour
{
    private Toggle _toggle;
    private Image _image;
    
    private void Start()
    {
        _toggle = GetComponent<Toggle>();
        _image = GetComponent<Image>();
        
        _toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool value)
    {
        var color = _image.color;
        color.a = value
            ? 0.3f
            : 1f;
        
        _image.color = color;
    }
}
