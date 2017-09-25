using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	//set up misc variables
	public Rigidbody2D Player;
	Vector3 rotate = new Vector3( 0, 0, 25 );
	private int velo = 1;

	public float JumpHeight = 8f;


	//Player State Machine
	public enum PlayerState
	{
		MenuIdle, Playing, HitObstacle, HitGround, GroundIdle
	}

	public enum MenuState
	{
		MainMenu, InGame, EndScreen
	}

	//define states
	PlayerState player_state;
	MenuState menu_state;


	//Set Screen Variables
	public GameObject MainScreen;
	public GameObject InGScreen;
	public GameObject EndGScreenTop;
	public GameObject EndGScreenBottom;





	void Start ()
	{
		player_state = PlayerState.MenuIdle;
		menu_state = MenuState.MainMenu;

		//player_state = PlayerState.Playing;
	}

	void Update ()
	{
		switch ( menu_state )
		{
			case MenuState.MainMenu:
				break;
			case MenuState.InGame:
				break;
			case MenuState.EndScreen:
				break;
			default:
				break;
		}

		switch ( player_state )
		{
			case PlayerState.MenuIdle:
				PlayerRotation();
				menu_Player();
				break;
			case PlayerState.Playing:
				menu_state = MenuState.InGame;
				PlayerRotation();
				break;
			case PlayerState.HitObstacle:
				break;
			case PlayerState.HitGround:
				break;
			case PlayerState.GroundIdle:
				break;
			default:
				break;
		}
	}


	private void OnMouseDown()
	{
		print(player_state);
		if ( player_state == PlayerState.Playing && Player.transform.position.y < 6.3f )
		{
			rotate.z = 35;
			Player.velocity = new Vector2( 0, JumpHeight );
		}
		else if(player_state==PlayerState.MenuIdle)
		{
			player_state = PlayerState.Playing;
			rotate.z = 35;
			Player.velocity = new Vector2( 0, JumpHeight );
		}
	}

	void StartScreenFunc()
	{
		MainScreen.SetActive( true );
		InGScreen.SetActive( false );
		EndGScreenTop.SetActive( false );
		EndGScreenBottom.SetActive( false );
	}
	void InGameScreenFunc()
	{
		MainScreen.SetActive( false );
		InGScreen.SetActive( true );
		EndGScreenTop.SetActive( false );
		EndGScreenBottom.SetActive( false );
	}
	void EndScreenFunc()
	{
		MainScreen.SetActive( false );
		InGScreen.SetActive( false );
		EndGScreenTop.SetActive( true );
		EndGScreenBottom.SetActive( true );
	}


	//메뉴 표시 상태에서 자동 tap 콘트롤 효과
	void menu_Player()
	{
		if ( Player.transform.position.y < 1 )
		{
			rotate.z = 35;
			Player.velocity = new Vector2( 0, JumpHeight );
		}
	}

	void PlayerRotation()
	{
		//player rotation
		Player.velocity = Vector2.Lerp( Player.velocity, new Vector2( 0, velo ), Time.deltaTime );
		rotate.z = Mathf.Lerp( rotate.z, -90, Time.deltaTime * 1.5f );
		Player.transform.rotation = Quaternion.Euler( rotate );
		velo = 3;
	}
}
