using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;

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
    public event Action<int> Oncollision;

    DoubleCircularNode <GameObject> powerUps;
    [SerializeField] GameObject CurrentPower;
    [SerializeField] GameObject player;
    [SerializeField] GameObject powerUpGrande;
    [SerializeField] GameObject powerUpChico;
    [SerializeField] GameObject powerUpSalto;
    [SerializeField] GameManager gameManager;
    Vector3 movementPlayer;
    public Vector3 gravity;
    public Vector3 speedJump;
    [SerializeField] WaveController wave;
    Animator animation;
    [SerializeField]LayerMask layermask;
    bool suelo;
    private void Awake()
    {
        animation = GetComponentInChildren<Animator>();
        Physics.gravity = gravity;
    }
    void Start()
    {
        powerUps = new DoubleCircularNode<GameObject>();
        _rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        powerUps.InsertNodeAtStart(player);
        CurrentPower = powerUps.GetHead().Value;
        powerUps.InsertNodeAtEnd(powerUpGrande);
        powerUps.InsertNodeAtEnd(powerUpChico);
        powerUps.InsertNodeAtEnd(powerUpSalto);
        index = 3;
        CurrentPower = powerUps.GetLastNode().Value;
    }
    void Update()
    {
        Oncollision?.Invoke(index);

    }
    private void FixedUpdate()
    {
        _rb.velocity =new Vector3( movementPlayer.x*speed,_rb.velocity.y,_rb.velocity.z);
    }
    void Jump()
    {
        suelo = Physics.Raycast(transform.position, Vector3.down, 1.03f);
        if (suelo)
        {
            isJump = true;
            if (isJump)
            {
                _rb.velocity = speedJump;
                animation.SetTrigger("tambienSuelo");
            }
        }
    }
    /*public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        movementPlayer = new Vector3(inputMovement.x, 0, 0);
        if(inputMovement.x < 0)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else if(inputMovement.x > 0)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
    }*/
    public void OnMovementAbilityRight(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            CurrentPower = powerUps.NexNode().Value;
            index++;
            if (index >= powerUps.count)
            {
                index = 0;
            }
        }
    }
    public void OnMovementAbilityLeft(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            CurrentPower = powerUps.PreviousNode().Value;
            index--;
            if (index <= -1)
            {
                index = powerUps.count - 1;
            }
        }
    }
    public void OnSelectionAbility(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            CurrentPower.GetComponent<PowerUps>().Ability(index);
            wave.transform.position = new Vector3(wave.transform.position.x + 1, wave.transform.position.y, wave.transform.position.z);
        }
    }
    public void OnMovementFront(InputAction.CallbackContext value)
    {
        if (Physics.Raycast(transform.position, Vector3.forward, 3f))
        {

        }
        else
        {
            if (value.started && isOtherSide == true)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.5f);
                isOtherSide = false;
            }
        }
    }
    public void OnMovementBack(InputAction.CallbackContext value)
    {
        if (Physics.Raycast(transform.position, Vector3.back, 5f))
        {

        }
        else
        {
            if (value.started && isOtherSide == false)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1.5f);
                isOtherSide = true;
            }
        }
    }
    public void OnJump(InputAction.CallbackContext value)
    {
        if (value.started)
        {
            Jump();
        }
    }
    /*IEnumerator TimeToMoveWave()
    {
        if (waveMove == true)
        {
            float avanzar = 0.10f;
            float avanzar2 = avanzar;
            while (avanzar < 1)
            {
                wave.transform.position = new Vector3(wave.transform.position.x + avanzar2, wave.transform.position.y, wave.transform.position.z);
                avanzar += 0.10f;
            }
        }

    }*/
    private void OnTriggerEnter(Collider collision)
    {
        /*if (collision.gameObject.tag == "PowerUps")
        {
            CurrentPower = collision.gameObject;
            powerUps.InsertNodeAtEnd(CurrentPower);
            powerUps.GetLastNode();
            collision.gameObject.SetActive(false);
            saveIndex++;
            index = saveIndex;
            Oncollision?.Invoke(saveIndex);
        }*/
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Wave")
        {
            Time.timeScale = 0;
            gameManager.GameOverMethod();
        }
        while (transform.localScale.x >=1)
        {

        }
    }
}
