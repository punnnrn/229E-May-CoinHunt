using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Vector3 rotation;
    void Update()
    {
        this.transform.Rotate(rotation * 1 * Time.deltaTime);
    }
}