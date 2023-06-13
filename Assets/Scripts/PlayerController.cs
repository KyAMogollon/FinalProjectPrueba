using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody _rb;
    bool isJump;
    bool isOtherSide=true;
    public bool selection;
    public int index=0;
    public int saveIndex = 0;
    [SerializeField] 
    float speed;
    public float jumpForce;

    [SerializeField] GameController gameController;
    DoubleCircularNode <GameObject> powerUps;
    [SerializeField] GameObject CurrentPower;
    [SerializeField] GameObject player;
    void Start()
    {
        powerUps = new DoubleCircularNode<GameObject>();
        _rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        powerUps.InsertNodeAtStart(player);
        CurrentPower = powerUps.GetHead().Value;
    }
    void Update()
    {
        if(Physics.Raycast(transform.position, Vector3.forward, 3f))
        {

        }else
        {
            //if (Input.GetKeyDown(KeyCode.W) && isOtherSide == true)
            //{
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 3);
                isOtherSide = false;
            //}
        }
        Debug.DrawRay(transform.position, Vector3.forward*3f,Color.red);
        if(Physics.Raycast(transform.position, Vector3.back, 5f))
        {

        }else
        {
            if (Input.GetKeyDown(KeyCode.S) && isOtherSide == false)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 3);
                isOtherSide = true;
            }
        }
        Debug.DrawRay(transform.position, Vector3.back * 5f, Color.red);
        ChooseAbility();
    }
    private void FixedUpdate()
    {
        
    }
    void Jump()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1.03f))
        {
            isJump = true;
            if (isJump)
            {
                _rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
        }
    }
    void ChooseAbility()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CurrentPower=powerUps.NexNode().Value;
            index++;
            if (index >= powerUps.count)
            {
                index = 0;
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CurrentPower = powerUps.PreviousNode().Value;
            index--;
            if (index <= -1)
            {
                index = powerUps.count-1;
            }
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            CurrentPower.GetComponent<PowerUps>().Ability(index);
        }
    }
    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        _rb.velocity = new Vector3(inputMovement.x*speed, _rb.velocity.y, _rb.velocity.z);
    }
    public void OnMovement1(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        _rb.velocity = new Vector3(inputMovement.x , _rb.velocity.y, _rb.velocity.z * speed);
    }
    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            Jump();
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "PowerUps")
        {
            CurrentPower = collision.gameObject;
            powerUps.InsertNodeAtEnd(CurrentPower);
            powerUps.GetLastNode();
            collision.gameObject.SetActive(false);
            saveIndex++;
            index = saveIndex;
        }
    }
}
