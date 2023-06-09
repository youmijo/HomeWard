using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;

    Dictionary<int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }

    void GenerateData()
    {
        questList.Add(10, new QuestData("������ �ɺθ�", new int[] { 4000, 1000, 2000, 3000, 5000 }));
        questList.Add(20, new QuestData("�ɺθ� �Ϸ�", new int[] { 4000 }));
        questList.Add(30, new QuestData("Ŭ����", new int[] { 0 }));
    }

    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        if (id == questList[questId].npcId[questActionIndex])
            questActionIndex++;

        if (questActionIndex == questList[questId].npcId.Length)
        {
            NextQuest();
        }

        return questList[questId].questName;
    }

    public string CheckQuest()
    {
        return questList[questId].questName;
    }
}