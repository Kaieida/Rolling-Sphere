using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollision : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (GameManager.Instance.gameState == GameManager.GameState.playing)
        {
            GameManager.Instance.AddPoint();
        }
    }
}
