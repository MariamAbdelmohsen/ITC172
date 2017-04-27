using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void FirstNametextBox_TextChanged(object sender, EventArgs e)
    {

    }

    protected void RegisterButton_Click(object sender, EventArgs e)
    {
        string first = FirstNametextBox.Text;
        string last = LastNameTextBox.Text;
        string email = EmailTextBox.Text;
        string password = PasswordTextBox.Text;

        Community_AssistEntities db = new Community_AssistEntities();
        int result = db.asp_NewUser(first, last, email, password);
        if( result != -1)
        {
            Response.Redirect("Default.aspx");

        }
        else
        {
            ErrorLable.Text ="Please Resgister First "
        }
    }
}