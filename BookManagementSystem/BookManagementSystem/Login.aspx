<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="loginnew" %>

<html lang="zh-CN">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>登录</title>

    <link href="css/bootstrap.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="css/reset.css">
    <link rel="stylesheet" type="text/css" href="css/style.css">
</head>
<body class="login_bg">
	<div id="login_content">
		<div class="login_logo">
			<img class="img-responsive" src="images/logo.png" >
		</div>
		<div class="login_box">
			 <div class="box_left">
			 	<img class="img-responsive" src="images/login_icon.png" >
			 </div>
			 <div class="box_right">
			 	<form id="loginForm" name="loginForm" runat="server" >
			 		<ul id="ul1" >
			 			<li class="box_bt"><img class="img-responsive" src="images/user_icon.png"  style="float:left;margin:8px 8px 0 0">用户登录</li>
			 			<li class="input-group input_li">
							  <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                              <asp:TextBox ID="tx_username" runat="server" type="text" class="form-control" name="userAccount" placeholder="请输入账号"></asp:TextBox>
			 			</li>
			 			<li class="input-group input_li">
							  <span class="input-group-addon" id="basic-addon1"><i class="glyphicon glyphicon-lock"></i></span>
                              <asp:TextBox ID="tx_password" runat="server" TextMode="Password" class="form-control" name="userPassword" placeholder="请输入密码"></asp:TextBox>						
			 			</li>
			 			<li></li>
			 			<li>
                             <div align="center">
							    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem>学生</asp:ListItem>
                                    <asp:ListItem>管理员</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
			 			</li>

			 			<li class="input_li">
                            <asp:Button ID="longin" runat="server" Text="登陆" OnClick="longin_Click" class="btn btn-primary login_btn"/>
			 			</li>
			 			<li class="input_li"  style="color: red; margin-bottom: 0;height: 10px;">
			 			&nbsp;<font color="red">本系统不支持IE9及以下浏览器和360浏览器兼容模式</font><br>
			 			</li>
			 			<li class="input_li" id="showMsg" style="color: red; margin-bottom: 0;">
							&nbsp;
			 			</li>
			 		</ul>
			 	</form>
			 </div>
		</div>
	</div>

	<footer>Copyright by 肖其昌 陈磊 西雅</footer>


    <script src="/framework/commonJs/jquery.min.js"></script>
    <script src="/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="/js/jspublic.js"></script>
	<script type="text/javascript" src="/framework/commonJs/jquery.min.js"></script>
  </body>
</html>
