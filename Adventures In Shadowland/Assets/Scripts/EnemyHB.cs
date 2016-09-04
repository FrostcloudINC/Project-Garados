using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class EnemyHB : HealthBar {
    readonly int BarWidth = 50;
    readonly int BarHeight = 10;
    readonly float hoverAdjustment = 0.75f;

    Canvas canvas;
    static GameObject barPrefab = null;
    GameObject bar = null;

    public override void init(Health h) {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        RectTransform transform = null;
        if (barPrefab == null) {
            barPrefab = new GameObject("EnemyHealthBar");
            transform = barPrefab.AddComponent<RectTransform>();
            barPrefab.AddComponent<CanvasRenderer>();
            Image image = barPrefab.AddComponent<Image>();

            barPrefab.transform.SetParent(canvas.transform);
            image.color = new Color(255, 0, 0);
            transform.sizeDelta = new Vector2(BarWidth, BarHeight);
            transform.localPosition = new Vector3(0, 0, -600);
        }

        bar = GameObject.Instantiate(barPrefab);
        bar.transform.SetParent(canvas.transform);
        transform = bar.GetComponent<RectTransform>();
        Debug.Log(h.getParent());
        Debug.Log(h.getParent().transform.position);

        transform.anchorMin = new Vector2(0,0);
        transform.anchorMax = new Vector2(0,0);
        transform.anchoredPosition = WorldPointToCanvasPoint(new Vector2(h.getParent().transform.position.x, h.getParent().transform.position.y + hoverAdjustment));

        transform.localPosition =  new Vector2(transform.localPosition.x, transform.localPosition.y);
        transform.localScale = new Vector3(1, 1, 1);
        Debug.Log("Instansiated");
    }

    public Vector3 WorldPointToCanvasPoint(Vector3 worldPoint) {
        Vector3 viewPoint = Camera.main.WorldToViewportPoint(worldPoint); //viewPoint ranges from 0,0 to 1,1 where 0,0 is the lower left corner and 1,1 is the upper right corner
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        Vector3 canvasPoint = new Vector3(viewPoint.x * canvasRect.sizeDelta.x, viewPoint.y * canvasRect.sizeDelta.y,0);
        return canvasPoint;
    }

    public override void update(Health h) {
        RectTransform transform = bar.GetComponent<RectTransform>();
        transform.anchoredPosition = WorldPointToCanvasPoint(new Vector2(h.getParent().transform.position.x, h.getParent().transform.position.y + hoverAdjustment));
    }
}