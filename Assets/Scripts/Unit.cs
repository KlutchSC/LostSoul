using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {

    public Rigidbody2D myBody = new Rigidbody2D();
    public SpriteRenderer myRender = new SpriteRenderer();

    public float maxSpeed = 100.0f;

    public float health;
    public bool isStunned;

    public void MoveHorizontal(float dir)
    {
        myBody.velocity = new Vector2((dir * maxSpeed * Time.deltaTime), myBody.velocity.y);
    }

    public void MoveVerticle(float dir)
    {
        myBody.velocity = new Vector2(myBody.velocity.x, (dir * maxSpeed * Time.deltaTime));
    }

    public void Jump()
    {
        myBody.velocity = new Vector2(myBody.velocity.x, (10.0f * maxSpeed * Time.deltaTime));
    }
}
