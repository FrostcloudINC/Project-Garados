using System;
using UnityEngine;
using System.Collections;

public class Enemy : Entity{
    Health health;

    void Start () {
        init();
    }

    public new void init() {
        base.init();
        this.addComponent(health = new Health(3));
        //health.initHealthBar(this.gameObject, new EnemyHB());
    }

    public new void update() {
        base.update();
        attack(GameObject.Find("TestLogicPlayer").GetComponent<Entity>());
    }

    void Update () {
        update();
    }

    //TODO This method should be deleted when starting to make attack logic. This should be connected to it's own component
    //This is just to test the Health system
    void attack(Entity ent) {
        if (ent.hasComponentOfType("Health")){
            Health targetHealth = (Health)ent.getComponentOfType("Health");
            if(targetHealth.getHealth() > 0) {
                targetHealth.receiveDamage(1);
            }
        }
    }
}
