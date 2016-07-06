using UnityEngine;
using System.Collections;

public abstract class Healthbar{
    public Texture2D[] textures;

    public abstract void init(Health h);
    public abstract void update(Health h);
}
