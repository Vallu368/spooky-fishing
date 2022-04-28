using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class markoscript : MonoBehaviour
{
	[SerializeField] GameObject themHands;
	[SerializeField] GameObject skin;
	[SerializeField] AudioClip markoGotU;

	private bool isPlayerAlive = true;
	public CameraMovement cam;
	public GameObject Marko;
	lightF playerLight;
	public GameObject gameOverScreen;
	public FishScript fishScript;
	private GameOver gameOverScript;
	public GameObject gameOverCanvas;

	public bool leftSide = false;
	public bool rightSide = false;
	public bool front = false;
	public bool backRight = false;
	public bool backLeft = false;

	private int nextUpdate = 1;

	public bool playerNoticed = false;

	public int timer = 0;

	void Start()
	{
		gameOverScript = gameOverCanvas.GetComponent<GameOver>();
		playerLight = GameObject.FindGameObjectWithTag("PlayerLight").GetComponent<lightF>(); //Find player light's script on Start to detect if flashlight is on
	}


	void Update()
	{
		if (!GlobalGameState.instance.isGameOver)
		{


			if (leftSide) //jos pit�� katsoa vasemmalle
			{
				LookLeft();
			}
			else if (rightSide) //pit�� kattoo oikeelle
			{
				LookRight();
			}
			else if (front) //pit�� kattoo eteen
			{
				LookForward();
			}
			else if (backLeft) //takavasen
			{
				LookBackLeft();
			}
			else if (backRight) //takaoikee
			{
				LookBackRight();
			}


			if (Time.time >= nextUpdate)
			{

				nextUpdate = Mathf.FloorToInt(Time.time) + 1;
				UpdateEverySecond();
			}
		}
	}

	private void UpdateEverySecond()
	{
		if (playerLight.flashlightActive)
        {
			timer++;
        }
		if (timer >= 10)
        {
			StartCoroutine(PlayerDies());
        }
		
	}

	IEnumerator PlayerDies()
	{
		if (isPlayerAlive)
		{
			SFX.instance.PlayClip(markoGotU, 1f);
			skin.SetActive(false);
			themHands.SetActive(true);
			isPlayerAlive = false;
			yield return new WaitForSeconds(0.95f);
			gameOverScript.GameEnded();
			gameOverScreen.SetActive(true);
			GameObject.Find("Player").GetComponentInChildren<InventoryManager>().enabled = false;
			GameObject.Find("Canvas").GetComponent<Pause>().enabled = false;
			if (GlobalGameState.instance.progression == 1)
            {
				GlobalGameState.instance.totalFishCaught = fishScript.totalFishForCheckpoint1;
			}
			if (GlobalGameState.instance.progression == 2) {
				GlobalGameState.instance.totalFishCaught = fishScript.totalFishForCheckpoint2;
            }
		}

	}

	private void FadeOut()
	{
		Debug.Log("he ded");
		Destroy(gameObject);
	}

	private void LookLeft()
	{
		
		if (cam.lookLeft)
		{
			playerNoticed = true;       //pelaaja huomattu
		}

		if (playerNoticed && cam.lookLeft && cam.time == 2)         //jos pelaaja on huomattu ja katotaan monsteria p�in 2sek niin kuollaan
		{
			StartCoroutine(PlayerDies());
		}

		if (!cam.lookLeft && !playerLight.flashlightActive && cam.time == 5) //Timer removed
					//jos k��ntyy pois monsterista ja valot on pois p��lt� pari sekkaa niin monsteri katoaa
		{
			FadeOut();
		}
	}

	private void LookRight()
	{
		if (cam.lookRight)
		{
			playerNoticed = true;
		}

		if (playerNoticed && cam.lookRight && cam.time == 2)
		{
			StartCoroutine(PlayerDies());
		}

		if (!cam.lookRight && !playerLight.flashlightActive && cam.time == 5) //Timer removed
		
		{
			FadeOut();
		}
	}

	private void LookForward()
	{
		if (cam.lookForward)
		{
			playerNoticed = true;
		}

		if (playerNoticed && cam.lookForward && cam.time == 2)
		{
			StartCoroutine(PlayerDies());
		}

		if (!cam.lookForward && !playerLight.flashlightActive && cam.time == 5) //Timer removed
		
		{
			FadeOut();
		}
	}

	private void LookBackLeft()
	{
		if (cam.lookBackLeft)
		{
			playerNoticed = true;
		}

		if (playerNoticed && cam.lookBackLeft && cam.time == 2)
		{
			StartCoroutine(PlayerDies());
		}

		if (!cam.lookBackLeft && !playerLight.flashlightActive && cam.time == 5) //Timer removed
		
		{
			FadeOut();
		}
	}

	private void LookBackRight()
	{
		if (cam.lookBackRight)
		{
			playerNoticed = true;
		}

		if (playerNoticed && cam.lookBackRight && cam.time == 2)
		{
			StartCoroutine(PlayerDies());
		}

		if (!cam.lookBackRight && !playerLight.flashlightActive && cam.time == 5) //Timer removed
		
		{
			FadeOut();
		}
	}

	public void WhichSide(string tag)
	{
		Debug.Log(tag);

		if (tag == "leftSide")
		{
			leftSide = true;
		} else if (tag == "rightSide")
		{
			rightSide = true;
		} else if (tag == "forward")
		{
			front = true;
		} else if (tag == "backLeft")
		{
			backLeft = true;
		} else if (tag == "backRight")
		{
			backRight = true;
		}
	}

}
