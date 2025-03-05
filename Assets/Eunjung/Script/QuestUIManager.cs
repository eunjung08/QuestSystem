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
        public Text questText; //UI 텍스트 (인스펙터에서 연결)

        private Dictionary<int, string> questProgress = new Dictionary<int, string>(); //Dictionary : key랑 value로 구성

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
            //퀘스트 진행 정보를 갱신
            questProgress[questId] = questInfo;
            RefreshUI();
        }

        public void CompleteQuest(int questId)
        {
            if (questProgress.ContainsKey(questId)) //이 퀘스트 아이디가 있는지 확인
            {
                questProgress.Remove(questId); //즉시 삭제
                RefreshUI();
            }
        }

        public void RefreshUI()
        {
            questText.text = ""; //기존 텍스트 초기화

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
