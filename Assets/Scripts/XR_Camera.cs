using UnityEngine;
using UnityEngine.XR;

public class XR_Camera : MonoBehaviour
{
    private Gyroscope gyro;
    private bool gyroEnabled;
    private Quaternion rotFix;

    void Start()
    {
        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = false; // Force reset
            Input.gyro.enabled = true;  // Reactivate gyroscope
            gyro = Input.gyro; // Assign gyro after enabling it
            rotFix = new Quaternion(0, 0, 1, 0);
            return true;
        }
        return false;
    }

    void Update()
    {
        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rotFix;
        }
    }

    private void OnDisable()
    {
        // Do nothing here, so gyro stays active
    }

    private void OnEnable()
    {
        gyroEnabled = EnableGyro(); // Re-enable when script is enabled again
    }
}

