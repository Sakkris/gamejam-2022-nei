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
	private int score_per_enemy = 20000;

	void Awake()
	{
        if (instance == null)

            instance = this;

        else if (instance != this)

            Destroy(gameObject);	
		
		DontDestroyOnLoad(gameObject);

		InitGame();
	}

	void InitGame()
	{
		score = 0;
		InvokeRepeating("Spawn_Enemies", 5.0f, 10f);
	}

	private void Update()
	{
		score = (int)(Time.deltaTime * score_per_second);
	}

	public void enemyDeath()
	{
		score += score_per_enemy;
	}

	private void Spawn_Enemies()
	{
		Instantiate(enemy, new Vector2(Random.Range(Min.position.x, Max.position.x), Random.Range(Min.position.y, Max.position.y)), Quaternion.identity);
	}
}

