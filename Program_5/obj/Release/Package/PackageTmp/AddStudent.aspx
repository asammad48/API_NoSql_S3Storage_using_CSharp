<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Program_5.AddStudent" %>
<head>
<meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body>
	<form runat="server">

		<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <div class="main">
			<!-- MAIN CONTENT -->
			<div class="main-content">
				<div class="container-fluid">
					<h3>Add Student</h3>
					<br />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
						<ContentTemplate>
                    <div class="form-group">

										 <div class="col-sm-6">
                                             <asp:TextBox ID="txtFname" runat="server" class="form-control input-group-lg" placeholder="First Name"></asp:TextBox>
                                             
										 </div>
										 <div class="col-sm-6">
											 <asp:TextBox ID="txtLname" runat="server" class="form-control input-group-lg" placeholder="Last Name"></asp:TextBox>
										 </div>
                                     </div>	
									<br />
									<br />
							<br />
									<div class="form-group">
										 <div class="col-sm-6">
                                             <asp:TextBox ID="txtRoll" runat="server" class="form-control input-group-lg" placeholder="Roll No" ></asp:TextBox>
                                             
										 </div>
										 <div class="col-sm-6">
											 <asp:TextBox ID="txtSemester" runat="server" class="form-control input-group-lg" placeholder="Semester"></asp:TextBox>
										 </div>
                                     </div>	
									<br />
									<br />
					                <div class="form-group">
                                        
												<div class="col-sm-6">
                                            <asp:TextBox ID="txtCampus" runat="server" class="form-control input-group-lg" placeholder="Campus Name"></asp:TextBox>
										 </div>
										<div class="col-sm-6">
                                           <asp:TextBox ID="txtCity" runat="server" class="form-control input-group-lg" placeholder="City/State"></asp:TextBox>
										 </div>
								
										
										 
                                     </div>
					<br />
					<br />



							  <div class="form-group">
                                        
												<div class="col-sm-6">
                                                     <asp:TextBox ID="txtPassword" runat="server" class="form-control input-group-lg" placeholder="Password" type="password"></asp:TextBox>
										 </div>
										<div class="col-sm-6">
                                           <asp:TextBox ID="txtEmail" runat="server" class="form-control input-group-lg" placeholder="Email"></asp:TextBox>
										 </div>
								
										
										 
                                     </div>
					<br />
					<br />




							 <div class="form-group">
                                        
												<div class="col-sm-6">
                                            <asp:TextBox ID="txtCountry" runat="server" class="form-control input-group-lg" placeholder="Country Name"></asp:TextBox>
										 </div>
										<div class="col-sm-6">
                                           <asp:TextBox ID="txtState" runat="server" class="form-control input-group-lg" placeholder="Postal/Zip Code"></asp:TextBox>
										 </div>
								
										
										 
                                     </div>
					<br />
					<br />


					                 <div class="form-group">
										 
										 <div class='col-sm-6'>
                                            
													 <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"> <asp:TextBox ID="txtCourseJoinDate" runat="server" class="form-control" Placeholder="Course Joining Date"></asp:TextBox></asp:LinkButton>
											 <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged">
												 <SelectedDayStyle CssClass="SelectedDayStyle" />
											 </asp:Calendar>
												
                                            
                                         </div>
										 <div class="col-sm-6">
                                             <asp:FileUpload ID="StudentImage" runat="server"/>
										 </div>
                                    
					                 </div>
					                 <br />
					                 <br />
					<br />
					<br />
							</ContentTemplate>
						</asp:UpdatePanel>
									<div class="form-group">
												<div class="col-sm-12 text-center">
													<asp:Button ID="btnAddStudent" runat="server" Text="Signup" class="form-control" OnClick="btnAddStudent_Click" style="background-color:#337ab7;color:white"/>
                                                  </div>
											
												 
											
										
										 
                                     </div>
					<br />
					<br />
					<div class="form-group">
												<div class="col-sm-12 text-center">
													<asp:Button ID="btnLogin" runat="server" Text="LOGIN" class="form-control" OnClick="btnLogin_Click" style="background-color:#337ab7;color:white"/>
                                                  </div>
											
												 
											
										
										 
                                     </div>
							
                    </div>
                </div>
		  </div>

	</form>
    

</body>
 