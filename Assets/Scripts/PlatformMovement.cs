using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] float speed;
    public void StartPlatformMovement()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
