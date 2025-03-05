using PlasticGui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Eunjung
{
    public class QuestUIManager : MonoBehaviour
    {
        public static QuestUIManager instance;
        public Text questText; //UI �ؽ�Ʈ (�ν����Ϳ��� ����)

        private Dictionary<int, string> questProgress = new Dictionary<int, string>(); //Dictionary : key�� value�� ����

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
        public void UpdateQuestProgress(int questId, string questInfo)
        {
            //����Ʈ ���� ������ ����
            questProgress[questId] = questInfo;
            RefreshUI();
        }

        public void CompleteQuest(int questId)
        {
            if (questProgress.ContainsKey(questId)) //�� ����Ʈ ���̵� �ִ��� Ȯ��
            {
                questProgress.Remove(questId); //��� ����
                RefreshUI();
            }
        }

        public void RefreshUI()
        {
            questText.text = ""; //���� �ؽ�Ʈ �ʱ�ȭ

            foreach (var quest in questProgress.Values)
            {
                questText.text += quest + "\n";
            }
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
