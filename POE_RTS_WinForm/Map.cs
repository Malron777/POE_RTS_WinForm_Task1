using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POE_RTS_WinForm
{
  public class Map
  {
    private char blankSpaceCharacter = 'o';
    private char rangedUnitCharacter = 'R';
    private char meleeUnitCharacter = 'M';

    public static int gridSize = 20;
    private int numberOfUnits;
    public List<Unit> units;
    private Random rand;
    public Unit[,] Battlefield;

    private char[,] map;

    public Map(int aNumberOfUnits)
    {
      this.numberOfUnits = aNumberOfUnits;
      units = new List<Unit>();
      rand = new Random();
      map = new char[gridSize, gridSize];
    }

    public void GenerateUnits()
    {
      Battlefield = new Unit[gridSize, gridSize];

      for (int i = 0; i < numberOfUnits; i++)
      {
        Unit unit = SpawnUnit();
        units.Add(unit);
      }
    }

    private Unit SpawnUnit()
    {
      int xPos;
      int yPos;

      bool posFound = false;
      do
      {
        xPos = rand.Next(0, gridSize);
        yPos = rand.Next(0, gridSize);
        if (Battlefield[xPos, yPos] == null)
        {
          posFound = true;
        }
      }
      while (!posFound);

      return GenerateRandomUnit(xPos, yPos);
    }

    private Unit GenerateRandomUnit(int xPos, int yPos)
    {
      int whichUnit = rand.Next(0, 2);
      int speed = rand.Next(1, 4);

      Unit unit;
      if (whichUnit == 0)
      { //spawn a ranged unit
        unit = new RangedUnit(xPos, yPos, 6, speed, 1, 3, "Horde", 'H');
      }
      else
      { //spawn a melee unit
        unit = new MeleeUnit(xPos, yPos, 10, speed, 2, "Alliance", 'A');
      }
      return unit;
    }

    public void PopulateMap()
    {
      int index = 0;
      while (index < units.Count)
      {
        if (units[index].isDead)
        {
          units.Remove(units[index]);
        }
        else
        {
          index++;
        }
      }

      foreach (Unit unit in units)
      {
        if (unit is RangedUnit)
        {
          RangedUnit lUnit = unit as RangedUnit;
          Battlefield[lUnit.xPos, lUnit.yPos] = lUnit;
        }
        if (unit is MeleeUnit)
        {
          MeleeUnit lUnit = unit as MeleeUnit;
          Battlefield[lUnit.xPos, lUnit.yPos] = lUnit;

        }
      }
    }

    public void UpdateDisplay()
    {
      for (int i = 0; i < gridSize; i++)
      {
        for (int j = 0; j < gridSize; j++)
        {
          map[i, j] = blankSpaceCharacter;
        }
      }

      foreach (Unit unit in units)
      {
        if (unit is RangedUnit)
        {
          RangedUnit lUnit = unit as RangedUnit;
          map[lUnit.xPos, lUnit.yPos] = lUnit.Symbol;
        }
        if (unit is MeleeUnit)
        {
          MeleeUnit lUnit = unit as MeleeUnit;
        map[lUnit.xPos, lUnit.yPos] = lUnit.Symbol;
        }
      }
    }

    public void UpdateUnitPosition(Unit aUnit, int aNewXPosition, int aNewYPosition)
    {
      if (aUnit is RangedUnit)
      {
        RangedUnit lUnit = aUnit as RangedUnit;
        lUnit.xPos = aNewXPosition;
        lUnit.yPos = aNewYPosition;
      }
      if (aUnit is MeleeUnit)
      {
        MeleeUnit lUnit = aUnit as MeleeUnit;
        lUnit.xPos = aNewXPosition;
        lUnit.yPos = aNewYPosition;
      }
    }

    public string PrintMap()
    {
      string text = "";

      for (int i = 0; i < gridSize; i++)
      {
        for (int j = 0; j < gridSize; j++)
        {
          text += map[i, j].ToString() + " ";
        }
        text += Environment.NewLine;
      }
      return text;
    }
  }
}
