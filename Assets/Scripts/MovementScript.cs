using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*	Author: Marcel
*	Version: 1.0
*	Date: 29.04.2018
*/

public class MovementScript : MonoBehaviour {

	private enum Direction { UP, DOWN, LEFT, RIGHT };

	private bool canMove;
	private bool moving;

	public int speed;
	public int buttonCooldown;

	private Direction dir;
	private Vector3 pos;

	// Use this for initialization
	public void Start () {
		canMove = true;
		moving = false;
		speed = 5;
		buttonCooldown = 0;
		dir = Direction.DOWN;

	}

	// Update is called once per frame
	public void Update() {
		buttonCooldown--;
		if(canMove) { 
			transformPosition();
		}
		if (moving) {
			if(transform.position == pos)
			{
				moving = false;
				canMove = true;
				move();
			}
			transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
		}
	}

	private void transformPosition() {
		pos = transform.position;
		move ();	
	}

	private void move() {
		if (buttonCooldown <= 0) {

			if (Input.GetAxis ("Vertical") > 0) { //forward
				if(dir != Direction.UP) {
					buttonCooldown = 5;
					dir = Direction.UP;
				} else {
					canMove = false;
					moving = true;
					pos += Vector3.forward;
				}			

			} else if (Input.GetAxis ("Vertical") < 0) { //backwards
				if(dir != Direction.DOWN) {
					buttonCooldown = 5;
					dir = Direction.DOWN;
				} else {
					canMove = false;
					moving = true;
					pos += Vector3.back;
				}

			} else if (Input.GetAxis ("Horizontal") > 0) { //right
				if(dir != Direction.RIGHT) {
					buttonCooldown = 5;
					dir = Direction.RIGHT;
				} else {
					canMove = false;
					moving = true;
					pos += Vector3.right;					
				}

			} else if (Input.GetAxis ("Horizontal") < 0) { //left
				if(dir != Direction.LEFT) {
					buttonCooldown = 5;
					dir = Direction.LEFT;
				} else {
					canMove = false;
					moving = true;
					pos += Vector3.left;
				}
			}
		}	
	}





}
