using Cinemachine;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float yMaxSpeed = 7;
    [SerializeField] private float xMaxSpeed = 900;
    [SerializeField] private CinemachineFreeLook FL;
     private float minRadius = 3;
     private float maxRadius = 5;
     private float zoomSpeed = 2.5f;
     private float minHigtTop = 2.5f;
     private float maxHigtTop = 5.5f;
     private float minHigtBotom = -1.5f;
     private float maxHigtBotom = -4.0f;
    void Update()
    {
        CameraMover();
        CameraZoom();
    }
    void CameraMover()
    {
        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            FL.m_YAxis.m_MaxSpeed = yMaxSpeed;
            FL.m_XAxis.m_MaxSpeed = xMaxSpeed;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            FL.m_YAxis.m_MaxSpeed = 0f;
            FL.m_XAxis.m_MaxSpeed = 0f;
        }
    }
    void CameraZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            float D = FL.m_Orbits[1].m_Radius - scroll * zoomSpeed; // D means Distance
            FL.m_Orbits[0].m_Height = Mathf.Clamp(D, minHigtTop, maxHigtTop);// heigt
            FL.m_Orbits[1].m_Radius = Mathf.Clamp(D, minRadius, maxRadius);// radius
            FL.m_Orbits[2].m_Height = Mathf.Clamp(D, minHigtBotom, maxHigtBotom);// heigt
        }
    }
}
