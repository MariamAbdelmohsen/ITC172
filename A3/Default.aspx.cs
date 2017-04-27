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

    protected void LogInButton_Click(object sender, EventArgs e)
    {
        int key = 0;
        Community_AssistEntities db = new Community_AssistEntities();
        int success = db.usp_Login(UserTextBox.Text, passwordTextBox.Text);
        if (success != -1)
        {
            var ukey = (from k in db.People
                        where k.PersonEmail.Equals(UserTextBox.Text)
                        select k.PersonKey).FirstOrDefault();

            key = (int)ukey;
            Session["PersonKey"] = key;
            Response.Redirect("donation.aspx");

        }else
        {
            Response.Redirect("Register.aspx");
        }

    }
}