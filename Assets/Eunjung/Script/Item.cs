using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eunjung
{
    public class Item : MonoBehaviour
    {
        public int itemId; //아이템의 고유 ID

        public void Collect()
        {
            Debug.Log($"아이템 획득: {itemId}");
            EventManager.CollectItem(itemId);
            Destroy(gameObject);
        }
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
