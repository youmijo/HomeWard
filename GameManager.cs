using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;
    public GameObject talkPanel;
    public GameObject mainPanel;
    public Text npcName;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;
    public bool isStart;
    public bool isEsc;
    public int talkIndex;
    public GameObject menuSet;

    void Start()
    {
        talkPanel.SetActive(false);
        //menuSet.SetActive(false);

        isAction = false;
        isEsc = false;

    }

    public void Action(GameObject scanObj)
    {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);

        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc)
    {
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            Debug.Log(questManager.CheckQuest(id));
            return;
        }

        if (isNpc)
        {
            npcName.text = scanObject.name;
            talkText.text = talkData;
        }
        else
        {
            talkText.text = talkData;
        }

        isAction = true;
        talkIndex++;
    }

    void Update()
    {
        //menuSet.SetActive(isEsc);

        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
            {
                menuSet.SetActive(false);
                //isEsc = false;
            }

            else
            {
                menuSet.SetActive(true);
                //isEsc = true;
            }
        }

        if (menuSet.activeSelf)
        {
            //menuSet.SetActive(false);
            isEsc = true;
        }

        else
        {
            //menuSet.SetActive(true);
            isEsc = false;
        }

        if (mainPanel.activeSelf)
            isStart = true;
        else
            isStart = false;

    }

    public void GameExit()
    {
        Application.Quit();
    }
}
