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
            gyro = Input.gyro;
            gyro.enabled = true;
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
}
