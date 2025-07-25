using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Vector3 rotateTarget;
    public float rotateSpeed;
    public bool startRotate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.Rotate(0f, transform.rotation.y, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion target = Quaternion.Euler(0, 180f, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * rotateSpeed);
    }
}
