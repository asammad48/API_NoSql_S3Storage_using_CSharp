using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Program_5
{
    public partial class LoginStudent : System.Web.UI.Page
    {
        private static AmazonDynamoDBClient client = new AmazonDynamoDBClient();

        static List<Location> locations = new List<Location>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string ipAddress = string.Empty;// Agai All code of IPINFODB explain with Comment in AddStudent.aspx.cs

            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                ipAddress = HttpContext.Current.Request.UserHostAddress;
            }
            string APIKey = "7ad2b709fbd352f8cdc825f496aea90c9dbe8991d0729a918c839b50e71d71b4";
            string url = string.Format("http://api.ipinfodb.com/v3/ip-city/?key={0}&ip={1}&format=json", APIKey, ipAddress);
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                Location location = new JavaScriptSerializer().Deserialize<Location>(json);
                locations.Add(location);
                

            }
        }

        protected void btnLoginStudent_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('Name')</script>");
            var credentials = new BasicAWSCredentials("AKIAJDAQYYI5HP3BHA2Q", "9WNKaloqh0HbrBbkN90HikJnmA1ayRSCqfF06mpw");
            client = new AmazonDynamoDBClient(credentials, RegionEndpoint.USWest1);
            var table = Amazon.DynamoDBv2.DocumentModel.Table.LoadTable(client, "Student");//For setting Table for Query Search
            var item = table.GetItem(txtRoll.Text,txtPassword.Text);// Get an Item With Hash key and Range Key
            if(item!=null)  // Check if item is Null or not for login
            {
                String CountryCode = default;
                foreach (var value in locations)
                {
                    CountryCode = value.CountryCode;// Get Country Code for CoronaVIRUS API
                }
                Session["CountryCode"] = CountryCode;//Creating Session because they are useful in Student Portal Page
                Session["FirstName"] = item["FirstName"].ToString();
                Session["LastName"] = item["LastName"].ToString();
                Session["StudentPic"] = item["StudentPic"].ToString();
                //Response.Write("<script>alert('" + CountryCode + "')</script>");
                Response.Redirect("StartPage.aspx");
               
            }
            else
            {
                Response.Write("<script>alert('Login Information Not Correct')</script>");
            }
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddStudent.aspx"); //  Navigate to AddStudent.aspx
        }
    }
}