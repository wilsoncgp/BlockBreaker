using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	private string breakableTagName = "Breakable";
	private LevelManager levelManager;
	private int timesHit;
	private bool isBreakable;

	// Use this for initialization
	void Start ()
	{
		isBreakable = this.tag == breakableTagName;
		if(isBreakable)
		{
			breakableCount++;
		}
		
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
		print (string.Format("Brick {0} created", breakableCount));
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		AudioSource.PlayClipAtPoint(crack, transform.position, 0.1f);
		if(isBreakable)
		{
			HandleHits();
		}
	}
	
	void HandleHits()
	{
		timesHit++;
		
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits)
		{
			breakableCount--;
			levelManager.BrickDestroyed();
			Destroy(this.gameObject);
		}
		else
		{
			LoadSprites();
		}
	}
	
	void PuffSmoke()
	{
		GameObject smokePuff = Instantiate(smoke, this.transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites()
	{
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex] != null)
		{
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else
		{
			Debug.LogError("Brick sprite missing at index: " + spriteIndex);
		}
	}
}
