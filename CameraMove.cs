using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private GameObject m_Player = null;
    private Vector3 m_TargetPos = Vector3.zero;

    //카메라 위치 계산용 변수
    private float m_PosX = 0.0f;        //마우스 좌우 조작값 
    private float m_PosY = 0.0f;        //마우스 상하 조작값
    private float xSpeed = 5.0f;        //마우스 좌우 회전에 대한 카메라 회전 스피드
    private float ySpeed = 2.4f;        //마우스 상하 회전에 대한 카메라 회전 스피드
    private float yMinLimit = -7.0f;    //위 아래 각도 제한
    private float yMaxLimit = 80.0f;    //위 아래 각도 제한
    private float zoomSpeed = 1.0f;     //줌인, 줌아웃 스피드
    private float maxDist = 50.0f;      //마우스 줌 아웃 최대 거리
    private float minDist = 3.0f;       //마우스 줌 인 최소 거리         

    //플레이어 기준 카메라 좌표 초기값
    private float m_DefaltPosX = 0.0f;  //평면 회전각도
    private float m_DefaltPosY = 27.0f; //높이 회전각도
    private float m_DefaltDist = 6f;    //플레이어와 카메라 사이의 거리

    private Quaternion a_BuffRot;
    private Vector3 a_BasicPos = Vector3.zero;
    public float distance = 20.0f;
    private Vector3 a_BuffPos;

    void Start()
    {
        m_Player = GameObject.Find("seol");

        m_TargetPos = m_Player.transform.position;
        m_TargetPos.y = m_TargetPos.y + 1.4f;

        //카메라 위치 계산 공식
        m_PosX = m_DefaltPosX-180;  //평면 기준회전각도
        m_PosY = m_DefaltPosY;      //높이 기준회전각도
        distance = m_DefaltDist;

        a_BuffRot = Quaternion.Euler(m_PosY, m_PosX, 0);
        a_BasicPos.x = 0.0f;
        a_BasicPos.y = 0.0f;
        a_BasicPos.z = -distance;

        a_BuffPos = a_BuffRot * a_BasicPos + m_TargetPos;

        transform.position = a_BuffPos; //카메라의 좌표계 기준 위치

        transform.LookAt(m_TargetPos);
    }

    private void LateUpdate()
    {
        if (m_Player != null)
        {
            m_TargetPos = m_Player.transform.position;
            m_TargetPos.y = m_TargetPos.y + 2f;    //카메라 높이를 플레이어보다 1.4f높게
        }

        if (Input.GetMouseButton(1))    //마우스 우측 버튼을 누르고 있는 동안
        {
            m_PosX += Input.GetAxis("Mouse X") * xSpeed;    //마우스를 좌우로 움직였을 때의 값
            m_PosY -= Input.GetAxis("Mouse Y") * ySpeed;    //마우스를 위아래로 움직였을 때의 값

            m_PosY = ClampAngle(m_PosY, yMinLimit, yMaxLimit);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && distance > minDist)
        {
            distance -= zoomSpeed;  //줌 인
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0 && distance < maxDist)
        {
            distance += zoomSpeed;  //줌 아웃
        }

        a_BuffRot = Quaternion.Euler(m_PosY, m_PosX, 0);
        a_BasicPos.x = 0.0f;
        a_BasicPos.y = 0.0f;
        a_BasicPos.z = -distance;

        a_BuffPos = a_BuffRot * a_BasicPos + m_TargetPos;

        transform.position = a_BuffPos;    //zoom 카메라의 직각좌표계 기준의 위치

        transform.LookAt(m_TargetPos);
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)   //-360->0
            angle += 360;
        if (angle > 360)    //360->0
            angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}
