using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Program_5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var client = new RestClient("https://covid-19-coronavirus-statistics.p.rapidapi.com/v1/total?country="+ Session["CountryCode"].ToString());
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-key", "fd251fd6abmsh2e75b5c3a6663aap111741jsn355f1e9bd503");
            request.AddHeader("x-rapidapi-host", "covid-19-coronavirus-statistics.p.rapidapi.com");
            IRestResponse response = client.Execute(request);
            Response.Write(response.Content);
            

            var coronalist = JsonConvert.DeserializeObject<JToken>(response.Content);
            
            //Response.Write(coronalist["data"].ToString());
            var newlist=JsonConvert.DeserializeObject(coronalist["data"].ToString());
            var coronalist1 = JsonConvert.DeserializeObject<JToken>(newlist.ToString());
            Label1.Text = Label1.Text + coronalist1["confirmed"];
            if (Session["FirstName"] != null && Session["LastName"] != null && Session["StudentPic"] != null)
            {

                Image1.ImageUrl = "https://studentpic.s3-us-west-1.amazonaws.com/" + Session["StudentPic"].ToString();
                Label8.Text = Session["FirstName"].ToString() + " " + Session["LastName"].ToString();
                



            }

        }
    }
}