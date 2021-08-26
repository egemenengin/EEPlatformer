// Egemen Engin 
// https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Config
    [SerializeField]  float moveSpeed = 3f;
    [SerializeField]  float jumpSpeed = 7f;
    [SerializeField] float climbSpeed = 5f;

    int health = 10;
    public Image[] hearths;
    public Sprite[] hearthTypes;//0:FULL HEARTH 1:HALF HEARTH 2: EMPTY HEARTH

    //State
    bool isAlive = true;
    bool isTakingDamage = false;

    //Cached component reference
    Rigidbody2D myRigidBody;
    CapsuleCollider2D myBodyCollider;
    CapsuleCollider2D myFeetCollider;
    float gravityInTheBeginning;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myBodyCollider = transform.GetChild(0).transform.GetComponent<CapsuleCollider2D>();
        myFeetCollider = transform.GetChild(1).transform.GetComponent<CapsuleCollider2D>();
        gravityInTheBeginning = myRigidBody.gravityScale;
    }

    void Update()
    {
        if (isAlive && !isTakingDamage)
        {
            Climb();
            Move();
            flipSprite();
            Jump();
        }
       

       
    }
    //MOVE
    public void Move()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(horizontalInput*moveSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
        if (myRigidBody.velocity.x != 0)
        {
            GetComponent<Animator>().SetBool("isRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isRunning", false);
        }
    }
    private void flipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), transform.localScale.y);
        }

    }

    //JUMP
    private void Jump()
    {
        
        if (Input.GetButtonDown("Jump")  && myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))  
        {
            //if(isGrounded)
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity = myRigidBody.velocity + jumpVelocity;
           
        }

    }



    //Climbing
    private void Climb()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(myRigidBody.velocity.x, verticalInput * climbSpeed);
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"))) {
            bool isClimbing = Mathf.Abs(climbVelocity.y) > Mathf.Epsilon;

            GetComponent<Animator>().SetBool("isClimbing", isClimbing);
            myRigidBody.velocity = climbVelocity;
            
            myRigidBody.gravityScale = 0f;
        }
        else
        {
           GetComponent<Animator>().SetBool("isClimbing", false);
            myRigidBody.gravityScale = gravityInTheBeginning;
        }
       
        
        
          
        
    }
    /*public void damageTake()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            
        }
    }*/
    public void damageTake(int damage,int rotation) 
    {
        isTakingDamage = true;
        
        for (int i = damage; i > 0; i--)
        {
            if (health > 0)
            {
                if (health % 2 == 0)
                {
                    hearths[health/2-1].GetComponent<Image>().sprite = hearthTypes[1];
                    health--;
                }
                else
                {
                    hearths[health/2].GetComponent<Image>().sprite = hearthTypes[2];
                    health--;
                }
            }
            else
            {
                break;
            }
        }
        if (health > 0)
        {
            if (rotation==0)//DAMAGE FROM LEFT
            {
                //myRigidBody.velocity = new Vector2(3f, 3f);
                myRigidBody.AddForce(new Vector2(-6f, 8f) * 10f);

            }
            else if(rotation==1)//DAMAGE FROM RIGHT
            {
                //myRigidBody.velocity = new Vector2(3f, 3f);
                myRigidBody.AddForce(new Vector2(6f, 8f) * 10f);
            }
            else if (rotation == 2)//DAMAGE FROM BOTTOM
            {
                myRigidBody.velocity = new Vector2(4f, 7f);
                //myRigidBody.AddForce(new Vector2(10f, 40f) * 10f);
            }
            StartCoroutine(takingDamageCourutine());
        }
        else
        {
            isAlive = false;
            FindObjectOfType<Canvas>().transform.Find("LosePanel").gameObject.SetActive(true);

            myRigidBody.velocity = new Vector2(0f,0f );
            GetComponent<Animator>().SetTrigger("isDead");     
            foreach(Enemy enemy in FindObjectsOfType<Enemy>())
            {
                if (enemy.GetComponent<Animator>())
                    enemy.GetComponent<Animator>().enabled = false;
                enemy.setMovementSpeed(0);
            }
        }

        
    }
    IEnumerator takingDamageCourutine()
    {

        yield return new WaitForSeconds(1);
        isTakingDamage = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            int rotation = 0;
            if (collision.GetComponent<Enemy>().getIsLeft())
            {
                rotation = 0;
            }
            else
            {
                rotation = 1;
            }
            damageTake(collision.GetComponent<Enemy>().getDamage(), rotation);
        }

        if (collision.transform.name == "Hazard")
        {
            damageTake(1, 2);
        }
        if (collision.transform.name == "Lava")
        {
            damageTake(999, 0);
        }
        if (collision.GetComponent<Coin>())
        {
            FindObjectOfType<GameSession>().addScore(collision.transform.GetComponent<Coin>().getCoinValue());
            collision.transform.GetComponent<Coin>().pickedUp();
            Destroy(collision.gameObject);
        }
    }

}
