using UnityEngine;
using System.Collections;

public class Combat : EntityComponent {

	CombatBehaviour currentCombatBehaviour;
	GameObject parent;
	Entity target;
	int castingLayerMask;

	public Combat(CombatBehaviour _currentCombatBehaviour)
	{
		this.currentCombatBehaviour = _currentCombatBehaviour;

	}

	public void initCombat(GameObject obj)
	{
		this.parent = obj;
	}

	public CombatBehaviour getCurrentCombatBehaviour()
	{
		return currentCombatBehaviour;
	}

	public void setCurrentCombatBehaviour(CombatBehaviour targetCombatBehaviour)
	{
		this.currentCombatBehaviour = targetCombatBehaviour;
	}

	public Entity getTarget()
	{
		return target;
	}

	public void setTarget(Entity _target)
	{
		this.target = _target;
		castingLayerMask = 1 << LayerMask.NameToLayer(target.gameObject.name);
		castingLayerMask = ~castingLayerMask;
	}

	public bool isInRange()
	{
		bool inRange = false;
		Vector2 parentPosition = new Vector2(parent.transform.position.x,parent.transform.position.y);

        RaycastHit2D hit = new RaycastHit2D();
		if(
		Physics2D.Linecast(parentPosition, new Vector2(parentPosition.x + 1, parentPosition.y),castingLayerMask) ||
		Physics2D.Linecast(parentPosition, new Vector2(parentPosition.x - 1, parentPosition.y),castingLayerMask) ||
		Physics2D.Linecast(parentPosition, new Vector2(parentPosition.x, parentPosition.y + 1),castingLayerMask) ||
		Physics2D.Linecast(parentPosition, new Vector2(parentPosition.x, parentPosition.y - 1),castingLayerMask) ||
		Physics2D.Linecast(parentPosition, new Vector2(parentPosition.x - 1, parentPosition.y - 1),castingLayerMask) ||
		Physics2D.Linecast(parentPosition, new Vector2(parentPosition.x + 1, parentPosition.y - 1),castingLayerMask) ||
		Physics2D.Linecast(parentPosition, new Vector2(parentPosition.x - 1, parentPosition.y + 1),castingLayerMask) ||
		Physics2D.Linecast(parentPosition, new Vector2(parentPosition.x + 1, parentPosition.y + 1),castingLayerMask)
		)
		{
            if (hit.collider.gameObject.GetComponent<Entity>() == target) {
                inRange = true;
            } 
            else {
                inRange = false;
            }
		}

		return inRange;
	}

	override public void update() {}
}
