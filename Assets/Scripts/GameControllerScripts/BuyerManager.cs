using System.Threading.Tasks;
using UnityEngine;

namespace GameControllerScripts
{
    public class BuyerManager : MonoBehaviour
    {
        [SerializeField] private GameObject buyerPrefab;

        private BuyerAnimationManager _buyerAnimationManager;
        private OrderManager _orderManager;

        public async void SpawnBuyer()
        {
            await Task.Delay(1000);
            
            var buyerInstanse = Instantiate(buyerPrefab, buyerPrefab.transform.position, Quaternion.identity);
            _buyerAnimationManager = buyerInstanse.GetComponent<BuyerAnimationManager>();
        }

        public void LeaveBuyer()
        {
            var buyerInstanse = GameObject.FindWithTag(Constants.Tags.Buyer);
            _buyerAnimationManager = buyerInstanse.GetComponent<BuyerAnimationManager>();
            _buyerAnimationManager.LeaveBuyer();
        }
        
        private void Start()
        {
            _orderManager = GetComponent<OrderManager>();
            
            SpawnBuyer();
        }

        private void Update()
        {
            if (!(_buyerAnimationManager is null))
            {
                if (!_buyerAnimationManager.IsAnimationGoing && !_buyerAnimationManager.IsLeaving)
                {
                    _orderManager.GetNewOrder();
                    _buyerAnimationManager = null;
                }
            }
        }
    }
}