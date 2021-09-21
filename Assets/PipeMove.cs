using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    private float minY;
    private float maxY;
    private float prePosition;
    private GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        prePosition = 10.5f;
        minY = -2.5f;
        maxY = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(-1*Time.deltaTime*moveSpeed, 0));
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("ResetWall"))
            obj.transform.position = new Vector3(prePosition, Random.Range(minY, maxY), -1);
    }
}
