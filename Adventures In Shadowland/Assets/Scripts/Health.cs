using UnityEngine;
using System.Collections;

public class Health : EntityComponent {
    int maxHealth;
    int health;
    GameObject parent;
    HealthBar bar;

    public Health(int maxHealth) {
        this.maxHealth = maxHealth;
        health = maxHealth;
    }

    public void initHealthBar(GameObject obj, HealthBar bar) {
        this.parent = obj;
        this.bar = bar;
        bar.init(this);
        Debug.Log("Healthbar intialized for gameObject:" + obj.name);
        //TODO add healthbar to object
    }

    public void updateHealthBar(GameObject obj) {
        bar.update(this);
        //TODO update healthbar to object
    }

    private void increaseHealth(int increasement) {
        this.health += increasement;
    }

    private void decreaseHealth(int decreasement) {
        this.health -= decreasement;
    }

    private void setHealth(int health) {
        this.health = health;
    }

    public int getHealth() {
        return this.health;
    }

    public void increaseMaxHealth(int increasement) {
        this.maxHealth += increasement;
    }

    public void decreaseMaxHealth(int decreasement) {
        this.maxHealth -= decreasement;
    }

    private void setMaxHealth(int maxHealth) {
        this.maxHealth = maxHealth;
    }

    public int getMaxHealth() {
        return maxHealth;
    }

    public void receiveDamage(int damage) {
        this.decreaseHealth(damage);
        if(this.getHealth() <= 0) {
            this.onNoHealth();
        }
        Debug.Log("gameobject:" + parent + " received " + damage + " damage" + " | current health:" + health);
    }

    public void recoverHealth(int increasement) {
        this.increaseHealth(increasement);
    }

    public void onNoHealth() {
        Debug.Log(parent + " is now dead");
        //TODO do more when dying
    }

    public GameObject getParent() {
        return this.parent;
    }

    override public void update() {
        updateHealthBar(parent);
    }
}
