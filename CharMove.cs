using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    private Rigidbody rb;

    float m_MoveVelocity = 5.0f;

    float h = 0, v = 0;
    Vector3 MoveNextStep;   //���� ����� ���� ����
    Vector3 MoveHStep;
    Vector3 MoveVStep;

    float a_CalcRotY = 1.0f;
    float rotSpeed = 100.0f;    //�ʴ� ȸ���ӵ�

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        KeyBDMove();
    }

    void KeyBDMove()    //Ű���� �̵�
    {
        //������ ���� �̵� ó��
        h = Input.GetAxisRaw("Horizontal"); //ȭ��ǥŰ �¿츦 �����ָ� -1,0,1 ���̰��� �����Ѵ�.
        v = Input.GetAxisRaw("Vertical");   //ȭ��ǥŰ �� �Ʒ��� �����ָ� -1,0,1���̰��� �����Ѵ�.

        //if (v < 0)
           // v = 0;


        if (h != 0 || v != 0)  //Ű���� �̵�ó��
        {
            a_CalcRotY = transform.eulerAngles.y;
            a_CalcRotY = a_CalcRotY + (h * rotSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, a_CalcRotY, 0);  //ȸ��

            MoveVStep = transform.forward * v;
            MoveNextStep = MoveVStep;
            MoveNextStep = MoveNextStep.normalized * m_MoveVelocity * Time.deltaTime;   //����,����

            transform.position += MoveNextStep;
        }
    }
}