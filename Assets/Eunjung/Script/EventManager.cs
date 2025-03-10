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
        /// 적 처치 이벤트
        /// </summary>
        public static event Action<int> OnEventKillEnemy;
        /// <summary>
        /// 아이템 획득 이벤트
        /// </summary>
        public static event Action<int> OnEventCollectItem;

        public static event Action<int> OnEventTalkNPC;

        /// <summary>
        /// 적 처치 함수
        /// </summary>
        /// <param name="enemyId"></param>
        public static void KillEnmey(int enemyId)
        {
            OnEventKillEnemy.Invoke(enemyId); //실행하는건 Invoke
        }

        /// <summary>
        /// 아이템 획득 이벤트
        /// </summary>
        /// <param name="itemId"></param>
        public static void CollectItem(int itemId)
        {
            OnEventCollectItem.Invoke(itemId);
        }

        public static void TalkNPC(int npcId)
        {
            OnEventTalkNPC.Invoke(npcId);
        }
    }
}
