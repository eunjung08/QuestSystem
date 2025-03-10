using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eunjung
{
    /// <summary>
    /// ����Ʈ Ÿ��,
    /// </summary>
    public enum QuestType
    {
        Kill,           //����
        Collect,        //����
        Talk
    }

    public enum QuestStatus
    {
        NotStart,       //����Ʈ ���� �ȵ�
        Progress,       //������
        Complete        //�Ϸ�
    }
    public class Quest
    {
        public int id;
        public string title;
        public string description;
        public QuestType questType;
        public int targetId; //��ǥ ��� (���� ID �Ǵ� ������ ID)
        public int requiredAmount; //��ǥ ����
        public int currentAmount;
        public QuestStatus status;

        public event Action<Quest> OnQusetCompleted; //����Ʈ �Ϸ� �̺�Ʈ

        public Quest(int id, string title, string description,
            QuestType questType, int targetId, int requiredAmount) //������, ���� �� �� ���� ���� ����
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.questType = questType;
            this.targetId = targetId;
            this.requiredAmount = requiredAmount;
            this.currentAmount = 0;
            this.status = QuestStatus.NotStart;
        }

        public void StartQuest()
        {
            if(status == QuestStatus.NotStart)
            {
                status = QuestStatus.Progress;
                Debug.Log($"����Ʈ ����: {title}");
            }
        }

        public void Prograss(int amount)
        {
            if(status == QuestStatus.Progress)
            {
                currentAmount += amount;
                Debug.Log($"����Ʈ ����: {title} ({currentAmount}/{requiredAmount})");

                if(currentAmount >= requiredAmount)
                {
                    CompleteQuest();
                }
            }
        }

        public void CompleteQuest()
        {
            status = QuestStatus.Complete;
            Debug.Log($"����Ʈ �Ϸ�: {title}");
            OnQusetCompleted?.Invoke(this);  //completed�� �Ǹ� �ٷ� ����
        }
    }
}
