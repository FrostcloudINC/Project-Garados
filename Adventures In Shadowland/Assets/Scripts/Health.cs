using UnityEngine;
using System.Collections;

public class Health : EntityComponent {
    int maxHealth;
    int health;
    GameObject parent;

    public Health() {
        health = maxHealth;
    }

    public Health(int maxHealth) {
        this.maxHealth = maxHealth;
        health = maxHealth;
    }

    public void initHealthBar(GameObject obj) {
        this.parent = obj;
        //TODO add healthbar to object
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
    }

    public void recoverHealth(int increasement) {
        this.increaseHealth(increasement);
    }

    public void onNoHealth() {
        //TODO make this function
    }

    override public void update() {}
}
