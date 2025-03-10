using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Eunjung
{
    public class QuestManager : MonoBehaviour
    {
        public static QuestManager instance;
        /// <summary>
        /// ����Ʈ��
        /// </summary>
        private List<Quest> quests = new List<Quest>();
        /// <summary>
        /// UI ������Ʈ �̺�Ʈ (����Ʈ ���൵)
        /// </summary>
        public event System.Action<int, string> OnQuestUpdatedUI;
        /// <summary>
        /// UI ������Ʈ �̺�Ʈ (����Ʈ �Ϸ�)
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
        /// Ȱ��ȭ �� ����
        /// </summary>
        private void OnEnable()  //�����ũ�� ��ŸƮ ����
        {
            EventManager.OnEventKillEnemy += UpdateKillQuest;
            EventManager.OnEventCollectItem += UpdateCollectQuest;
            EventManager.OnEventTalkNPC += UpdateTalkNPC;
        }
        /// <summary>
        /// Ȱ��ȭ ������ ����
        /// </summary>
        private void OnDisable()
        {
            EventManager.OnEventKillEnemy -= UpdateKillQuest;
            EventManager.OnEventCollectItem -= UpdateCollectQuest;
            EventManager.OnEventTalkNPC -= UpdateTalkNPC;
        }

        public void AddQuest(Quest quest)
        {
            quests.Add(quest);
            quest.StartQuest();
            //����Ʈ �Ϸ� �̺�Ʈ ����
            quest.OnQusetCompleted += HandleQuestCompleted;
            //UI�� ����Ʈ ���� ǥ��
            UpdateQuestUI(quest);
        }

        private void UpdateKillQuest(int enemyId)
        {
            //����Ʈ ���� �� ���� ������ ���� ��������
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
            //����Ʈ ���� �� ���� ������ ���� ��������
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

        private void UpdateTalkNPC(int npcId)
        {
            //����Ʈ ���� �� ���� ������ ���� ��������
            for (int i = quests.Count - 1; i >= 0; i--)
            {
                Quest quest = quests[i];

                if (quest.questType == QuestType.Talk && quest.targetId == npcId
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
            Debug.Log($"[����Ʈ UI] �Ϸ�� ����Ʈ: {quest.title}");
            GameManager.instance.nums++;
            //UI ������Ʈ �̺�Ʈ ȣ��
            OnQuestCompletedUI?.Invoke(quest.id);

            //����Ʈ ��Ͽ��� ����
            quests.Remove(quest);
            GameManager.instance.StoryQuest(GameManager.instance.nums);
        }
    }
}
