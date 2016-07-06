using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerHB : HealthBar {
    readonly int StartX = -50;
    readonly int StartY = -20;
    readonly int HeartWidth = 40;
    readonly int HeartHeight = 40;
    Canvas canvas;

    public override void init(Health h) {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        int x = StartX;
        int y = StartY;
        for (int i = 0; i < h.getHealth(); i++) {
            GameObject heart = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Heart_full"));
            heart.transform.SetParent(GameObject.Find("Canvas").transform);
            RectTransform transform = heart.GetComponent<RectTransform>();
            transform.anchoredPosition3D = new Vector3(x, y);
            transform.sizeDelta = new Vector2(HeartWidth, HeartHeight);
            transform.localScale = new Vector3(1, 1, 1);
            x -= HeartWidth;
        }
    }

    public override void update(Health h) {
        //TODO Update healthbar
    }
}
