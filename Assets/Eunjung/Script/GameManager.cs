using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eunjung
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        QuestManager questManager;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            //퀘스트 매니저 싱글톤 가져오기
            questManager = QuestManager.instance;

            questManager.OnQuestUpdatedUI +=
                QuestUIManager.instance.UpdateQuestProgress;

            questManager.OnQuestCompletedUI +=
                QuestUIManager.instance.CompleteQuest;
        }
        /// <summary>
        /// 퀘스트 추가
        /// </summary>
        /// <param name="num"></param>
        public void BtnQuest(int num)
        {
            switch (num)
            {
                case 0:     //몬스터 퀘스트 시작 101
                    {
                        //몬스터 처치 퀘스트 추가
                        Quest killQuest = new Quest(0, "늑대 사냥",
                            "늑대를 5마리 처치하라", QuestType.Kill, 101, 5);
                        questManager.AddQuest(killQuest);
                    }
                    break;
                case 1:     //몬스터 퀘스트 시작 102
                    {
                        //몬스터 처치 퀘스트 추가
                        Quest killQuest = new Quest(1, "늑대 사냥",
                            "늑대를 5마리 처치하라", QuestType.Kill, 102, 5);
                        questManager.AddQuest(killQuest);
                    }
                    break;
                case 2:     //아이템 퀘스트 시 201
                    {
                        Quest collectQuest = new Quest(2, "보석 수집",
                            "보석을 3개 모아라", QuestType.Collect, 201, 3);
                        questManager.AddQuest(collectQuest);
                    }
                    break;
                case 3:     //아이템 퀘스트 시 202
                    {
                        Quest collectQuest = new Quest(3, "보석 수집",
                            "보석을 3개 모아라", QuestType.Collect, 202, 3);
                        questManager.AddQuest(collectQuest);
                    }
                    break;
            }
        }
        /// <summary>
        /// 몬스터 킬
        /// </summary>
        /// <param name="num"></param>
        public void SetKillMonst(int num)
        {
            switch (num)
            {
                case 0:         //몬스터 101 처치
                    {
                        EventManager.KillEnmey(101);
                    }
                    break;
                case 1:         //몬스터 102 처치
                    {
                        EventManager.KillEnmey(102);
                    }
                    break;
            }
        }

        public void SetCollectItem(int num)
        {
            switch (num)
            {
                case 0:         //아이템 201 획득
                    {
                        EventManager.CollectItem(201);
                    }
                    break;
                case 1:         //아이템 202 획득
                    {
                        EventManager.CollectItem(202);
                    }
                    break;
            }
        }
    }
}
