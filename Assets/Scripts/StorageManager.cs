using System;
using System.Collections.Generic;
using System.Linq;
using GameControllerScripts;
using UnityEngine;
using UnityEngine.UI;

public class StorageManager : MonoBehaviour
{
    [SerializeField] private AudioClip selectProductSound;
    
    private readonly List<int> _selectedProducts = new List<int>();

    private Toggle[] _toggleGroup;

    private ProductsManager _productsManager;
    private OrderManager _orderManager;
    private StorageOpener _storageOpener;
    private Button _sellButton;

    public void OpenStorage()
    {
        _storageOpener.IsOpened = true;
    }

    private void Start()
    {
        var gameController = GameObject.FindWithTag(Constants.Tags.GameController);
        
        _productsManager = gameController.GetComponent<ProductsManager>();
        _orderManager = gameController.GetComponent<OrderManager>();
        
        _storageOpener = GetComponentInChildren<StorageOpener>();

        _sellButton = GetComponentInChildren<Button>();
        _sellButton.interactable = false;
        _sellButton.onClick.AddListener(OnSellButtonClick);

        _toggleGroup = GetComponentsInChildren<Toggle>();

        for (int i = 0; i < _toggleGroup.Length; i++)
        {
            _toggleGroup[i].image.sprite = _productsManager.Products[i];
            var i1 = i;
            _toggleGroup[i].onValueChanged.AddListener(isChecked => OnToggleValueChanged(isChecked, i1));
        }
    }

    private void OnToggleValueChanged(bool isChecked, int index)
    {
        SoundManager.Instanse.PlaySound(selectProductSound, transform.position);
        
        if (isChecked)
        {
            _selectedProducts.Add(index);
        }
        else
        {
            _selectedProducts.Remove(index);
        }

        if (_selectedProducts.Count >= 3)
        {
            var disabledToggles = _toggleGroup.Where(x => !x.isOn);
            foreach (var toggle in disabledToggles)
            {
                toggle.enabled = false;
            }
        }
        else
        {
            foreach (var toggle in _toggleGroup)
            {
                toggle.enabled = _selectedProducts.Count < 3;
            }
        }
        

        _sellButton.interactable = _selectedProducts.Count == _orderManager.OrderSize;
    }

    private void OnSellButtonClick()
    {
        _storageOpener.IsOpened = false;
        
        _orderManager.CompareWithOrder(_selectedProducts.ToList());
        
        foreach (var toggle in _toggleGroup)
        {
            toggle.isOn = false;
        }
    }
}