<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginStudent.aspx.cs" Inherits="Program_5.LoginStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
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
					<h2 style="text-align:center">Login Page</h2>
					<br />
					<br />
					<br />
					<br />
					<br />
					<br />
                    <div class="form-group">

										 <div class="col-sm-6">
                                             <asp:TextBox ID="txtRoll" runat="server" class="form-control input-group-lg" placeholder="Roll Number"></asp:TextBox>
                                             
										 </div>

										 <div class="col-sm-6">
											 <asp:TextBox ID="txtPassword" runat="server" class="form-control input-group-lg" placeholder="Password" type="password"></asp:TextBox>
										 </div>
                                     </div>	
									<br />
									<br />
									<div class="form-group">
												<div class="col-sm-12 text-center">
													<asp:Button ID="btnLoginStudent" runat="server" Text="Login" class="form-control" style="background-color:#337ab7;color:white" OnClick="btnLoginStudent_Click"/>
                                                  </div>
											
												 
											
										
										 
                                     </div>
					<br />
					<br />
					<br />

			                        	<div class="form-group">
												<div class="col-sm-12 text-center">
													<asp:Button ID="Button1" runat="server" Text="SignUp" class="form-control" style="background-color:#337ab7;color:white" OnClick="Button1_Click"/>
                                                  </div>
											
												 
											
										
										 
                                     </div>
							
                    </div>
                </div>
		  </div>

	</form>
    

</body>
 
</html>
