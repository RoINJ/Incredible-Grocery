using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameControllerScripts
{
    public class OrderManager : MonoBehaviour
    {
        private readonly List<int> _orderedProducts = new List<int>();
    
        private ProductsManager _productsManager;
        private DialogManager _dialogManager;
        private BalanceManager _balanceManager;
        private BuyerManager _buyerManager;
        private StorageManager _storageManager;

        public int OrderSize => _orderedProducts.Count;

        public async void GetNewOrder()
        {
            var random = new System.Random();
            var count = random.Next(1, 4);
        
            _orderedProducts.Clear();

            var newProducts = _productsManager.GetRandomProducts(count);
            foreach (var product in newProducts)
            {
                _orderedProducts.Add(Array.IndexOf(_productsManager.Products, product));
            }

            await _dialogManager.ShowNewOrder(newProducts);
            
            _storageManager.OpenStorage();
        }
        
        public async void CompareWithOrder(IEnumerable<int> indexes)
        {
            var results = indexes.Select(x => _orderedProducts.Contains(x));
        
            var productSprites = indexes.Select(x => _productsManager.Products[x]).ToArray();
            await _dialogManager.ShowOrderConfirmation(productSprites, results.ToArray());

            var countOfCorrectProducts = results.Count(x => x);
            var isOrderCompleted = countOfCorrectProducts == OrderSize;
            
            await _dialogManager.ShowBuyerReaction(isOrderCompleted);

            var orderCost = isOrderCompleted
                ? countOfCorrectProducts * 10 * 2
                : countOfCorrectProducts * 10;

            _balanceManager.TotalMoney += orderCost;
        
            _buyerManager.LeaveBuyer();
        }

        private void Start()
        {
            _productsManager = GetComponent<ProductsManager>();
            _dialogManager = GetComponent<DialogManager>();
            _balanceManager = GetComponent<BalanceManager>();
            _buyerManager = GetComponent<BuyerManager>();

            _storageManager = FindObjectOfType<Canvas>().GetComponentInChildren<StorageManager>();
        }
    }
}
