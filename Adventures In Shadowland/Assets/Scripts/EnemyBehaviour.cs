using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	GameObject player;
	public int visionRadius = 3;
	VisionTile[,] VisionArray;
	Vector2 originPoint;

	void Start () {
		VisionArray = new VisionTile[visionRadius,visionRadius];
		player = GameObject.FindGameObjectWithTag("Player");

		originPoint = new Vector2(this.transform.FindChild("VisionTile").transform.position.x - visionRadius%3, this.transform.FindChild("VisionTile").transform.position.y + visionRadius%3);
		updateVision();
	}

	void Update () {
		Target ();
	}

	void updateVision()
	{
		for(int x=0; x < visionRadius; x++)
		{
			for(int y=0; y < visionRadius; y++)
			{
				Debug.Log (x + " " + y);
				VisionArray[x,y] = new VisionTile((GameObject) Instantiate(this.transform.FindChild("VisionTile").gameObject, new Vector3(originPoint.x + x, originPoint.y - y, 0), Quaternion.identity), true);
				VisionArray[x,y].visionTile.SetActive(true);
				VisionArray[x,y].visable = VisionArray[x,y].visionTile.GetComponent<BoxCollider2D>().IsTouchingLayers(1<<8)?false:true;
			}
		}
	}

	void Target()
	{
		foreach (VisionTile tile in VisionArray)
		{
			if(tile.visionTile.GetComponent<BoxCollider2D>().IsTouchingLayers(1<<9) && tile.visable)
			{
				this.gameObject.GetComponent<AILerp>().canSearch = true;
			}
		}
	}
}
