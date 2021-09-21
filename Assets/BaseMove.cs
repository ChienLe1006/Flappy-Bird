using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMove : MonoBehaviour
{
    public float moveSpeed;
    public float moveRange;
    private Vector3 prePosition;
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        prePosition = obj.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1*Time.deltaTime*moveSpeed, 0, 0));
        if (Vector3.Distance(prePosition, obj.transform.position) > moveRange) {
            obj.transform.position = prePosition;
        }
    }
}
