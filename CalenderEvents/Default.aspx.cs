using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        Label1.Text = "";
        string[,] events = new string[8, 2];

        events[0, 0] = "6/7/2017";
        events[0, 1] = "Happy Birthday!";
        events[1, 0] = "4/16/2017";
        events[1, 1] = "Easter Sunday! Eat lots of chocolate!";
        events[2, 0] = "5/29/2017";
        events[2, 1] = "Memorial Day.";
        events[3, 0] = "6/18/2017";
        events[3, 1] = "Father's Day";
        events[4, 0] = "6/18/2017";
        events[4, 1] = "Sunday Funday";
        events[5, 0] = "7/4/2017";
        events[5, 1] = "Independence Day";
        events[6, 0] = "7/8/2017";
        events[6, 1] = "Dirty Heads Show!";
        events[7, 0] = "6/20/2017";
        events[7, 1] = "Welcome Summer Season!";

        string Dates = Calendar1.SelectedDate.ToShortDateString();

        for (int i = 0; i < 8; i++)
        {

            if (Dates.Equals(events[i, 0]))
            {
                Label1.Text += events[i, 1] + "<br/>";
            }

        }

        if (Label1.Text == "") Label1.Text = Dates;

    }
}