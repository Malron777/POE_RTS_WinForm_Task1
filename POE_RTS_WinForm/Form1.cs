using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POE_RTS_WinForm
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }
    public GameEngine GE;

    private int numberOfUnits = 12;
    //private float waitTime = 1;
    //private float timeElapsed = 0;
    //private bool isPaused = true;

    private void btnStart_Click(object sender, EventArgs e)
    {
      if (GE == null)
      {
        GE = new GameEngine(numberOfUnits);
        GE.StartGame();
      }

      timer1.Enabled = true;
    }

    private void time1_Tick(object sender, EventArgs e)
    {
      if ((GE.map.units.Count > 1))
      {
        GE.StartNewRound();
        rtbMap.Text = GE.map.PrintMap();
        lblRoundCount.Text = $"Round: {GE.roundsCompleted}";

        UpdateUnitInfo();
      }      
    }

    private void UpdateUnitInfo()
    {
      rtbUnitInfo.Text = "";
      foreach (var unit in GE.map.units)
      {
        rtbUnitInfo.Text += $"{unit.ToString()}{Environment.NewLine}";
      }
    }

    private void btnPause_Click(object sender, EventArgs e)
    {
      timer1.Enabled = false;
    }
  }
}
