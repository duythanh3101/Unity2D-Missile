using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFollowPlayer : MonoBehaviour
{
    public Transform target;

    [SerializeField] private MapGenerator map;

    void LateUpdate()
    {
        if (target != null)
        {
            AutoFollowTarget();
        }
    }

    private void AutoFollowTarget()
    {
        Vector3 CameraPosition = transform.position;
        CameraPosition.x = Mathf.Clamp(target.position.x, map.MinX, map.MaxX);
        CameraPosition.y = Mathf.Clamp(target.position.y, map.MinY, map.MaxY);
        transform.position = CameraPosition;
    }
}
