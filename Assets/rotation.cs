using UnityEngine;
using System.Collections;

public class rotation : MonoBehaviour {

    public float rotationAmount = 3.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward * rotationAmount);
	}
}
