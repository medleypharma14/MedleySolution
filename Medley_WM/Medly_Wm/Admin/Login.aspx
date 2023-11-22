<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FoodAdminReports.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">
    <!--<![endif]-->
    <!-- BEGIN HEAD -->

    <head>
    
   <style type="text/css">
div.main{
    background: #ffffff; /* Old browsers */
background: -moz-radial-gradient(center, ellipse cover,  #ffffff 1%, #1c2b5a 100%); /* FF3.6+ */
background: -webkit-gradient(radial, center center, 0px, center center, 100%, color-stop(1%,#ffffff), color-stop(100%,#1c2b5a)); /* Chrome,Safari4+ */
background: -webkit-radial-gradient(center, ellipse cover,  #ffffff 1%,#1c2b5a 100%); /* Chrome10+,Safari5.1+ */
background: -o-radial-gradient(center, ellipse cover,  #ffffff 1%,#1c2b5a 100%); /* Opera 12+ */
background: -ms-radial-gradient(center, ellipse cover,  #ffffff 1%,#1c2b5a 100%); /* IE10+ */
background: radial-gradient(ellipse at center,  #ffffff 1%,#1c2b5a 100%); /* W3C */
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#ffffff', endColorstr='#1c2b5a',GradientType=1 ); /* IE6-9 fallback on horizontal gradient */
height:calc(100vh);
width:100%;
}

[class*="fontawesome-"]:before {
  font-family: 'FontAwesome', sans-serif;
}

/* ---------- GENERAL ---------- */

* {
  box-sizing: border-box;
    margin:0px auto;

  &:before,
  &:after {
    box-sizing: border-box;
  }

}

body {
   
    color: #606468;
  font: 87.5%/1.5em 'Open Sans', sans-serif;
  margin: 0;
}

a {
	color: #eee;
	text-decoration: none;
}

a:hover {
	text-decoration: underline;
}

input {
	border: none;
	font-family: 'Open Sans', Arial, sans-serif;
	font-size: 14px;
	line-height: 1.5em;
	padding: 0;
	-webkit-appearance: none;
}

p {
	line-height: 1.5em;
}

.clearfix {
  *zoom: 1;

  &:before,
  &:after {
    content: ' ';
    display: table;
  }

  &:after {
    clear: both;
  }

}

.container {
  left: 50%;
  position: fixed;
  top: 50%;
  transform: translate(-50%, -50%);
}

/* ---------- LOGIN ---------- */

#login form{
	width: 250px;
}
#login, .logo{
    display:inline-block;
    width:40%;
}
#login{
 
}
.logo{
color:#fff;
font-size:50px;
  line-height: 125px;
}

#login form span.fa {
	background-color: #fff;
	border-radius: 3px 0px 0px 3px;
	color: #000;
	display: block;
	float: left;
	height: 50px;
    font-size:24px;
	line-height: 50px;
	text-align: center;
	width: 50px;
}

#login form input {
	height: 50px;
}
fieldset{
    padding:0;
    border:0;
    margin: 0;

}
#login form input[type="text"], input[type="password"] {
	background-color: #fff;
	border-radius: 0px 3px 3px 0px;
	color: #000;
	margin-bottom: 1em;
	padding: 0 16px;
	width: 200px;
}

#login form input[type="submit"] {
  border-radius: 3px;
  -moz-border-radius: 3px;
  -webkit-border-radius: 3px;
  background-color: #000000;
  color: #eee;
  font-weight: bold;
  /* margin-bottom: 2em; */
  text-transform: uppercase;
  padding: 5px 10px;
  height: 30px;
}

#login form input[type="submit"]:hover {
	background-color: #d44179;
}

#login > p {
	text-align: center;
}

#login > p span {
	padding-left: 5px;
}
.middle {
  display: flex;
  width: 600px;
}
#login form span.fa {
	background-color: #fff;
	border-radius: 3px 0px 0px 3px;
	color: #000;
	display: block;
	float: left;
	height: 50px;
    font-size:24px;
	line-height: 50px;
	text-align: center;
	width: 50px;
}
 
.fa-user-o:before{content:"\f2c0"}
.fa-users:before{content:"\f0c0"}
.fa-user-md:before{content:"\f0f0"}
.fa-user-plus:before{content:"\f234"}


.fa-user:before
{
    content:"\f007";
    }
    
    .fa-lock:before
    {
        content:"\f023"}
        
       .topform{
  border-bottom:2px solid lightgrey;
  margin:0px;
  background-image: url('../images/user.png');
  background-repeat: no-repeat;
  background-color:white;
  background-size: 9%;
  background-position: 50% 50%;
}
.bottomform{
  margin-top:0px;
  margin-bottom:20px;
  background-image: url('../images/pass.png');
  background-repeat: no-repeat;
  background-color:white;
  background-size: 10%;
  background-position: 50% 50%;
}
   </style>
        <meta charset="utf-8" />
        <title>Login</title>
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta content="width=device-width, initial-scale=1" name="viewport" />
        <meta content="Preview page of Metronic Admin Theme #2 for " name="description" />
        <meta content="" name="author" />
        <!-- BEGIN GLOBAL MANDATORY STYLES -->
        <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
        <link href="../assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
        <link href="../assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
        <link href="../assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="../assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css" />
        <!-- END GLOBAL MANDATORY STYLES -->
        <!-- BEGIN THEME GLOBAL STYLES -->
        <link href="../assets/global/css/components-md.min.css" rel="stylesheet" id="style_components" type="text/css" />
        <link href="../assets/global/css/plugins-md.min.css" rel="stylesheet" type="text/css" />
        <!-- END THEME GLOBAL STYLES -->
        <!-- BEGIN PAGE LEVEL STYLES -->
        <link href="../assets/pages/css/lock.min.css" rel="stylesheet" type="text/css" />
        <!-- END PAGE LEVEL STYLES -->
        <!-- BEGIN THEME LAYOUT STYLES -->
        <!-- END THEME LAYOUT STYLES -->
        <link rel="shortcut icon" href="favicon.ico" /> </head>
    <!-- END HEAD -->

     <body>
   
<div class="main">
    
    
    <div class="container">
<center>
<div class="middle">
      <div id="login">

         <form id="form1" runat="server">
          <div class="logo" style="padding-top:26px;    " ><asp:Image ID="log" ImageUrl="../images/logo11.png" style="width: 11pc; margin-left: -31px;" runat="server"  />
          
          <div class="clearfix"></div>
      </div>
           

            <p><span class="fa fa-user"  > </span><asp:TextBox  ID="txtUsername" AutoComplete="Off"  runat="server"  Placeholder="Username" ></asp:TextBox>
           </p>
            <p> <span class="fa fa-lock"></span><asp:TextBox  ID="txtpassword" AutoComplete="Off" runat="server"  Placeholder="PassWord" TextMode="Password"></asp:TextBox>
            </p> 
            
             <div>
                               
                                <span style="width:30%; text-align:right;  display: inline-block;">
                               <asp:Button id="Button1" Text="Sign-In" runat="server" OnClick="btnlogin_Click"  />
                                 
    
                                </span>
                                
                            </div>
                          
                           

         
         
<div class="clearfix"></div>
        </form>
         
        <div class="clearfix"></div>

      </div> <!-- end login -->
     
      


      </div>
</center>
 <div align="center" style="padding-top:2pc;width: 871px;">
                           <label id="Label1"  align="center" runat="server"> Powered By</label> <br />
                            <div class="logo" ><asp:Image ID="Image1" ImageUrl="../images/blogo.png" style="width: 22pc;" runat="server"  />
                            </div>
                            </div>
    </div>


</div>

</body>

</html>