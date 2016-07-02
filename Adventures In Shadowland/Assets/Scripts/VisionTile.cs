using UnityEngine;
using System.Collections;

public class VisionTile : MonoBehaviour{

	public GameObject visionTile;
	public bool visable;

	public VisionTile(GameObject _visionTile, bool _visable)
	{
		this.visionTile = _visionTile;
		this.visable = _visable;
	}

}
