using Cinemachine;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float topRing;
    public float middleRing;
    public float bottomRing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetComponent<CinemachineFreeLook>();

            // move camera
        }
    }
}
