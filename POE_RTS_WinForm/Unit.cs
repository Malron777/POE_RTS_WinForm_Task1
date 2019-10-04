using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POE_RTS_WinForm
{
  public abstract class Unit
  {
    public Unit(int aPositionX, int aPositionY, int aHealth, int aSpeed, int aAttack, string aFaction, char aSymbol)
    {
    }

    public enum Direction { Up, Down, Left, Right};
    protected int xPosition;
    protected int yPosition;

    protected int maxHealth;
    protected int health;

    protected int speed;

    protected int attack;
    protected int attackRange;

    protected string faction;
    protected char symbol;

    protected bool isAttacking;

    public bool isDead = false;


    public abstract void Move(Direction direction);

    public abstract void EngageUnit(Unit aTarget);

    public abstract bool RangeCheck(Unit aTarget);

    public abstract Unit FindClosestEnemy(Unit[,] aFieldToCheck);

    public abstract void DamageUnit(int aAttack);

    public abstract void KillUnit();

    public abstract override string ToString();
  }
}
