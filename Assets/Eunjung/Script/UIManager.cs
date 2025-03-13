using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eunjung
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;

        public GameObject monsterQ1;
        public GameObject monsterQ2;
        public GameObject itemQ1;
        public GameObject itemQ2;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            monsterQ1.SetActive(false);
            monsterQ2.SetActive(false);
            itemQ1.SetActive(false);
            itemQ2.SetActive(false);
        }
    }
}
