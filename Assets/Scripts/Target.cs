using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private TargetType _targetType;
    [SerializeField]
    private float _influeceRadius;
    [SerializeField]
    private float _weight;

    public float GetAcceleration(Vector3 boidPosition)
    {
        float distance = (transform.position - boidPosition).magnitude;
        if (distance > _influeceRadius) 
            return 0;
        
        if (_targetType == TargetType.CloseAttracter)
        {
            return _weight / distance;
        }
        else
        {
            return _weight * distance;
        }
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _influeceRadius);
    }
    
}
[Serializable]
public struct TargetParams
{
    public Vector3 offsetToTarget;
    public float targetWheight;
}

enum TargetType
{
    CloseAttracter,
    FarAttracter,
    // AntiAttracter
}