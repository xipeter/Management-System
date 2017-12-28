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
    <div class="page-header">
      <h1>个人中心 <small>概要</small></h1>
    </div>

        <div class="tabbable tabs-left" style="margin-bottom: 18px;">
          <ul class="nav nav-tabs">
            <li class="active"><a href="#tab1" data-toggle="tab"><i class="icon-user large"></i>状态</a></li>
            <li><a href="#tab2" data-toggle="tab"><i class="icon-volume-up"></i>通知</a></li>
            <li><a href="#tab3" data-toggle="tab"><i class="icon-book"></i>其他</a></li>
          </ul>
          <div class="tab-content" style="padding-bottom: 9px; border-bottom: 1px solid #ddd;">
            <div class="tab-pane active" id="tab1">
                <div class="page-header">
                  <h3>
                    最新状态 <small>关注您的最新状态</small>
                  </h3>
                </div>

                 <div class="progress progress-striped active">

                       <div class="bar" <?php  if($emp_state[0]["STATE"]=="0"){ echo "style='width: 20%;'"; }elseif ($emp_state[0]["STATE"]=="1") { echo "style='width: 40%;'"; }elseif ($emp_state[0]["STATE"]=="2") { echo "style='width: 60%;'"; }elseif ($emp_state[0]["STATE"]=="3") { echo "style='width: 80%;'"; }elseif ($emp_state[0]["STATE"]=="4") { echo "style='width: 100%;'"; } ?> ></div>

                       
                  </div>

                  <span class="alert alert-success offset4">
                    当前状态：
                  <?php  if($emp_state[0]["STATE"]=="0"){ echo "资料填写,请尽快完善您的信息资料，并点击‘提交审核’"; }elseif ($emp_state[0]["STATE"]=="1") { echo "待审核,下一步状态为‘审核通过’"; }elseif ($emp_state[0]["STATE"]=="2") { echo "审核通过,下一步状态为‘入职’"; }elseif ($emp_state[0]["STATE"]=="3") { echo "入职,下一步状态为‘资料提供’"; }elseif ($emp_state[0]["STATE"]=="4") { echo "资料提供,下一步状态为‘完成’"; }else{ echo "完成"; } ?> 
                  </span>
            </div>


            <div class="tab-pane" id="tab2">
              <div class="page-header">
                  <h3>
                    通知公告 <small>关注最新通知</small>
                  </h3>
                </div>
              <p>暂无通知</p>
            </div>


            <div class="tab-pane" id="tab3">
               <div class="page-header">
                  <h3>
                    其他 <small>其他事宜</small>
                  </h3>
                </div>

                <ul class="thumbnails">
                    <li class="span4">
                        <div class="thumbnail">
                          <img alt="300x200" src="__PUBLIC__/Public/img/city.jpg" />
                          <div class="caption">
                            <h3>
                              注意事项
                            </h3>
                            <p>
                              1、请关注您的实时审核进度<br />2、如有问题，请与人力资源部联系
                            </p>

                          </div>
                        </div>
                    </li>
                </ul>



            </div>


          </div>
        </div> <!-- /tabbable -->




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