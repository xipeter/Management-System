<?php if (!defined('THINK_PATH')) exit();?><!DOCTYPE html>
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7"> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8"> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<!--[if gt IE 8]><!--> <html lang="en"> <!--<![endif]-->
  <head>
    <meta charset="utf-8">
    <title>锦艺集团人力资源管理系统</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    
    <!-- Le styles -->
    <link href="__PUBLIC__/Public/assets/css/bootstrap.min.css" rel="stylesheet">
    <link href="__PUBLIC__/Public/assets/css/bootstrap-responsive.min.css" rel="stylesheet">
    <link href="__PUBLIC__/Public/assets/css/docs.css" rel="stylesheet">
    <link href="__PUBLIC__/Public/assets/css/datetimepicker.css" rel="stylesheet">
    <!--xizf modify20130704无法执行js-->
    <script src="__PUBLIC__/public/js/jquery.js"></script>
    <script src="__PUBLIC__/public/js/bootstrap.min.js"></script>

    <style>
    h1, h2, h3, .masthead p, .subhead p, .marketing h2, .lead
{
  font-family: "Helvetica Neue", Helvetica, Arial, "Microsoft Yahei UI", "Microsoft YaHei", SimHei, "\5B8B\4F53", simsun, sans-serif;
  font-weight: normal;
}

#scrollUp {
  bottom: 20px;
  right: 20px;
  height: 38px;  /* Height of image */
  width: 38px; /* Width of image */
  background: url("assets/img/top.png") no-repeat;
}
    </style>
    <link href="__PUBLIC__/Public/assets/css/prettify.css" rel="stylesheet">
    <link href="__PUBLIC__/Public/assets/css/bootstro.min.css"  rel="stylesheet">
	<!--
	<link href="__PUBLIC__/Public/dist/css/flat-ui.css" rel="stylesheet"> --> modify by xizf @20140928 按钮不兼容


    <!-- Le HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
      <script src="//cdnjs.bootcss.com/ajax/libs/html5shiv/3.6.2/html5shiv.js"></script>
    <![endif]-->

    <!-- Le fav and touch icons -->
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="assets/ico/apple-touch-icon-144-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="assets/ico/apple-touch-icon-114-precomposed.png">
      <link rel="apple-touch-icon-precomposed" sizes="72x72" href="assets/ico/apple-touch-icon-72-precomposed.png">
                    <link rel="apple-touch-icon-precomposed" href="assets/ico/apple-touch-icon-57-precomposed.png">
                                   <link rel="shortcut icon" href="assets/ico/favicon.png">


    <script>
var _hmt = _hmt || [];
</script>
  </head>

  <body data-spy="scroll" data-target=".bs-docs-sidebar">

    <!-- Navbar
    ================================================== -->
    <div class="navbar navbar-inverse navbar-fixed-top">
      <div class="navbar-inner">
        <div class="container">
           <button type="button" class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse">
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a class="navbar-brand hidden-sm" href="http://www.jinyigroup.com">锦艺集团</a>
          <!--<font style="color:white;" size="4.5pt"></font>-->

          <a class="brand" href="#">人力资源管理系统</a>
          <div class="nav-collapse collapse">
            <ul class="nav">
              <li >
                <a href="__PUBLIC__/">首页</a>
              </li>
             

              <li >
                <a href="__PUBLIC__/index.php/BaseInfor" class="bootstro" data-bootstro-title=""
           data-bootstro-placement="bottom"  data-bootstro-step="0">1、基础资料填写</a>
              </li>

              <li >
                 <a class="dropdown-toggle" href="__PUBLIC__/index.php/ReviewInfor" >2、人事资料审核</a>
                
              </li>
			  <li >
                 <a class="dropdown-toggle" href="__PUBLIC__/index.php/Assets" >3、入职面试</a>
                
              </li>
			  
			   <li >
                 <a class="dropdown-toggle" href="__PUBLIC__/index.php/Assets" >4、资料提交</a>
                
              </li>
			 <?php
 if(isset($_SESSION[C('USER_AUTH_KEY')])) { echo " <li >
				<a class='dropdown-toggle' href='__PUBLIC__/index.php/Login/logout' >"; echo $_SESSION[C('USER_NAME')]; echo "->退出登陆</a>
                
              </li>"; } ?>
                    
					
            
            </ul>
          </div>

        </div>
      </div>
    </div>

<!-- Masthead
================================================== -->



    

<div class="container">

    <!-- Docs nav
    ================================================== -->

	
	<div class="container-fluid">
	<div class="row-fluid">
	
		<div class="span12">
        <!-- Customize form
        ================================================== -->
			
			  <section class="download" id="t1">
				<div class="page-header">              
				  <h2>
					<img alt=""  style="height:20%;width:20%;"  src="__PUBLIC__/Public/img/logo.png" /> &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; 诚邀您的加盟
				  </h2>
				</div>
			
			  </section>
			
			
			<div class="carousel slide" id="carousel-996444">
				<ol class="carousel-indicators">
					<li data-slide-to="0" data-target="#carousel-996444">
					</li>
					<li data-slide-to="1" data-target="#carousel-996444">
					</li>
					<li data-slide-to="2" data-target="#carousel-996444" class="active">
					</li>
				</ol>
				<div class="carousel-inner">
					<div class="item">
						<img alt="" src="__PUBLIC__/Public/img/index/1.jpg" />
						<div class="carousel-caption">
							<h4>
								核心价值
							</h4>
							<p>
								诚信  敬业 团队 共赢
							</p>
						</div>
					</div>
					<div class="item">
						<img alt="" src="__PUBLIC__/Public/img/index/2.jpg" />
						<div class="carousel-caption">
							<h4>
								企业使命
							</h4>
							<p>
								持续为社会创造价值
							</p>
						</div>
					</div>
					<div class="item active">
						<img alt="" src="__PUBLIC__/Public/img/index/3.jpg" />
						<div class="carousel-caption">
							<h4>
								企业愿景
							</h4>
							<p>
								受人尊敬的企业
							</p>
						</div>
					</div>
				</div> <a data-slide="prev" href="#carousel-996444" class="left carousel-control">‹</a> <a data-slide="next" href="#carousel-996444" class="right carousel-control">›</a>
			</div>
			<!--
			<div class="hero-unit">
						<h2>
							指南
						</h2>
						<p>
							请输入HR给您的用户名和密码，填写基础信息，查看招聘进度。
						</p>
						<p>
							<a class="btn btn-primary btn-large" href="#">登陆 »</a>
						</p>
			</div>
			-->
			
			
			 
              
			      
       

      

			 

			
	</div> 
	
	
	<div class="row-fluid">
	<div class="span8">
	<h2 contenteditable="false">指南</h2>
                <p contenteditable="false">请输入HR给您的用户名和密码，填写基础信息，查看招聘进度.</p>
	</div>
	<div class="span4">
	<form id='loginform' action="__URL__/checklogin/" method="post">
	          <div class="login-form">
            <div class="form-group">
              <input type="text" class="form-control login-field" value="" placeholder="用户名" id="login-name" name="username" />
              <label class="login-field-icon fui-user" for="login-name"></label>
            </div>
 
            <div class="form-group">
              <input type="password" class="form-control login-field" value="" placeholder="密码" id="login-pass" name="passwd" />
              <label class="login-field-icon fui-lock" for="login-pass"></label>
            </div>
			
			<div class="form-group">
              <input type="text" class="form-control login-field" value="" name="verify" placeholder="验证码" id="verify-code" />
			  <img  src='__APP__/Public/verify/' onclick="javascript:this.src='__APP__/Public/verify/'+Math.random();" />
              <label class="login-field-icon fui-alert-circle" for="verify-code"></label>
            </div>
			
            <a class="btn btn-primary btn-lg btn-block" href="javascript:$('#loginform').submit();">登陆</a>
            
          </div>
	</form>
	
	</div>
	</div>
	

	
</div>

  </div>

    <!-- Footer
    ================================================== -->
    <footer class="footer">
      <div class="container">        
        <p><a href="#" >Copyright</a><a href="#" >锦艺集团© 版权所有<br /> Power By 集团综合管理部</a>.</p>             
      </div>
    </footer>

  </body>
</html>