using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient.Memcached;
using System.ComponentModel;
using System.Threading;

namespace Program_5
{
    public partial class StartPage : System.Web.UI.Page
    {
        List<List<CountryData>> CountryData1; 
        List<List<CoronaCases>> CoronaCasesData;
        protected void Page_Load(object sender, EventArgs e)
        {
            CountryData1 = new List<List<CountryData>>(); //List for Country data For only Finding slug
            CoronaCasesData = new List<List<CoronaCases>>(); //List for CoronaCases in Pakistan
            string slug = "";
            //GetCoronaCases("pakistan");
            string countrycode = Session["CountryCode"].ToString();
            //Response.Write("<script>alert('" + countrycode + "')</script>");
            var client = new RestClient("https://api.covid19api.com/countries");
            client.Timeout = -1;
            var request = new RestRequest(RestSharp.Method.GET);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);

            var countrydata = new JavaScriptSerializer().Deserialize<List<CountryData>>(response.Content);//Desearilze json into class object according to data
            CountryData1.Add(countrydata);
            int k = -1;
            foreach (var i in CountryData1)//Functionality for getting Confirmed Cases of Corona In Last Week
            {
                int count = i.Count();
                int forachcount = -1;
                foreach (var j in i)
                {

                    if (j.ISO2 == Session["CountryCode"].ToString())
                    {
                        slug = j.Slug;
                        //Response.Write("<script>alert('" + slug + "')</script>");
                        GetCoronaCases(slug);
                    }
                }
                //Response.Write("Count is : " + forachcount);
            }
            //Response.Write("<script>alert('" + Session["CountryCode"].ToString() + "')</script>");
            if (Session["FirstName"] != null && Session["LastName"] != null && Session["StudentPic"] != null)
            {

                Image1.ImageUrl = "https://studentpic.s3-us-west-1.amazonaws.com/" + Session["StudentPic"].ToString();
                Label8.Text = Session["FirstName"].ToString() + " " + Session["LastName"].ToString();




            }

        }
        public List<int> GetCoronaCases(string slug)
        {
            //Response.Write("<script>alert('In get corona function')</script>");
            List<int> coronaCasesweek = new List<int>();
            string url = "https://api.covid19api.com/total/country/" + slug;
            var client = new RestClient(@url);
            client.Timeout = -1;
            var request = new RestRequest(RestSharp.Method.GET);
            IRestResponse response = client.Execute(request);
            //Response.Write(response.Content);

            var coronalist = new JavaScriptSerializer().Deserialize<List<CoronaCases>>(response.Content);
            CoronaCasesData.Add(coronalist);
            int k = -1;
            foreach (var i in CoronaCasesData)
            {
                int count = i.Count();
                int forachcount = -1;
                foreach (var j in i)
                {
                    forachcount = forachcount + 1;
                    if (count - forachcount <= 8)
                    {
                        int casestotal = j.Confirmed;
                        coronaCasesweek.Add(casestotal);
                    }
                    // Response.Write(j);

                }

                //Response.Write("Count is : " + forachcount);
            }
            List<int> graphlist = new List<int>();
            
            int average=0;
            for (int i = 1; i < coronaCasesweek.Count(); i++)
            {
                graphlist.Add(coronaCasesweek[i] - coronaCasesweek[i - 1]);
                //Response.Write("<script>alert('" + graphlist[i - 1] + "')</script>");
                average += graphlist[i - 1];
               
                
            }
            average = average / 7;
            float percentage =(float) average / graphlist[0];
           
            if(percentage<1)
            {
                percentage = 1-percentage ;
                lblCases.Text = "As You can See from the following Table that there is " + percentage + " times decline in CoronaVirus Cases in the Last Week So Classes will be hold on Campus today";
            }
            else
            {
                percentage = percentage - 1;
                lblCases.Text = "As You can See from the following Table that there is " + percentage + " times incline in CoronaVirus Cases in the Last Week So Classes will be hold Online today";
            }
            Label1.Text = graphlist[0].ToString();
            Label2.Text = graphlist[1].ToString();
            Label3.Text = graphlist[2].ToString();
            Label4.Text = graphlist[3].ToString();
            Label5.Text = graphlist[4].ToString();
            Label6.Text = graphlist[5].ToString();
            Label7.Text = graphlist[6].ToString();
            


            return graphlist;
        }


        public class CountryData
        {
            public string Country { get; set; }
            public string Slug { get; set; }
            public string ISO2 { get; set; }

        }


        public class CoronaCases
        {
            public string Country { get; set; }
            public string CountryCode { get; set; }
            public string Province { get; set; }
            public string City { get; set; }
            public string CityCode { get; set; }
            public string Lat { get; set; }
            public string Lon { get; set; }
            public int Confirmed { get; set; }
            public int Deaths { get; set; }
            public int Recovered { get; set; }
            public int Active { get; set; }
            public string Status { get; set; }
            public string Date { get; set; }
        }

    }
}
