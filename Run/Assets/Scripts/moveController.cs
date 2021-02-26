using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveController : MonoBehaviour {
    public float moveHSpeed = 5.0f;
    public float maxVSpeed = 10.0f;
    public float minVSpeed = 5.0f;
    public float jumpHeight = 5.0f;
    static bool isjump;  //判断是否出于跳跃状态
    float jump_state = 0f; //跳跃状态
    Animator role_animator;
    double begin_time;  //起跳时间
    double now_time;   //当前时间，用于判断起跳是否完成

    float moveVSpeed;
    public Transform cameraTransform;
    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().freezeRotation = true;
        role_animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {       
        float h = Input.GetAxis("Horizontal");
        isjump = Input.GetKeyDown("space");
        //AnimatorStateInfo stateInfo = role_animator.GetCurrentAnimatorStateInfo(0);
        if (isjump)
        {
            role_animator.SetBool("Jump", true);
            jump_state = 1;
        }
        Vector3 vSpeed = new Vector3(this.transform.forward.x, this.transform.forward.y, this.transform.forward.z) * minVSpeed;
        Vector3 hSpeed = new Vector3(this.transform.right.x, this.transform.right.y, this.transform.right.z) * moveHSpeed * h;
        Vector3 jumpSpeed = new Vector3(this.transform.up.x, this.transform.up.y, this.transform.up.z) * jumpHeight * jump_state;
        this.transform.position += (vSpeed + hSpeed + jumpSpeed) * Time.deltaTime;
        Vector3 vCameraSpeed = new Vector3(this.transform.forward.x, this.transform.forward.y, this.transform.forward.z) * minVSpeed;
        cameraTransform.position += (vCameraSpeed) * Time.deltaTime;
	}
}
