using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    private Rigidbody rb;

    float m_MoveVelocity = 5.0f;

    float h = 0, v = 0;
    Vector3 MoveNextStep;   //보폭 계산을 위한 변수
    Vector3 MoveHStep;
    Vector3 MoveVStep;

    float a_CalcRotY = 1.0f;
    float rotSpeed = 100.0f;    //초당 회전속도

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        KeyBDMove();
    }

    void KeyBDMove()    //키보드 이동
    {
        //가감속 없이 이동 처리
        h = Input.GetAxisRaw("Horizontal"); //화살표키 좌우를 눌러주면 -1,0,1 사이값을 리턴한다.
        v = Input.GetAxisRaw("Vertical");   //화살표키 위 아래를 눌러주면 -1,0,1사이값을 리턴한다.

        //if (v < 0)
           // v = 0;


        if (h != 0 || v != 0)  //키보드 이동처리
        {
            a_CalcRotY = transform.eulerAngles.y;
            a_CalcRotY = a_CalcRotY + (h * rotSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, a_CalcRotY, 0);  //회전

            MoveVStep = transform.forward * v;
            MoveNextStep = MoveVStep;
            MoveNextStep = MoveNextStep.normalized * m_MoveVelocity * Time.deltaTime;   //전진,후진

            transform.position += MoveNextStep;
        }
    }
}