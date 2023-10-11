using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Vector3 Offset;
    public float smoothness;
    Transform PlayerTransform;
    void Start()
    {
        PlayerTransform = GameObject.Find("Player").transform;
        Offset=PlayerTransform.position-transform.position;
    }
    private void Update()
    {
        Follow();
    }
    public void Follow() => transform.position =Vector3.Lerp(transform.position, PlayerTransform.position - Offset,smoothness);
}
