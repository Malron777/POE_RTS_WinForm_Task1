using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_RTS_WinForm
{
  public class GameEngine
  {
    public GameEngine(int aNumberOfUnits)
    {
      map = new Map(aNumberOfUnits);
      rand = new Random();
    }

    private Random rand;
    public Map map;

    public int roundsCompleted = 0;

    public void StartGame()
    {
      map.GenerateUnits();
      map.PopulateMap();
      map.UpdateDisplay();
    }

    public void StartNewRound()
    {
      for (int i = 0; i < map.units.Count; i++)
      {
        PerformAction(map.units[i]);
      }

      map.PopulateMap();
      map.UpdateDisplay();

      roundsCompleted++;
    }

    private void PerformAction(Unit aUnit)
    {
      if (aUnit is RangedUnit)
      {
        RangedUnit lUnit = aUnit as RangedUnit;
        Unit closestEnemy = lUnit.FindClosestEnemy(map.Battlefield);

        if (closestEnemy != null && lUnit.Health >= 0.25 * lUnit.MaxHealth)
        {
          if (lUnit.RangeCheck(closestEnemy))
          {
            lUnit.EngageUnit(closestEnemy);
            lUnit.IsAttacking = true;
          }
          else if (roundsCompleted % lUnit.Speed == 0)
          {
            if (closestEnemy is IPosition)
            { //Move toward the enemy
              var lTarget = closestEnemy as IPosition;
              int differenceInXPosition = Math.Abs(lUnit.xPos - lTarget.xPos);
              int differenceInYPosition = Math.Abs(lUnit.yPos - lTarget.yPos);
              if (differenceInXPosition > differenceInYPosition)
              { //Move vertical
                if (lUnit.yPos <= lTarget.yPos)
                {
                  lUnit.Move(Unit.Direction.Up);
                }
                else if (lUnit.yPos > lTarget.yPos)
                {
                  lUnit.Move(Unit.Direction.Down);
                }
              }
              else if (differenceInXPosition > differenceInYPosition)
              { //Move horizontal
                if (lUnit.xPos <= lTarget.xPos)
                {
                  lUnit.Move(Unit.Direction.Right);
                }
                else if (lUnit.xPos > lTarget.xPos)
                {
                  lUnit.Move(Unit.Direction.Left);
                }
              }
              else
              {
                lUnit.Move(Unit.Direction.Up);
              }
            }
          }
          else if (lUnit.Health < 0.25 * lUnit.MaxHealth)
          {
            lUnit.Move(RandomDirection());
          }
        }
      }
      if (aUnit is MeleeUnit)
      {
        MeleeUnit lUnit = aUnit as MeleeUnit;
        Unit closestEnemy = lUnit.FindClosestEnemy(map.Battlefield);


        if (closestEnemy != null && lUnit.Health >= 0.25 * lUnit.MaxHealth)
        {
          if (lUnit.RangeCheck(closestEnemy))
          {
            lUnit.EngageUnit(closestEnemy);
            lUnit.IsAttacking = true;
          }
          else if (roundsCompleted % lUnit.Speed == 0)
          {
            if (closestEnemy is IPosition)
            { //Move toward the enemy
              var lTarget = closestEnemy as IPosition;
              int differenceInXPosition = Math.Abs(lUnit.xPos - lTarget.xPos);
              int differenceInYPosition = Math.Abs(lUnit.yPos - lTarget.yPos);
              if (differenceInXPosition > differenceInYPosition)
              { //Move vertical
                if (lUnit.yPos <= lTarget.yPos)
                {
                  lUnit.Move(Unit.Direction.Up);
                }
                else if (lUnit.yPos > lTarget.yPos)
                {
                  lUnit.Move(Unit.Direction.Down);
                }
              }
              else if (differenceInXPosition > differenceInYPosition)
              { //Move horizontal
                if (lUnit.xPos <= lTarget.xPos)
                {
                  lUnit.Move(Unit.Direction.Right);
                }
                else if (lUnit.xPos > lTarget.xPos)
                {
                  lUnit.Move(Unit.Direction.Left);
                }
              }
              else
              {
                lUnit.Move(Unit.Direction.Up);
              }
            }
          }
        }
        else if (lUnit.Health < 0.25 * lUnit.MaxHealth)
        {
          lUnit.Move(RandomDirection());
        }
      }
    }

    private Unit.Direction RandomDirection()
    {
      int r = rand.Next(0, 4);
      switch (r)
      {
        case 0:
          return Unit.Direction.Up;
        case 1:
          return Unit.Direction.Down;
        case 2:
          return Unit.Direction.Left;
        case 3:
          return Unit.Direction.Right;
        default:
          return Unit.Direction.Up;
      }
    }
  }
}
