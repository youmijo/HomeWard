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
        //1000: 정육점, 2000: 야채가게, 3000: 생과일주스, 4000: 수프집, 5000: 치킨집 
        talkData.Add(1000, new string[] { "어서옵쇼!" });
        talkData.Add(2000, new string[] { "오늘의 마지막 할인!! 놓치지 마세요~!!" });
        talkData.Add(3000, new string[] { "그날그날 신선한 과일로 준비합니다." });
        talkData.Add(4000, new string[] { "우리 집 수프는 이 푸드테리아에서도 유명하다고." });
        talkData.Add(5000, new string[] { "어머~ 어서와요~" });

        //Quest Talk
        talkData.Add(10 + 4000, new string[] { "저... 학생?",
                                                "그래. 학생 말야.\n혹시 내 부탁 좀 들어줄 수 있을까?",
                                                "곧 장사 시작할 시간인데, 사실 실수로 이걸 통째로 엎어버려서 말이지.\n다른 것도 준비해야 해서 지금은 내가 재료를 사러 갈 수가 없어.",
                                                "학생이 다녀와 줄 수 있겠어?\n다 이 시장 안에서 구할 수 있는 것들이야." });
                                                
        talkData.Add(11 + 1000, new string[] { "뭘로 드릴까!\n① 소고기 ② 돼지고기 ③ 닭고기", "자! 받아가쇼!" });
        talkData.Add(12 + 2000, new string[] { "어서오세요~싱싱한 채소 있어요~!\n① 양파 ② 감자 ③ 당근", "감사합니다~!!" });
        talkData.Add(13 + 3000, new string[] { "주문하시겠어요?\n① 오렌지주스 ② 바나나주스 ③ 사과주스", "오렌지주스 네 잔 나왔습니다." });
        talkData.Add(14 + 5000, new string[] { "어머~ 처음 보는 여행자인데.\n그래~ 몇 마리 줄까요?", "자 여기~ 다음에 또 와요~" });

        talkData.Add(20 + 4000, new string[] { "벌써 다녀왔니? 어디 볼까~\n싱싱한 걸로 잘 골라왔네. 고마워." });
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
