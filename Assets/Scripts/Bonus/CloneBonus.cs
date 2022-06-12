using UnityEngine;

public class CloneBonus : Bonus
{
    public override void Apply()
    {
        base.Apply();
        BallCreator ballCreator = GetComponentInParent<BallCreator>();
        if (ballCreator != null)
        {
            ballCreator.CreateClone();
        }
        Destroy(gameObject);
    }
}
