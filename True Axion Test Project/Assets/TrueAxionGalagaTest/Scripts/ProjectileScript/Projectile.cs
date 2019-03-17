using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Tooltip("The Speed Of Projectile")]
    public float speed = 6f;

    [Tooltip("the direction where the projectile will move to")]
    public Vector3 moveDirection;

    //min and max of viewport for checking if the projectile is off-screen 
    Vector2 minViewport;
    Vector2 maxViewport;

    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {
        //Get The Viewport EveryFrame
        minViewport = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxViewport = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        MoveProjectile();
        DestroyOnOffScreen();
    }

    //Transform the projectile according to its move direction
    public void MoveProjectile()
    {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    //Destroy The Projectile If It's off-screen
    void DestroyOnOffScreen()
    {
        if (transform.position.y < minViewport.y || transform.position.y > maxViewport.y)
        {
            Destroy(gameObject);
        }
    }
}
