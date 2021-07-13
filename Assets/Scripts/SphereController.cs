using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SphereController : MonoBehaviour
{
    public bool isGravityReversed;
    [SerializeField] bool isGrounded;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float sphereRotationSpeed;
    RaycastHit hit;
    public void StartRotation()
    {
        if (isGrounded)
        {
            Physics.gravity *= -1;
            DOTween.KillAll();
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isGravityReversed = !isGravityReversed;
            if (isGravityReversed)
            {
                transform.DORotate(new Vector3(0, 0, 359), sphereRotationSpeed, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
            }
            else
            {
                transform.DORotate(new Vector3(0, 0, -359), sphereRotationSpeed, RotateMode.FastBeyond360).SetLoops(-1).SetEase(Ease.Linear);
            }
        }
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f) || Physics.Raycast(transform.position, Vector3.up, out hit, 1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if(transform.localPosition.y < -1.5 || transform.localPosition.y > 1.5)
        {
            DOTween.KillAll();
            transform.rotation = Quaternion.Euler(0, 0, 0);
            GameManager.Instance.GameLost();
        }
    }
}
