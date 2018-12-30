using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    private PlayerMotor motor;


    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        //calculate movement velocity as a vector
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        //Apply Movement
        motor.Move(velocity);


        //Calculate Horizontal Rotation
        float _yRotation = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f , _yRotation, 0f) * lookSensitivity;

        motor.Rotate(_rotation);

        //Calculate  Vertical Rotation
        float _xRotation = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(_xRotation, 0f, 0f) * lookSensitivity;

        motor.RotateCamera(_cameraRotation);
    }
}
