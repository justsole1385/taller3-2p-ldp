using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Configuración")]
    public float moveSpeed = 5f;
    public float jumpForce = 6f;
    public Sprite[] mySprites;

    private Rigidbody2D myRigidBody2D; 
    private SpriteRenderer mySpriteRenderer;
    private int index = 0;

    private bool isGrounded;

    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        
        // Evita que el personaje se caiga o rote
        myRigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        
        StartCoroutine(WalkCoRutine());
    }

    void Update()
    {
        // CORREGIDO: Saltar con la tecla E (como pidió la docente)
        if (Input.GetKeyDown(KeyCode.E) && isGrounded)
        {
            myRigidBody2D.linearVelocity = new Vector2(myRigidBody2D.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // CORREGIDO: Moverse solo automáticamente hacia la derecha todo el tiempo
        myRigidBody2D.linearVelocity = new Vector2(moveSpeed, myRigidBody2D.linearVelocity.y);
    }

    IEnumerator WalkCoRutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            
            if (mySprites.Length > 0) 
            {
                mySpriteRenderer.sprite = mySprites[index];
                index++;
                
                if (index >= mySprites.Length) 
                {
                    index = 0;
                }
            }
        }
    }

    // --- Sistema simple para detectar el suelo ---
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
