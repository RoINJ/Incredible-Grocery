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

        public async Task ShowNewOrder(Sprite[] products)
        {
            var buyer = GameObject.FindWithTag("Buyer");
        
            var cloud = Instantiate(cloudPrefab, buyer.transform.position + new Vector3(2, 2, 0), Quaternion.identity);

            var productsRenderers = GetCloudSpriteRenderers(cloud);

            for (int i = 0; i < products.Length; i++)
            {
                productsRenderers[i].sprite = products[i];
            }

            await Task.Delay(Constants.NEW_ORDER_CLOUD_DELAY);

            Destroy(cloud);
        }

        public async Task ShowOrderConfirmation(Sprite[] products, bool[] results)
        {
            var cloud = Instantiate(cloudPrefab, seller.transform.position + new Vector3(2, 2, 0), Quaternion.identity);

            var productsRenderers = GetCloudSpriteRenderers(cloud);

            for (int i = 0; i < products.Length; i++)
            {
                productsRenderers[i].sprite = products[i];
            }

            await Task.Delay(Constants.ORDER_CONFIRMATION_CLOUD_DELAY);
        
            for (int i = 0; i < products.Length; i++)
            {
                var color = productsRenderers[i].color;
                productsRenderers[i].color = new Color(color.r, color.g, color.b, 0.3f);

                var confirmationSpriteRenderer = Instantiate(new GameObject(), productsRenderers[i].transform)
                    .AddComponent<SpriteRenderer>();
            
                confirmationSpriteRenderer.sprite = results[i]
                    ? acceptSprite
                    : declineSprite;
            
                await Task.Delay(Constants.CHECK_ORDER_CLOUD_DELAY);
            }

            await Task.Delay(Constants.ORDER_CONFIRMATION_CLOUD_DELAY);
        
            Destroy(cloud);
        }
    
        public async Task ShowBuyerReaction(bool value)
        {
            var buyer = GameObject.FindWithTag("Buyer");
        
            var cloud = Instantiate(cloudPrefab, buyer.transform.position + new Vector3(2, 2, 0), Quaternion.identity);

            var renderers = GetCloudSpriteRenderers(cloud);

            renderers[1].sprite = value
                ? goodReaction
                : badReaction;
            
            await Task.Delay(1000);

            Destroy(cloud);
        }

        private SpriteRenderer[] GetCloudSpriteRenderers(GameObject cloud)
        {
            return cloud.GetComponentsInChildren<SpriteRenderer>()
                .Where(x => x.gameObject != cloud.gameObject)
                .ToArray();
        }
    }
}