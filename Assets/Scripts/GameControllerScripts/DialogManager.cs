using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace GameControllerScripts
{
    public class DialogManager : MonoBehaviour
    {
        [SerializeField] private Sprite acceptSprite;
        [SerializeField] private Sprite declineSprite;
    
        [SerializeField] private Sprite goodReaction;
        [SerializeField] private Sprite badReaction;

        [SerializeField] private GameObject seller;

        [SerializeField] private GameObject cloudPrefab;

        private readonly Vector3 _cloudOffset = new Vector3(2, 2, 0);

        public async Task ShowNewOrder(Sprite[] products)
        {
            var buyer = GameObject.FindWithTag(Constants.Tags.Buyer);
        
            var cloud = Instantiate(cloudPrefab, buyer.transform.position + _cloudOffset, Quaternion.identity);

            var productsRenderers = GetCloudSpriteRenderers(cloud);

            for (int i = 0; i < products.Length; i++)
            {
                productsRenderers[i].sprite = products[i];
            }

            await Task.Delay(Constants.Delays.NEW_ORDER_CLOUD_DELAY);

            Destroy(cloud);
        }

        public async Task ShowOrderConfirmation(Sprite[] products, bool[] results)
        {
            var cloud = Instantiate(cloudPrefab, seller.transform.position + _cloudOffset, Quaternion.identity);

            var productsRenderers = GetCloudSpriteRenderers(cloud);

            for (int i = 0; i < products.Length; i++)
            {
                productsRenderers[i].sprite = products[i];
            }

            await Task.Delay(Constants.Delays.ORDER_CONFIRMATION_CLOUD_DELAY);
        
            for (int i = 0; i < products.Length; i++)
            {
                var color = productsRenderers[i].color;
                color.a = 0.3f;
                productsRenderers[i].color = color;

                var confirmationSpriteRenderer = Instantiate(new GameObject(), productsRenderers[i].transform)
                    .AddComponent<SpriteRenderer>();
            
                confirmationSpriteRenderer.sprite = results[i]
                    ? acceptSprite
                    : declineSprite;
            
                await Task.Delay(Constants.Delays.CHECK_ORDER_CLOUD_DELAY);
            }

            await Task.Delay(Constants.Delays.ORDER_CONFIRMATION_CLOUD_DELAY);
        
            Destroy(cloud);
        }
    
        public async Task ShowBuyerReaction(bool value)
        {
            var buyer = GameObject.FindWithTag(Constants.Tags.Buyer);
        
            var cloud = Instantiate(cloudPrefab, buyer.transform.position + _cloudOffset, Quaternion.identity);

            var renderers = GetCloudSpriteRenderers(cloud);

            renderers[1].sprite = value
                ? goodReaction
                : badReaction;
            
            await Task.Delay(1000);

            Destroy(cloud);
        }

        private static SpriteRenderer[] GetCloudSpriteRenderers(GameObject cloud)
        {
            return cloud.GetComponentsInChildren<SpriteRenderer>()
                .Where(x => x.gameObject != cloud.gameObject)
                .ToArray();
        }
    }
}