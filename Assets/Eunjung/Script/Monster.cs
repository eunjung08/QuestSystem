using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eunjung
{
    public class Monster : MonoBehaviour
    {
        public int monsterId;
        public void Kill()
        {
            Debug.Log($"���� óġ��: {monsterId}");
            EventManager.KillEnmey(monsterId);
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
