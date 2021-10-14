using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rgbd;
    [SerializeField] float startingMinMaxXForce;
    [SerializeField] Vector2 startingMinMaxYForce;
    Vector2 speed;float inc = 1f;
    Controller controller;
    bool init;
    // Start is called before the first frame update
    void Start()
    {
        //move at random direction upward
        if (!init)
        {
            rgbd = GetComponent<Rigidbody2D>();
            controller = FindObjectOfType<Controller>();
            init = false;
        }
        speed = new Vector2(Random.Range(-startingMinMaxXForce, startingMinMaxXForce),
            Random.Range(startingMinMaxYForce.x, startingMinMaxYForce.y));
        rgbd.AddForce(speed,ForceMode2D.Impulse);
        controller.playing = true;
       // rgbd.velocity = speed;
    }
   
    private void FixedUpdate()
    {
         Debug.Log("vel -- "+ transform.position.y);
        if (transform.position.y < -4.7f && controller.playing) { controller.ShowGameEndScreen();controller.playing = false; }
    }
    public void Increment()
    {
        Debug.Log("incr");
        //speed = rgbd.velocity.normalized * .5f;
        //rgbd.velocity = speed;
        if (rgbd.velocity.x == 0)
        {
            Debug.Log("force move in x direction");

            rgbd.AddForce(new Vector2(Random.Range(0,1)<.5f?3:-3, rgbd.velocity.normalized.y * inc), 
                ForceMode2D.Impulse);
        }
        else if (Mathf.Abs(rgbd.velocity.y) > 10) { Debug.Log("no adding"); }
        else { rgbd.AddForce(rgbd.velocity.normalized * inc, ForceMode2D.Impulse); Debug.Log("adding"); }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("GameContinue"))
        {
            Increment();
        }
       
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("GameFinished"))
    //    {
    //        Debug.Log("enterd");
    //        controller.ShowGameEndScreen();
    //    }
    //}
    public void Reset()
    {
        rgbd.velocity = speed = Vector2.zero;
        transform.localPosition = Vector2.zero;
        Start();
    }
}
