using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotateSpeed = 150f;
    public float jumpVelocity = 3f;
    public float distanceToGround = 0.01f;
    public LayerMask groundLayer;

    public GameObject bullet;
    public float bulletSpeed = 25f;

    private bool doShoot;
    private bool doJump;

    private float vInput;
    private float hInput;
    private Rigidbody _rb;
    private CapsuleCollider _col;
    private GameBehavior _gameManager;
    private ScaleBehavior scaleBehavior;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _col = GetComponent<CapsuleCollider>();

        _gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();

        scaleBehavior = GetComponent<ScaleBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scaleBehavior.doShrink == true)
        {
            moveSpeed = .3f;
            jumpVelocity = 1f;
            doShoot = false;
        }

        if (scaleBehavior.doEnlarge == true)
        {
            moveSpeed = 3f;
            jumpVelocity = 3f;
        } 

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            doJump = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            doShoot = true;
        }

        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
    }

    // 
    void FixedUpdate()
    {
        // Jumping when flag is triggered
        if (doJump)
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            doJump = false;
        }
        
        // Bullet when left mouse is triggered
        if (doShoot)
        {
            GameObject newBullet = Instantiate (bullet, this.transform.position + new Vector3(0, 0, 0), this.transform.rotation) as GameObject;
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletSpeed;
            doShoot = false;
        }

        Vector3 rotation = Vector3.up * hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position + this.transform.forward * vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3 (_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);
        
        return grounded;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            _gameManager.HP -= 1;
        }
    }

    /*
        Speed Boost
    */
    private float speedMultiplier;

    public void BoostSpeed(float multiplier, float seconds)
    {
        speedMultiplier = multiplier;
        moveSpeed *= multiplier;
        Invoke("EndSpeedBoost", seconds);
    }

    private void EndSpeedBoost()
    {
        Debug.Log("Speed Boost Ended");
        moveSpeed /= speedMultiplier;
    }
}
