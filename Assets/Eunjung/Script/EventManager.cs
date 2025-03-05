using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Eunjung
{
    public class EventManager
    {
        /// <summary>
        /// �� óġ �̺�Ʈ
        /// </summary>
        public static event Action<int> OnEventKillEnemy;
        /// <summary>
        /// ������ ȹ�� �̺�Ʈ
        /// </summary>
        public static event Action<int> OnEventCollectItem;

        /// <summary>
        /// �� óġ �Լ�
        /// </summary>
        /// <param name="enemyId"></param>
        public static void KillEnmey(int enemyId)
        {
            OnEventKillEnemy.Invoke(enemyId); //�����ϴ°� Invoke
        }

        /// <summary>
        /// ������ ȹ�� �̺�Ʈ
        /// </summary>
        /// <param name="itemId"></param>
        public static void CollectItem(int itemId)
        {
            OnEventCollectItem.Invoke(itemId);
        }
    }
}
