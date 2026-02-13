using System;
using Blocks;
using UnityEngine;
using Upgrades;

public class Drill : LevelableEntity
{
    [SerializeField] private float _speed;
    
    public void OnContact(Block block)
    {
        block.TakeDamage(_speed);

        if (block != null) //TODO AddForce, откинуть назад если не смог сломать
        {
            Debug.Log("Block Hit");
        }
        else
        {
            Debug.Log("Block die");
        }
    }

    public void UpgradeSpeed(int speed)
    {
        if (speed < 0)
            throw new ArgumentOutOfRangeException(nameof(speed), speed, $"{nameof(speed)} cannot be negative");
        
        _speed = speed;
        base.Upgrade(speed);
    }

    // public override void Upgrade() //TODO DrillScaler для своего lvl
    // {
    //     base.Upgrade();
    // }
}