using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float jumpSpeed;
    public AudioClip swingClip;
    public AudioClip dieClip;
    private AudioSource audioSource;
    [SerializeField]
    private AudioSource backgroundSource;
    GameObject obj;
    public GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        rigidbody2D = transform.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = swingClip;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            if(!gameController.GetComponent<GameController>().isEndGame) {
                audioSource.Play();
            }          
            float jumpVelocity = 6f;
             rigidbody2D.velocity = Vector2.up*jumpVelocity*jumpSpeed;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        gameController.GetComponent<GameController>().GetPoint();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        EndGame();
    }
    void EndGame()
    {
        audioSource.clip = dieClip;
        audioSource.Play();
        backgroundSource.volume = 0;
        gameController.GetComponent<GameController>().EndGame();
    }
}
