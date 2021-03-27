using System.Linq;
using UnityEngine;

namespace GameControllerScripts
{
    public class ProductsManager : MonoBehaviour
    {
        [SerializeField] private Sprite[] products;

        public Sprite[] Products => products;
    
        public Sprite[] GetRandomProducts(int count)
        {
            var random = new System.Random();

            var result = new Sprite[count];
            var tmpProducts = Products.ToList();

            for (int i = 0; i < count; i++)
            {
                var index = random.Next(0, tmpProducts.Count);
                result[i] = tmpProducts[index];
                tmpProducts.RemoveAt(index);
            }

            return result;
        }
    }
}
