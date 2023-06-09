using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private GameObject m_Player = null;
    private Vector3 m_TargetPos = Vector3.zero;

    //ī�޶� ��ġ ���� ����
    private float m_PosX = 0.0f;    //���콺 �¿� ���۰� 
    private float m_PosY = 0.0f;    //���콺 ���� ���۰�
    private float xSpeed = 5.0f;    //���콺 �¿� ȸ���� ���� ī�޶� ȸ�� ���ǵ�
    private float ySpeed = 2.4f;    //���콺 ���� ȸ���� ���� ī�޶� ȸ�� ���ǵ�
    private float yMinLimit = -7.0f;    //�� �Ʒ� ���� ����
    private float yMaxLimit = 80.0f;    //�� �Ʒ� ���� ����
    private float zoomSpeed = 1.0f; //����,�ܾƿ� ���ǵ�
    private float maxDist = 50.0f;  //���콺 �� �ƿ� �ִ� �Ÿ�
    private float minDist = 3.0f;  //���콺 �� �� �ּ� �Ÿ�
                           

    //���ΰ� ���� ī�޶� ��ǥ �ʱⰪ
    private float m_DefaltPosX = 0.0f;  //��� ȸ������
    private float m_DefaltPosY = 27.0f; //���� ȸ������
    private float m_DefaltDist = 6f;  //���ΰ�~ī�޶� �Ÿ�

    private Quaternion a_BuffRot;
    private Vector3 a_BasicPos = Vector3.zero;
    public float distance = 20.0f;
    private Vector3 a_BuffPos;

    void Start()
    {
        m_Player = GameObject.Find("seol");

        m_TargetPos = m_Player.transform.position;
        m_TargetPos.y = m_TargetPos.y + 1.4f;

        //ī�޶� ��ġ ��� ����
        m_PosX = m_DefaltPosX-180;  //��� ����ȸ������
        m_PosY = m_DefaltPosY;  //���� ����ȸ������
        distance = m_DefaltDist;

        a_BuffRot = Quaternion.Euler(m_PosY, m_PosX, 0);
        a_BasicPos.x = 0.0f;
        a_BasicPos.y = 0.0f;
        a_BasicPos.z = -distance;

        a_BuffPos = a_BuffRot * a_BasicPos + m_TargetPos;

        transform.position = a_BuffPos; //ī�޶��� ��ǥ�� ���� ��ġ

        transform.LookAt(m_TargetPos);
    }

    private void LateUpdate()
    {
        if (m_Player != null)
        {
            m_TargetPos = m_Player.transform.position;
            m_TargetPos.y = m_TargetPos.y + 2f;   //ī�޶� ���̸� �÷��̾�� 1.4f����
        }

        if (Input.GetMouseButton(1))//���콺 ���� ��ư�� ������ �ִ� ����
        {
            m_PosX += Input.GetAxis("Mouse X") * xSpeed;    //���콺�� �¿�� �������� ���� ��
            m_PosY -= Input.GetAxis("Mouse Y") * ySpeed;    //���콺�� ���Ʒ��� �������� ���� ��

            m_PosY = ClampAngle(m_PosY, yMinLimit, yMaxLimit);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && distance > minDist)
        {
            distance -= zoomSpeed;  //�� ��
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && distance < maxDist)
        {
            distance += zoomSpeed;  //�� �ƿ�
        }

        a_BuffRot = Quaternion.Euler(m_PosY, m_PosX, 0);
        a_BasicPos.x = 0.0f;
        a_BasicPos.y = 0.0f;
        a_BasicPos.z = -distance;

        a_BuffPos = a_BuffRot * a_BasicPos + m_TargetPos;

        transform.position = a_BuffPos;    //zoom ī�޶��� ������ǥ�� ������ ��ġ

        transform.LookAt(m_TargetPos);
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)   //-360->0
            angle += 360;
        if (angle > 360)    //360->0
            angle -= 360;   //���� �̷絵��

        return Mathf.Clamp(angle, min, max);
    }

}