using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity : MonoBehaviour {
    List<EntityComponent> components;

    public Entity() {
        this.components = new List<EntityComponent>();
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void addComponent(EntityComponent comp) {
        this.components.Add(comp);
    }

    void removeComponent(EntityComponent comp) {
        this.components.Remove(comp);
    }

    List<EntityComponent> getComponents() {
        return components;
    }
}
