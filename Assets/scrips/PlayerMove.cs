using UnityEngine;
using Fusion;

public class PlayerMove : NetworkBehaviour
{
    public CharacterController controller;    
    public float Speed = 10f;
    public float JumpHeight = 3f; // Chiều cao nhảy
    public float Gravity = -9.81f; // Gia tốc trọng trường
    private Vector3 velocity; // Vận tốc hiện tại

    public override void FixedUpdateNetwork()
    {

        if (!Object.HasStateAuthority) return;

        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        var move = transform.right * x + transform.forward * z;

        // Kiểm tra xem nhân vật có đang chạm đất hay không
        if (controller.isGrounded)
        {
            velocity.y = 0f; // Reset vận tốc theo trục y khi chạm đất

            // Kiểm tra xem phím cách có được nhấn hay không
            if (Input.GetButtonDown("Jump"))
            {   
                velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity); // Tính toán vận tốc nhảy
            }
        }

        // Áp dụng trọng lực
        velocity.y += Gravity * Time.fixedDeltaTime;

        // Di chuyển nhân vật
        controller.Move((move * Speed + velocity) * Time.fixedDeltaTime);
    }
}
//using UnityEngine;
//using Fusion;


//public class PlayerMove : NetworkBehaviour
//{
//    public CharacterController controller;
//    public float jump = 5f;
//    public float Speed = 10f;
//    private Rigidbody rb;
//    public override void FixedUpdateNetwork()
//    {
//        //kiem tra xem nguoi choi co dang dieu khien hay khong
//        if (!Object.HasStateAuthority) return;
//        float horizontalInput = Input.GetAxis("Horizontal");
//        float verticalInput = Input.GetAxis("Vertical");

//        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * Speed;


//        if (Input.GetButtonDown("Jump") && IsGrounded())
//        {
//            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
//        }
//        bool IsGrounded()
//        {
//            RaycastHit hit;
//            return Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f);
//        }
//    }
//}
