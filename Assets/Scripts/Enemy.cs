// Egemen Engin 
// https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    float moveSpeed = 1f;
    Rigidbody2D myRigidBody2D;


   
    [SerializeField]int damage = 1;
    bool isFacingLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    private void move()
    {
        if (isFacingLeft)
        {
            myRigidBody2D.velocity = new Vector2(-moveSpeed, myRigidBody2D.velocity.y);

        }
        else
        {
            myRigidBody2D.velocity = new Vector2(moveSpeed, myRigidBody2D.velocity.y);

        }
    }
    public int getDamage()
    {
        
        return damage;
    }
    public bool getIsLeft()
    {
        return isFacingLeft;
    }
    public void setMovementSpeed(float speed)
    {
        moveSpeed = speed;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(Mathf.Sign(myRigidBody2D.velocity.x), 1f);
        isFacingLeft = !isFacingLeft;
    }
   
}
