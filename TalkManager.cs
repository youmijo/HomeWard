using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        //1000: ������ / 2000: ��ä���� / 3000: �������ֽ� / 4000: ������ / 5000: ġŲ�� 
        talkData.Add(1000, new string[] { "��ɼ�!" });
        talkData.Add(2000, new string[] { "������ ������ ����!! ��ġ�� ������~!!" });
        talkData.Add(3000, new string[] { "�׳��׳� �ż��� ���Ϸ� �غ��մϴ�." });
        talkData.Add(4000, new string[] { "�츮 �� ������ �� Ǫ���׸��ƿ����� �����ϴٰ�." });
        talkData.Add(5000, new string[] { "���~ ��Ϳ�~" });

        //Quest Talk
        talkData.Add(10 + 4000, new string[] { "��... �л�?",
                                                "�׷�. �л� ����.\nȤ�� �� ��Ź �� ����� �� ������?",
                                                "�� ��� ������ �ð��ε�, ��� �Ǽ��� �̰� ��°�� ��������� ������.\n�ٸ� �͵� �غ��ؾ� �ؼ� ������ ���� ��Ḧ �緯 �� ���� ����.",
                                                "�л��� �ٳ�� �� �� �ְھ�?\n�� �� ���� �ȿ��� ���� �� �ִ� �͵��̾�." });
        talkData.Add(11 + 1000, new string[] { "���� �帱��!\n�� �Ұ�� �� ������� �� �߰��", "��! �޾ư���!" });
        talkData.Add(12 + 2000, new string[] { "�������~�̽��� ä�� �־��~!\n�� ���� �� ���� �� ���", "�����մϴ�~!!" });
        talkData.Add(13 + 3000, new string[] { "�ֹ��Ͻðھ��?\n�� �������ֽ� �� �ٳ����ֽ� �� ����ֽ�", "�������ֽ� �� �� ���Խ��ϴ�." });
        talkData.Add(14 + 5000, new string[] { "���~ ó�� ���� �������ε�.\n�׷�~ �� ���� �ٱ��?", "�� ����~ ������ �� �Ϳ�~" });

        talkData.Add(20 + 4000, new string[] { "���� �ٳ�Դ�? ��� ����~\n�̽��� �ɷ� �� ���Գ�. ����." });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
            {
                return GetTalk(id - id % 100, talkIndex);
            }
            else
            {
                return GetTalk(id - id % 10, talkIndex);
            }
        }

        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}