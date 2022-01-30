using System.Collections.Generic;
using System.Linq;
using Player;
using UnityEngine;

namespace UI.Elements
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private GameObject _hpPrefab;

        private List<Hp> _readyHp = new List<Hp>();

        private void Awake()
        {
            _readyHp = _container.GetComponentsInChildren<Hp>().ToList();
        }

        public void AddHp()
        {
            Hp additionHp = _readyHp.FirstOrDefault(p => p.gameObject.activeSelf == false);

            if (additionHp == null)
            {
                additionHp = Instantiate(_hpPrefab, _container).GetComponent<Hp>();
                _readyHp.Add(additionHp);
            }

            additionHp.gameObject.SetActive(true);
        }

        public void RemoveHp()
        {
            Hp removingHp = _readyHp.FirstOrDefault(p => p.gameObject.activeSelf == true);
            
            if(removingHp == null)
                return;

            removingHp.gameObject.SetActive(false);
        }
    }
}