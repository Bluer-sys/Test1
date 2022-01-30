using System.Threading.Tasks;
using UnityEngine;

namespace Services
{
    public interface IAssetProvider : IService
    {
        void Initialize();
        Task<GameObject> Instantiate(string address);
        Task<GameObject> Instantiate(string address, Transform parent);
        
        Task<GameObject> Instantiate(string address, Vector3 at);

        Task<GameObject> Instantiate(string address, Vector3 at, Transform parent);
    }
}