using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject go_Target;

    [SerializeField]
    private float speed;

    private Vector3 difValue;

    void Start()
    {
        difValue = transform.position - go_Target.transform.position;
    
    }

     // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, go_Target.transform.position + difValue, Time.deltaTime * speed); 
    }
}
