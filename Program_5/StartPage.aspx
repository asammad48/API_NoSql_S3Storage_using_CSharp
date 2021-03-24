<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartPage.aspx.cs" Inherits="Program_5.StartPage" %>

<!DOCTYPE html> 
<html> 

<head> 
	<title> 
		STUDENTS PORTAL
	</title> 

	<link href= 
"https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css"
			rel="stylesheet" integrity= 
"sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh"
			crossorigin="anonymous"> 

	<script src="https://code.jquery.com/jquery-3.5.1.js" integrity= 
"sha256-QWo7LDvxbWT2tbbQ97B53yJnYU3WhH/C8ycbRAkjPDc="
			crossorigin="anonymous"> 
	</script> 
	
	<script src= 
"https://stackpath.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js"
			integrity= 
"sha384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6"
			crossorigin="anonymous"> 
	</script> 
</head> 

<body> 
	<!-- NAVBAR STARTING -->
	<!-- Use navbar class to the navbar logo 
		to the far left of the screen-->
			<nav class=" navbar navbar-expand-lg 
		navbar-light bg-light fixed-top py-lg-0 " style="position:fixed"> 

		<a class="navbar-brand" href="#"> 

			<!-- Add logo with size of 90*80 -->
            <asp:Image ID="Image1" runat="server" Width="90" Height="80"/>
		</a> 
		
		<button class="navbar-toggler" type="button"
				data-toggle="collapse"
				data-target="#navbarResponsive"
				aria-controls="navbarResponsive"
				aria-expanded="false"
				aria-label="Toggle navigation"> 
				
				<span class="navbar-toggler-icon"></span> 
		</button> 

		<div class="collapse navbar-collapse"
				id="navbarResponsive"> 
			<ul class="navbar-nav ml-auto"> 
				<li class="nav-item active"> 
					<a class="nav-link" href="#">
                        <asp:Label ID="Label8" runat="server" Text="" Font-Bold="true"></asp:Label> 
						<span class="sr-only">(current)</span> 
					</a> 
				</li> 
				<%--<li class="nav-item"> 
					<a class="nav-link" href="#">About</a> 
				</li> 
				<li class="nav-item"> 
					<a class="nav-link" href="#">Courses</a> 
				</li> 
				<li class="nav-item"> 
					<a class="nav-link" href="#">Contact</a> 
				</li> --%>
			</ul> 
		</div> 
	</nav>
	<div style="margin-top:100px" class="container">
        <asp:Label ID="lblCases" runat="server" Text="Label"></asp:Label>
	</div>
	<div style="margin-top:50px" class="container">
		
			<table class="table table-striped">
				<thead>
					<tr>
						<td>Day 1</td>
						<td>Day 2</td>
						<td>Day 3</td>
						<td>Day 4</td>
						<td>Day 5</td>
						<td>Day 6</td>
						<td>Day 7</td>
						
					</tr>
				</thead>
				<tbody>
					<tr>
						<td><asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
						<td><asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
						<td><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
						<td><asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
						<td><asp:Label ID="Label5" runat="server" Text=""></asp:Label></td>
						<td><asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>
						<td><asp:Label ID="Label7" runat="server" Text=""></asp:Label></td>
						
					</tr>
				</tbody>
			</table>
	</div>
	
	 
		
    

	


   


</body> 

</html> 

