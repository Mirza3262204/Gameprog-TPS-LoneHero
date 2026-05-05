using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 CamOffset = new Vector3(0f, 1.2f, -2.6f);

    private Transform target;

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void LateUpdate()
    {
        transform.position = target.TransformPoint(CamOffset);
        transform.LookAt(target);
    }
}