using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Referanse til input systemet v�rt
    private PlayerInput playerInputAction;

    // Kontroll over hvor h�yt spiller kan hoppe
    [SerializeField] private float jumpForce = 0f;

    // Kontroll over hvor raskt spilleren blir dratt nedover
    [SerializeField] private float gravityStrength = 0f;

    // Referanse til RigidBody komponent
    private Rigidbody rb;

    // Har spilleren lov til � hoppe eller ikke?
    private bool canJump = true;

    // Hvor lang tid skal spilleren IKKE f� lov til � hoppe
    [SerializeField] private float jumpRecoveryTime;

    // Lyd som skal spilles av hvis vi krasjer.
    [SerializeField] private AudioClip crashSFX;


    private void Awake()
    {
        playerInputAction = new PlayerInput();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnEnable()
    {
        playerInputAction.Enable();
    }

    private void OnDisable()
    {
        playerInputAction.Disable();
    }

    private void FixedUpdate()
    {
        // Legg til en kraft som trekker spilleren v�r nedover
        rb.AddForce(Vector3.down * gravityStrength, ForceMode.Acceleration);
    }

    private void Update()
    {
        // Hvis spilleren trykker p� space OG har lov til � hoppe, s� hopp
        if(playerInputAction.Player.Jump.triggered && canJump)
        {
            // Nullstille hastighet (velocity)
            rb.linearVelocity = Vector3.zero;

            // Dytte spilleren oppover med en bestemt kraft (jumpPower)
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // Setter vi canJump til false
            canJump = false;

            // Starter en timer som setter canJump tilbake til True etter en gitt tid
            StartCoroutine(JumpResetTimer(jumpRecoveryTime));
        }

        IEnumerator JumpResetTimer(float recoveryTime)
        {
            yield return new WaitForSeconds(recoveryTime);
            canJump = true;
        }
    }


    // Laster scenen v�r p� nytt om vi kolliderer med noe.
    private void OnCollisionEnter(Collision collision)
    {
        AudioManager.instance.PlayCrashSFX(crashSFX);
        SceneManager.LoadScene(0);
    }




}
