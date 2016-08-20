﻿using UnityEngine;
using System.Collections;

public class smoothCameraFollow : MonoBehaviour {

    public float damping = 0.15f;
    private Vector3 vel = Vector3.zero;
    public Transform target;
    private Camera cam;

	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (target)
        {
            Vector3 point = cam.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - cam.ViewportToWorldPoint(new Vector3(0.5f,0.5f,point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref vel, damping);
        }
	}
}
