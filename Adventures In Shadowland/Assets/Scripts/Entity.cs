using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Entity : MonoBehaviour {
    List<EntityComponent> components;

	// Use this for initialization
	void Start () {
        init();
    }

    public void init() {
        this.components = new List<EntityComponent>();
    }
	
    public void update() {
        foreach (EntityComponent comp in this.components) {
            comp.update();
        }
    }

	// Update is called once per frame
	void Update () {
        update();
	}

    public void addComponent(EntityComponent comp) {
        if(comp == null) {
            Debug.LogError("The component that was gonna be added was equal to null");
            return;
        }
        this.components.Add(comp);
    }

    public void removeComponent(EntityComponent comp) {
        this.components.Remove(comp);
    }

    public List<EntityComponent> getComponents() {
        return components;
    }

    public bool hasComponentOfType(string type) {
        Type t = Type.GetType(type);
        if(t == null) {
            Debug.LogWarning("No such type:" + type);
            return false;
        }
        foreach(EntityComponent comp in components) {
            if (comp.GetType().Equals(t)) {
                return true;
            }
        }
        Debug.LogWarning("Did NOT find component of type:" + t.Name + " | in gameobject:" + this.gameObject);
        return false;
    }

    public EntityComponent getComponentOfType(string type) {
        Type t = Type.GetType(type);
        if (t == null) {
            Debug.LogWarning("No such type:" + type);
            return null;
        }
        foreach (EntityComponent comp in components) {
            if (comp.GetType().Equals(t)) {
                return comp;
            }
        }
        Debug.LogWarning("Did NOT find component of type:" + t.Name + " | in gameobject:" + this.gameObject);
        return null;
    }
}
