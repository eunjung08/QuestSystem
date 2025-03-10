using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eunjung
{
    public class Talk : MonoBehaviour
    {
        public int npcId;

        public void Talks()
        {
            Debug.Log($"¥Î»≠: {npcId}");
            EventManager.TalkNPC(npcId);
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
