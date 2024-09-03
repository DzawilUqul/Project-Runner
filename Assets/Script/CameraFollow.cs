using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Dino sebagai target
    public Vector3 offset; // Offset dari posisi Dino

    void Update()
    {
        // Atur posisi kamera agar mengikuti Dino dengan offset yang telah ditentukan
        transform.position = target.position + offset;
    }
}
