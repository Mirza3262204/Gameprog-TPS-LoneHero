using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float OnscreenDelay = 3f;

    void Start()
    {
        Destroy(this.gameObject, OnscreenDelay);
    }
}
