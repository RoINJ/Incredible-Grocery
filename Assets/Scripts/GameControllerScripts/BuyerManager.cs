using System;
using System.Threading.Tasks;
using UnityEngine;

namespace GameControllerScripts
{
    public class BuyerManager : MonoBehaviour
    {
        [SerializeField] private GameObject buyerPrefab;

        private BuyerAnimationManager _buyerAnimationManager;

        private async void Start()
        {
            await Task.Delay(500);
            SpawnBuyer();
        }

        private void Update()
        {
            if (_buyerAnimationManager != null)
            {
                if (!_buyerAnimationManager.IsAnimationGoing && !_buyerAnimationManager.IsLeaving)
                {
                    _buyerAnimationManager = null;
                }
            }
        }

        public void SpawnBuyer()
        {
            var buyerInstanse = Instantiate(buyerPrefab, buyerPrefab.transform.position, Quaternion.identity);
            _buyerAnimationManager = buyerInstanse.GetComponent<BuyerAnimationManager>();
        }

        public void LeaveBuyer()
        {
            var buyerInstanse = GameObject.FindWithTag("Buyer");
            _buyerAnimationManager = buyerInstanse.GetComponent<BuyerAnimationManager>();
            _buyerAnimationManager.LeaveBuyer();
        }
    }
}
