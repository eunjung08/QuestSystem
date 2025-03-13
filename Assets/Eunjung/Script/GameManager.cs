using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
            //����Ʈ �Ŵ��� �̱��� ��������
            questManager = QuestManager.instance;

            questManager.OnQuestUpdatedUI +=
                QuestUIManager.instance.UpdateQuestProgress;

            questManager.OnQuestCompletedUI +=
                QuestUIManager.instance.CompleteQuest;

            StoryQuest(nums);
        }

        /// <summary>
        /// ����Ʈ �߰�
        /// </summary>
        /// <param name="num"></param>
        public void BtnQuest(int num)
        {
            switch (num)
            {
                case 1:     //���� ����Ʈ ���� 101
                    {
                        //���� óġ ����Ʈ �߰�
                        Quest killQuest = new Quest(1, "���� ���",
                            "���븦 5���� óġ�϶�", QuestType.Kill, 101, 5);
                        questManager.AddQuest(killQuest);
                    }
                    break;
                case 2:     //���� ����Ʈ ���� 102
                    {
                        //���� óġ ����Ʈ �߰�
                        Quest killQuest = new Quest(2, "���� ���",
                            "���븦 5���� óġ�϶�", QuestType.Kill, 102, 5);
                        questManager.AddQuest(killQuest);
                    }
                    break;
                case 3:     //������ ����Ʈ ���� 201
                    {
                        Quest collectQuest = new Quest(3, "���� ����",
                            "������ 3�� ��ƶ�", QuestType.Collect, 201, 3);
                        questManager.AddQuest(collectQuest);
                    }
                    break;
                case 4:     //������ ����Ʈ ���� 202
                    {
                        Quest collectQuest = new Quest(4, "���� ����",
                            "������ 3�� ��ƶ�", QuestType.Collect, 202, 3);
                        questManager.AddQuest(collectQuest);
                    }
                    break;
                case 0:
                    {
                        Quest chatQuest = new Quest(0, "��ȭ",
                            "NPC�� ��ȭ�� �϶�", QuestType.Talk, 301, 1);
                        questManager.AddQuest(chatQuest);
                    }
                    break;
            }
        }
        public int nums=0;
        public void StoryQuest(int nums)
        {
            switch (nums)
            {
                case 0:
                    {
                        Quest chatQuest = new Quest(0, "���� �Խ��� Ȯ��",
                            "���� �Խ��� Ȯ��", QuestType.Talk, 301, 1);
                        questManager.AddQuest(chatQuest);
                        Debug.Log("���� �Խ����� Ȯ�� �غ�����!");
                    }
                    break;
                case 1:     //���� ����Ʈ ���� 101
                    {
                        //���� óġ ����Ʈ �߰�
                        Quest killQuest = new Quest(1, "���� ���",
                            "���븦 5���� óġ�϶�", QuestType.Kill, 101, 5);
                        questManager.AddQuest(killQuest);
                    }
                    break;
                case 2:     //���� ����Ʈ ���� 102
                    {
                        //���� óġ ����Ʈ �߰�
                        Quest killQuest = new Quest(2, "���� ���",
                            "���븦 5���� óġ�϶�", QuestType.Kill, 102, 5);
                        questManager.AddQuest(killQuest);
                    }
                    break;
                case 3:     //������ ����Ʈ ���� 201
                    {
                        Quest collectQuest = new Quest(3, "���� ����",
                            "������ 3�� ��ƶ�", QuestType.Collect, 201, 3);
                        questManager.AddQuest(collectQuest);
                    }
                    break;
                case 4:     //������ ����Ʈ ���� 202
                    {
                        Quest collectQuest = new Quest(4, "���� ����",
                            "������ 3�� ��ƶ�", QuestType.Collect, 202, 3);
                        questManager.AddQuest(collectQuest);
                    }
                    break;
            }
        }

        /// <summary>
        /// ���� ų
        /// </summary>
        /// <param name="num"></param>
        public void SetKillMonst(int num)
        {
            switch (num)
            {
                case 0:         //���� 101 óġ
                    {
                        EventManager.KillEnmey(101);
                    }
                    break;
                case 1:         //���� 102 óġ
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
                case 0:         //������ 201 ȹ��
                    {
                        EventManager.CollectItem(201);
                    }
                    break;
                case 1:         //������ 202 ȹ��
                    {
                        EventManager.CollectItem(202);
                    }
                    break;
            }
        }

       public void SetTalkNPC(int num)
        {
            switch (num)
            {
                case 0:
                    {
                        EventManager.TalkNPC(301);
                    }
                    break;
            }
        }
    }
}
