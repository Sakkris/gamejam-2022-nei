using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Manager : MonoBehaviour
{
	public static Manager instance = null;
	public GameObject enemy;
	public Transform Min;
	public Transform Max;
	public int score = 0;

	private int score_per_second = 500;
	private int score_per_enemy = 2000;
	private int numberSpawns = 2;

	void Awake()
	{
        if (instance == null)

            instance = this;

        else if (instance != this)

            Destroy(gameObject);	

		InitGame();
	}

	void InitGame()
	{
		score = 0;
		InvokeRepeating("Spawn_Enemies", 0.0f, 7.5f);

	}

	private void Update()
	{
		score += (int)(Time.deltaTime * score_per_second);
	}

	public void enemyDeath()
	{
		score += score_per_enemy;
	}

	private void Spawn_Enemies()
	{
		for (int i = 0; i < Mathf.Log(numberSpawns); i++) {
			bool found = true;
			Vector2 spawnPosition = new Vector2(0, 0);

			while (found)
			{
				found = false;
				spawnPosition = new Vector2(Random.Range(Min.position.x, Max.position.x), Random.Range(Min.position.y, Max.position.y));

				foreach (Collider2D nearbyObject in Physics2D.OverlapCircleAll(spawnPosition, 0.5f))
				{
					if (nearbyObject.gameObject.CompareTag("Player"))
					{
						found = true;
					}
				}

			}

			Instantiate(enemy, spawnPosition, Quaternion.identity);
		}
		numberSpawns++;
	}
	
}

