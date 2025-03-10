using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eunjung
{
    /// <summary>
    /// 퀘스트 타입,
    /// </summary>
    public enum QuestType
    {
        Kill,           //설명
        Collect,        //수집
        Talk
    }

    public enum QuestStatus
    {
        NotStart,       //퀘스트 시작 안됨
        Progress,       //진행중
        Complete        //완료
    }
    public class Quest
    {
        public int id;
        public string title;
        public string description;
        public QuestType questType;
        public int targetId; //목표 대상 (몬스터 ID 또는 아이템 ID)
        public int requiredAmount; //목표 개수
        public int currentAmount;
        public QuestStatus status;

        public event Action<Quest> OnQusetCompleted; //퀘스트 완료 이벤트

        public Quest(int id, string title, string description,
            QuestType questType, int targetId, int requiredAmount) //생성자, 생성 할 때 가장 먼저 실행
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
                Debug.Log($"퀘스트 시작: {title}");
            }
        }

        public void Prograss(int amount)
        {
            if(status == QuestStatus.Progress)
            {
                currentAmount += amount;
                Debug.Log($"퀘스트 진행: {title} ({currentAmount}/{requiredAmount})");

                if(currentAmount >= requiredAmount)
                {
                    CompleteQuest();
                }
            }
        }

        public void CompleteQuest()
        {
            status = QuestStatus.Complete;
            Debug.Log($"퀘스트 완료: {title}");
            OnQusetCompleted?.Invoke(this);  //completed가 되면 바로 실행
        }
    }
}
