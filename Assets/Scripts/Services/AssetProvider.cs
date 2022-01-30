using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Services
{
    public class AssetProvider : IAssetProvider
    {
        public void Initialize()
        {
            Addressables.InitializeAsync();
        }
        
        public Task<GameObject> Instantiate(string address)
        {
            return Addressables.InstantiateAsync(address).Task;
        }

        public Task<GameObject> Instantiate(string address, Transform parent)
        {
            return Addressables.InstantiateAsync(address, parent).Task;
        }
        
        public Task<GameObject> Instantiate(string address, Vector3 at)
        {
            return Addressables.InstantiateAsync(address, at, Quaternion.identity).Task;
        }
        
        public Task<GameObject> Instantiate(string address, Vector3 at, Transform parent)
        {
            return Addressables.InstantiateAsync(address, at, Quaternion.identity, parent).Task;
        }
    }
}