using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiShootBehaviour : AIBehaviour
{
    public float fieldOfVisionForShooting = 60;

    public override void PerformAction(TankController tank, AIDetector detector)
    {
        if (TargetInFOV(tank, detector))
        {
            tank.HandleMoveBody(Vector2.zero);
            tank.HandleShoot();
        }
            
        tank.HandleTurretMovement(detector.Target.position);
    }

    private bool TargetInFOV(TankController tank, AIDetector detector)
    {
        var direction = detector.Target.position - tank.aimTurret.transform.position;
        if (Vector2.Angle(tank.aimTurret.transform.right, direction) < fieldOfVisionForShooting / 2)
        {
            return true;
        }
        return false;
    }
}
