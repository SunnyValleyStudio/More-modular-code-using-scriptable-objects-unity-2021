using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
        [SerializeField] private Animator animator;
    
    	[SerializeField] private AnimationCurve accelerationCurve;
    
    	[SerializeField] private  Rigidbody2D rb2d;
    
    	[SerializeField] private float maxSpeed = 3;
        [SerializeField] private float accelerationMaxTime = 1;
    	private float buttonHeldTime;
    	private bool isMoving;

        [SerializeField] private string animationMovementX = "InputX";
        [SerializeField] private string animationMovementY = "InputY";
    
    	private void Awake()
    	{
    		rb2d = GetComponent<Rigidbody2D>();
    	}
    
    	private void Update()
    	{
    		Vector2 input = GetInput();
    
    		SetAnimation(input);
    		SetAccelerationParameters(input);
    
    		float speed = CalculateSpeed(input, accelerationCurve);
    
    		SetVelocity(speed, input);
    	}
    
    	private void SetAnimation(Vector2 input)
    	{
    		animator.SetFloat(animationMovementX, input.x);
            animator.SetFloat(animationMovementY, input.y);
        }
    
    	private void SetVelocity(float speed, Vector2 input)
    	{
    		rb2d.velocity = input.normalized * speed;
    	}
    
    	private void SetAccelerationParameters(Vector2 input)
    	{
    		if (input.magnitude > 0)
    		{
    			isMoving = true;
    			buttonHeldTime += Time.deltaTime;
    		}
    		else
    		{
    			isMoving = false;
    			buttonHeldTime = 0;
    		}
    	}
    
    	private float CalculateSpeed(Vector2 input, AnimationCurve animationCurve)
    	{
    		if (isMoving)
    		{
    			float acceleration = accelerationCurve.Evaluate(buttonHeldTime/ accelerationMaxTime) ;
    			return maxSpeed * acceleration;
    		}
    		else
    		{
    			return 0;
    		}
    	}
    
    	private Vector2 GetInput()
    	{
    		return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    	}
}
