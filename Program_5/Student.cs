using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Program_5
{
   
        [DynamoDBTable("Student")]
        public class Student
        {
        [DynamoDBHashKey]
        public string RollNo { get; set; }
        [DynamoDBRangeKey]
        public string Password { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Semester { get; set; }
            public string CampusName { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string CourseDate { get; set; }

        
        public string Email { get; set; }
            public string StudentPic { get; set; }
            public int isActive { get; set; }
        }
    }
