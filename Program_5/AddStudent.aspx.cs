using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Amazon.Runtime;
using Amazon.DynamoDBv2;
using Amazon;
using Amazon.DynamoDBv2.Model;
using System.Threading;
using Amazon.DynamoDBv2.DataModel;
using System.Net.Mail;

namespace Program_5
{
    public partial class AddStudent : System.Web.UI.Page
    {
        private static AmazonDynamoDBClient client = new AmazonDynamoDBClient();
        DynamoDBContext context = new DynamoDBContext(client);
        static void Main(string[] args)
        {
            try
            {
                DynamoDBContext context = new DynamoDBContext(client);
                Console.WriteLine("To continue, press Enter");
                Console.ReadLine();
            }
            catch (AmazonDynamoDBException e) { Console.WriteLine(e.Message); }
            catch (AmazonServiceException e) { Console.WriteLine(e.Message); }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        static List<Location> locations = new List<Location>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // In the Structure When Page is not Post Back
            {
                Calendar1.Visible = false;

                string ipAddress = string.Empty;

                if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]!=null)//Checking and getting Ip Address
                {
                    ipAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString(); 
                }
                else if(HttpContext.Current.Request.UserHostAddress.Length!=0)// If run on localhost get Localhost ip
                {
                    ipAddress = HttpContext.Current.Request.UserHostAddress;
                }
                //Response.Write("<script>alert('" + ipAddress + "')</script>");
                string APIKey = "7ad2b709fbd352f8cdc825f496aea90c9dbe8991d0729a918c839b50e71d71b4";
                string url = string.Format("http://api.ipinfodb.com/v3/ip-city/?key={0}&ip={1}&format=json", APIKey, ipAddress); //For sending Ip address to Api for getting information
                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(url); //Downloading string in Json Format
                    Location location = new JavaScriptSerializer().Deserialize<Location>(json); // Loading the content of JSON data in Class type Variable
                    locations.Add(location);
                    foreach (var value in locations)
                    {
                        txtCountry.Text = value.CountryName;  // Setting value in textfeild
                        txtCity.Text = value.CityName; // Setting value in textfeild
                        txtState.Text = value.RegionName; // Setting value in textfeild
                    }

                }

            }
        }


        private void CreateTable()
        {
            var credentials = new BasicAWSCredentials("AKIAJDAQYYI5HP3BHA2Q", "9WNKaloqh0HbrBbkN90HikJnmA1ayRSCqfF06mpw");// Setting AWS Credentials
            client = new AmazonDynamoDBClient(credentials, RegionEndpoint.USWest1);// Set Region
            string tableName = "Student";
            var tableResponse = client.ListTables();
            if (!tableResponse.TableNames.Contains(tableName))//Checking If table exists
            {
                //Below Code for Creating Table
                client.CreateTable(new CreateTableRequest
                {
                    TableName = tableName,
                    ProvisionedThroughput = new ProvisionedThroughput
                    {
                        ReadCapacityUnits = 3,
                        WriteCapacityUnits = 1
                    },
                    KeySchema = new List<KeySchemaElement>
                    {
                        new KeySchemaElement
                        {
                            AttributeName = "RollNo",
                            KeyType = KeyType.HASH
                        },
                        new KeySchemaElement
                        {
                            AttributeName="Password",
                            KeyType=KeyType.RANGE
                        }
                    },
                    AttributeDefinitions = new List<AttributeDefinition>
                    {
                        new AttributeDefinition { AttributeName = "RollNo", AttributeType=ScalarAttributeType.S },
                        new AttributeDefinition { AttributeName = "Password", AttributeType=ScalarAttributeType.S }
                    }
                });

                bool isTableAvailable = false;
                while (!isTableAvailable)
                {
                    Console.WriteLine("Waiting for table to be active...");
                    Thread.Sleep(5000);
                    var tableStatus = client.DescribeTable(tableName);
                    isTableAvailable = tableStatus.Table.TableStatus == "ACTIVE";
                }
                Response.Write("<script>alert('Table Created Successfully!')</script>");
            }
        }
    




    protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;// Some Functonality for Calendar in signup form
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtCourseJoinDate.Text = Calendar1.SelectedDate.ToString(); // Setting Date to Textbox when Calendar Date is Selected
            Calendar1.Visible = false;
        }

        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            Stream st = StudentImage.PostedFile.InputStream;

            string name = Path.GetFileName(StudentImage.FileName); //For getting Path and Name of Picture

            if (txtEmail.Text!=null&&txtPassword.Text!=null&&txtRoll.Text!=null&&txtFname.Text!=null)// All Form Feild Must be Filled
            {
                if (name == "")
                {
                    Response.Write("<script>'You must Have to upload your Profile Picture'</script>");
                }
                else
                {
                    String extension = Path.GetExtension(name);//Get uploaded file Extension
                    String ImageName = Guid.NewGuid() + extension;// New Name of file is RandomString with Extension
                    if (extension == ".jpg" || extension == ".png" || extension == ".jpeg" || extension == ".tiff" || extension == ".gif")// Images must be of this type
                    {
                        string myBucketName = "studentpic"; //your s3 bucket name goes here  
                        string s3DirectoryName = "";
                        string s3FileName = @ImageName;
                        bool a;
                        AmazonUploader myUploader = new AmazonUploader();
                        a = myUploader.sendMyFileToS3(st, myBucketName, s3DirectoryName, s3FileName);
                        if (a == true)
                        {
                            //Response.Write("<script>alert('Successfull Uploaded')</script>");
                            CreateTable();
                            //Create an Student object to save  
                            Student currentState = new Student
                            {
                                //studentId = Guid.NewGuid().ToString(),
                                FirstName = txtFname.Text,
                                LastName = txtLname.Text,
                                RollNo = txtRoll.Text,
                                CampusName = txtCampus.Text,
                                City = txtCity.Text,
                                Country = txtCountry.Text,
                                CourseDate = txtCourseJoinDate.Text,
                                Semester = txtSemester.Text,
                                State = txtState.Text,
                                Password=txtPassword.Text,
                                Email=txtEmail.Text,
                                StudentPic=@ImageName,
                                isActive = 1
                            };

                            //Save an Student object  
                            context.Save<Student>(currentState);

                            SendEmail();
                            Response.Write("<script>alert('A Congratulation Mail Has been Sent to Your Email')</script>");
                        }
                        else
                            Response.Write("Error");
                    }
                    else
                    {
                        Response.Write("<script>alert('File Must be an Images')</script>");
                    }




                }
            }
            else
            {
                Response.Write("<script>alert('All Enteries Must Be Filled')</script>");
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginStudent.aspx");
        }
        public void SendEmail()
        {
            MailMessage message1 = new MailMessage("program5five@gmail.com", txtEmail.Text); //From Email,To Email
            message1.Subject = "Congratulation!";
            message1.Body = "Thank you '" + txtFname.Text + "' for Signing up to Student Portal <br><br>";
            message1.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);// Specify Port number and Channel for transferring mail
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("program5five@gmail.com", "Program5%five"); // Setting Gmail Credentials
            try
            {
                client.Send(message1);  //Send Gmail
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }
        }
    }
    public class Location // Creating Class for JSON Deserialing IPINFODB
    {
        public string IPAddress { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public string ZipCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string TimeZone { get; set; }
    }
}