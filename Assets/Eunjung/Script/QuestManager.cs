using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eunjung
{
    public class QuestManager : MonoBehaviour
    {
        public static QuestManager instance;
        /// <summary>
        /// 퀘스트들
        /// </summary>
        private List<Quest> quests = new List<Quest>();
        /// <summary>
        /// UI 업데이트 이벤트 (퀘스트 진행도)
        /// </summary>
        public event System.Action<int, string> OnQuestUpdatedUI;
        /// <summary>
        /// UI 업데이트 이벤트 (퀘스트 완료)
        /// </summary>
        public event System.Action<int> OnQuestCompletedUI;

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
        }

        /// <summary>
        /// 활성화 시 동작
        /// </summary>
        private void OnEnable()  //어웨이크랑 스타트 사이
        {
            EventManager.OnEventKillEnemy += UpdateKillQuest;
            EventManager.OnEventCollectItem += UpdateCollectQuest;
        }
        /// <summary>
        /// 활성화 해제시 동작
        /// </summary>
        private void OnDisable()
        {
            EventManager.OnEventKillEnemy -= UpdateKillQuest;
            EventManager.OnEventCollectItem -= UpdateCollectQuest;
        }

        public void AddQuest(Quest quest)
        {
            quests.Add(quest);
            quest.StartQuest();
            //퀘스트 완료 이벤트 연결
            quest.OnQusetCompleted += HandleQuestCompleted;
            //UI에 퀘스트 정보 표시
            UpdateQuestUI(quest);
        }

        private void UpdateKillQuest(int enemyId)
        {
            //리스트 삭제 후 오류 방지를 위해 역순으로
            for (int i = quests.Count - 1; i >= 0; i--)
            {
                Quest quest = quests[i];

                if (quest.questType == QuestType.Kill && quest.targetId == enemyId
                    && quest.status == QuestStatus.Progress)
                {
                    quest.Prograss(1);
                    UpdateQuestUI(quest);
                }
            }
        }

        private void UpdateCollectQuest(int itemId)
        {
            //리스트 삭제 후 오류 방지를 위해 역순으로
            for (int i = quests.Count - 1; i >= 0; i--)
            {
                Quest quest = quests[i];

                if (quest.questType == QuestType.Collect && quest.targetId == itemId
                    && quest.status == QuestStatus.Progress)
                {
                    quest.Prograss(1);
                    UpdateQuestUI(quest);

                }
            }
        }

        private void UpdateQuestUI(Quest quest)
        {
            string questInfo = $"{quest.title}: {quest.currentAmount}" +
                $"/{quest.requiredAmount}";
            OnQuestUpdatedUI?.Invoke(quest.id, questInfo);
        }

        private void HandleQuestCompleted(Quest quest)
        {
            Debug.Log($"[퀘스트 UI] 완료된 퀘스트: {quest.title}");

            //UI 업데이트 이벤트 호출
            OnQuestCompletedUI?.Invoke(quest.id);

            //퀘스트 목록에서 삭제
            quests.Remove(quest);
        }
    }
}
