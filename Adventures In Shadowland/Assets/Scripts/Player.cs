using UnityEngine;
using System.Collections;

public class Player : Entity{
    Health health;
	Combat combat;

    void Start() {
        init();
    }

    public new void init() {
        base.init();
        this.addComponent(health = new Health(3));
        health.initHealthBar(this.gameObject, new PlayerHB());
		combat.initCombat(this.gameObject);
    }
}
