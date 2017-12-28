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



    
<script src="__PUBLIC__/Public/js/jquery.form.js"></script>
<script type="text/javascript">

function relativechange(){
  $('#EMP_RELATIVENAME').attr("disabled", "disabled"); 

}
function enablerelative(){
  $('#EMP_RELATIVENAME').removeAttr("disabled"); 

}


function checkForm(){ 
  if($("#SCHOOL_NAME").val().trim()==""){
    alert("请输入学校名称");
    return false;
  } 
  if($("#SCHOOL_BEGINANDEND_TIME").val().trim()==""){
    alert("请输入起止时间");
    return false;
  }
   if($("#SCHOOL_EMP_EDU").val().trim()==""){
    alert("请输入学历");
    return false;
  }
  if($("#SCHOOL_EMP_PROFESSION").val().trim()==""){
    alert("请输入专业");
    return false;
  }
  return true;
}
//基础信息表单检查
function checkBaseForm(){ 
  if($("#EMP_NAME").val().trim()==""){
    alert("请输入姓名");
    return false;
  } 
  if($("#EMP_IDEN").val().trim()==""){
    alert("请输入身份证号");
    return false;
  }
   if($("#EMP_AGE").val().trim()==""){
    alert("请输入年龄");
    return false;
  }
  if($("#EMP_HEIGHT").val().trim()==""){
    alert("请输入身高");
    return false;
  }
  if($("#EMP_NATIVE").val().trim()==""){
    alert("请输入籍贯");
    return false;
  }
  if($("#EMP_RESIDENCE").val().trim()==""){
    alert("请输入户口");
    return false;
  }
  if($("#EMP_ADDRESS").val().trim()==""){
    alert("请输入住址");
    return false;
  }
  if($("#EMP_PHONE").val().trim()==""){
    alert("请输入手机");
    return false;
  }
  if($("#EMP_LANGUAGE").val().trim()==""){
    alert("请输入外语程度");
    return false;
  }
  if($("#EMP_COLLEGE").val().trim()==""){
    alert("请输入毕业院校");
    return false;
  }
  if($("#EMP_HEIGHT").val().trim()==""){
    alert("请输入身高");
    return false;
  }
  if($("#EMP_PROFESSION").val().trim()==""){
    alert("请输入专业");
    return false;
  }
  if($("#EMP_TITLE").val().trim()==""){
    alert("请输入职称");
    return false;
  }
  if($("#EMP_EXPSALARY").val().trim()==""){
    alert("请输入期望薪资");
    return false;
  }
  if($("#EMP_CERTIFICATE").val().trim()==""){
    alert("请输入证书信息");
    return false;
  }
  if($("#EMP_RELATIVENAME").val().trim()==""&&!$('#radio_realtive').is(":checked")){
    alert("请输入亲属姓名");
    return false;
  }
  return true;
}
///培训经历表单检查
function checkTrainForm(){ 
  if($("#TRAIN_TITLE ").val().trim()==""){
    alert("请输入培训内容");
    return false;
  } 
  if($("#TRAIN_BEGINANDEND_TIME").val().trim()==""){
    alert("请输入起止时间");
    return false;
  }
   if($("#TRAIN_ADDRESS").val().trim()==""){
    alert("请输入培训地点");
    return false;
  }
  if($("#TRAIN_PURPOSE").val().trim()==""){
    alert("请输入培训目的");
    return false;
  }
  return true;
}
///工作经历表单检查
function checkJobForm(){ 
  if($("#JOB_COMPANY").val().trim()==""){
    alert("请输入工作单位");
    return false;
  } 
  if($("#JOB_BEGINANDEND_TIME").val().trim()==""){
    alert("请输入起止时间");
    return false;
  }
  if($("#DEPARTANDPOST").val().trim()==""){
    alert("请输入所在部门及岗位");
    return false;
  }
  if($("#JOB_SALARY").val().trim()==""){
    alert("请输入薪资");
    return false;
  }
  if($("#JOB_PROOF_PERSONANDTEL").val().trim()==""){
    alert("请输入证明人及电话");
    return false;
  }
  if($("#LEAVE_REASON").val().trim()==""){
    alert("请输入离职原因");
    return false;
  }
  return true;
}
///家庭成员表单检查
function checkFamilyForm(){ 
  if($("#FAMILY_NAME").val().trim()==""){
    alert("请输入姓名");
    return false;
  } 
  if($("#FAMILY_RELATION").val().trim()==""){
    alert("请输入与家庭成员的关系");
    return false;
  }
  if($("#FAMILY_AGE").val().trim()==""){
    alert("请输入家庭成员年龄");
    return false;
  }
  if($("#FAMILY_COMPANY").val().trim()==""){
    alert("请输入家庭成员工作单位");
    return false;
  }
  if($("#FAMILY_TEL").val().trim()==""){
    alert("请输入家庭成员电话");
    return false;
  }
  return true;
}
///紧急事件表单检查
function checkEmergeForm(){ 
  if($("#EMP_EMERGE_NAME").val().trim()==""){
    alert("请输入联系人姓名");
    return false;
  } 
  if($("#EMP_EMERGE_PHONE").val().trim()==""){
    alert("请输入联系人电话");
    return false;
  }
  if($("#EMP_EMERGE_ADDRESS").val().trim()==""){
    alert("请输入联系人地址");
    return false;
  }
  if($("#EMP_EMERGE_MAILCODE").val().trim()==""){
    alert("请输入联系人邮编");
    return false;
  }
  return true;
}
///自我评价表单检查
function checkMyselfForm(){ 
  if($("#EMP_OTHERS").val().trim()==""){
    alert("请输入性格特点和自我评价");
    return false;
  } 
  return true;
}
//删除教育经历
var delschool = function(empid){
      $.ajax({ 
      url:"__URL__/delschool",
      dataType: "json",  
      data:{id:empid}, 
      type: "post", 
      success: function(data) 
      {
        if(1==data){
        //提交成功
          window.location.reload();
        }else{
          window.location.reload();
          alert("删除失败");
          
        }
      
      } 
    }); 


};
//删除培训经历
var deltrain = function(empid){
      $.ajax({ 
      url:"__URL__/deltrain",
      dataType: "json",  
      data:{id:empid}, 
      type: "post", 
      success: function(data) 
      {
        if(1==data){
        //提交成功
          window.location.reload();
        }else{
          window.location.reload();
          alert("删除失败");
          
        }
      
      } 
    }); 


};
//删除工作经历
var deljob = function(empid){
      $.ajax({ 
      url:"__URL__/deljob",
      dataType: "json",  
      data:{id:empid}, 
      type: "post", 
      success: function(data) 
      {
        if(1==data){
        //提交成功
          window.location.reload();
        }else{
          window.location.reload();
          alert("删除失败");
          
        }
      
      } 
    }); 


};
//删除家庭成员
var delfamily = function(empid){
      $.ajax({ 
      url:"__URL__/delfamily",
      dataType: "json",  
      data:{id:empid}, 
      type: "post", 
      success: function(data) 
      {
        if(1==data){
        //提交成功
          window.location.reload();
        }else{
          window.location.reload();
          alert("删除失败");
          
        }
      
      } 
    }); 


};
//更新个人信息状态
var updatestate = function(){
      $.ajax({ 
      url:"__URL__/updatestate",
      dataType: "json",  
      data:null, 
      type: "post", 
      success: function(data) 
      {
        if(1==data){
        //提交成功
          window.location="__PUBLIC__/index.php/ReviewInfor";
        }else{
          window.location.reload();
          alert("更新失败");
          
        }
      
      } 
    }); 


};


$(function(){
	$('#school-form').submit(function() {
		if(!checkForm()){
			
			return false;
			}
		
		 
		$.ajax({ 
			url:"__URL__/addschool",
			data: $('#school-form').serialize(), 
			type: "post", 
			success: function(data) 
			{
				if(1==data){
				//提交成功
					$('#close_school').click();
					window.location.reload();
				}else{
					$('#close_school').click();
          window.location.reload();
					alert("新增失败,请重试");
				}
			
			} 
		}); 
		return false; 
	}); 
  //培训经历提交
    $('#train-form').submit(function() {
    if(!checkTrainForm()){
      
      return false;
      }
    
     
    $.ajax({ 
      url:"__URL__/addtrain",
      data: $('#train-form').serialize(), 
      type: "post", 
      success: function(data) 
      {
        if(1==data){
        //提交成功
          
          window.location.reload();
        }else{
         
          window.location.reload();
          alert("新增失败,请重试");
        }
      
      } 
    }); 
    return false; 
  });

  //工作经历提交
  $('#job-form').submit(function() {
    if(!checkJobForm()){
      
      return false;
      }
    
     
    $.ajax({ 
      url:"__URL__/addjob",
      data: $('#job-form').serialize(), 
      type: "post", 
      success: function(data) 
      {
        if(1==data){
        //提交成功
          window.location.reload();
        }else{
          alert("新增失败,请重试");
          window.location.reload();
          
        }
      
      } 
    }); 
    return false; 
  });
  //家庭成员提交
  $('#family-form').submit(function() {
    if(!checkFamilyForm()){
      
      return false;
      }
    
     
    $.ajax({ 
      url:"__URL__/addfamily",
      data: $('#family-form').serialize(), 
      type: "post", 
      success: function(data) 
      {
        if(1==data){
        //提交成功
          window.location.reload();
        }else{
          alert("新增失败,请重试");
          window.location.reload();
          
        }
      
      } 
    }); 
    return false; 
  });
    //基础信息提交
  $('#base-form').submit(function() {
    if(!checkBaseForm()){
      
      return false;
    }
    $.ajax({ 
      url:"__URL__/addbaseinfor",
      data: $('#base-form').serialize(), 
      type: "post", 
      success: function(data) 
      {
        if(1==data){
        //提交成功
          alert("保存成功");
          window.location.reload();
        }else{
          alert("新增失败,请重试");
          window.location.reload();
          
        }
      
      } 
    }); 
    return false; 
  });

  //紧急事件提交
  $('#emerge-form').submit(function() {
    if(!checkEmergeForm()){
      
      return false;
    }
    $.ajax({ 
      url:"__URL__/addemerge",
      data: $('#emerge-form').serialize(), 
      type: "post", 
      success: function(data) 
      {
        if(1==data){
        //提交成功
          alert("保存成功");
          window.location.reload();
        }else{
          alert("新增失败,请重试");
          window.location.reload();
          
        }
      
      } 
    }); 
    return false; 
  });

    //自我评价提交
  $('#myself-form').submit(function() {
    if(!checkMyselfForm()){
      
      return false;
    }
    $.ajax({ 
      url:"__URL__/addmyself",
      data: $('#myself-form').serialize(), 
      type: "post", 
      success: function(data) 
      {
        if(1==data){
        //提交成功
          alert("保存成功");
          window.location.reload();
        }else{
          alert("新增失败,请重试");
          window.location.reload();
          
        }
      
      } 
    }); 
    return false; 
  });

});

</script>



  <div class="container">

    <!-- Docs nav
    ================================================== -->
  <div class="row">
    <div class="span12">
      <div class="row">
      <div class="span3 bs-docs-sidebar">
        <ul class="nav nav-list bs-docs-sidenav">
          <li><a href="#t1"><i class="icon-chevron-right"></i>
          <?php  if($empinfor_state[0]["STATUS"]=="0"){ echo "<span class='badge badge-inverse'>×</span>"; }else{ echo "<span class='badge badge-important'>√</span>"; }?>
          1.个人资料</a></li>
          <li><a href="#t2"><i class="icon-chevron-right"></i>
          <?php  if($empinfor_state[1]["STATUS"]=="0"){ echo "<span class='badge badge-inverse'>×</span>"; }else{ echo "<span class='badge badge-important'>√</span>"; }?>2.紧急事件联络人</a></li>
          <li><a href="#t3"><i class="icon-chevron-right"></i>
          <?php  if($empinfor_state[2]["STATUS"]=="0"){ echo "<span class='badge badge-inverse'>×</span>"; }else{ echo "<span class='badge badge-important'>√</span>"; }?>
            3.教育经历</a></li>
          <li><a href="#t4"><i class="icon-chevron-right"></i>
          <?php  if($empinfor_state[3]["STATUS"]=="0"){ echo "<span class='badge badge-inverse'>×</span>"; }else{ echo "<span class='badge badge-important'>√</span>"; }?>
            4.培训经历</a></li>
          <li><a href="#t5"><i class="icon-chevron-right"></i>
          <?php  if($empinfor_state[4]["STATUS"]=="0"){ echo "<span class='badge badge-inverse'>×</span>"; }else{ echo "<span class='badge badge-important'>√</span>"; }?>
            5.工作经历</a></li>
          <li><a href="#t6"><i class="icon-chevron-right"></i>
          <?php  if($empinfor_state[5]["STATUS"]=="0"){ echo "<span class='badge badge-inverse'>×</span>"; }else{ echo "<span class='badge badge-important'>√</span>"; }?>
            6.家庭成员</a></li>
          <li><a href="#t7"><i class="icon-chevron-right"></i>
          <?php  if($empinfor_state[6]["STATUS"]=="0"){ echo "<span class='badge badge-inverse'>×</span>"; }else{ echo "<span class='badge badge-important'>√</span>"; }?>
            7.性格特点及自我评价</a></li>
          <li><a href="#t8"><i class="icon-chevron-right"></i>8.诚信承诺</a></li>
        </ul>
      </div>

      <div class="span9">

        <!-- Customize form
        ================================================== -->

          
          <section class="download" id="t1">
             <div class="page-header">
              <blockquote>
                <p>(一)个人资料</p>
              </blockquote>
            </div>
    <form class="form-inline" id="base-form" method="post" action="__URL__/addbaseinfor" enctype="multipart/form-data">
      <?php if(is_array($base_infor)): $i = 0; $__LIST__ = $base_infor;if( count($__LIST__)==0 ) : echo "" ;else: foreach($__LIST__ as $key=>$base): $mod = ($i % 2 );++$i;?><div class="row">
     
               <div class="span4">
               
                  
                 <label class="control-label" for="EMP_NAME">姓名</label>
                    <input type="text" id="EMP_NAME" name="EMP_NAME" placeholder="姓名" value="<?php echo ($base["EMP_NAME"]); ?>">
                 
                
              </div>

               <div class="span5">

                  <label class="control-label" for="EMP_IDEN">身份证号</label>
          
                    <input type="text" id="EMP_IDEN" name="EMP_IDEN" placeholder="身份证号" value="<?php echo ($base["EMP_IDEN"]); ?>">


               </div>

        </div>



         <div class="row">
               <div class="span4">
                  <label class="control-label" for="EMP_AGE">年龄</label>
                     <input type="text" id="EMP_AGE" name="EMP_AGE" placeholder="年龄" value="<?php echo ($base["EMP_AGE"]); ?>">
               </div>
              <div class="span5">
                  <label class="control-label" >性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别</label>
                   <?php  if($base["EMP_SEX"]==1){ echo "<label class='radio'> <input type='radio' name='EMP_SEX' id='optionsRadios1' value='1' checked >男 </label>"; echo "<label class='radio'><input type='radio' name='EMP_SEX' id='optionsRadios2' value='2'  >女</label>"; }else{ echo "<label class='radio'> <input type='radio' name='EMP_SEX' id='optionsRadios1' value='1'  >男 </label>"; echo "<label class='radio'><input type='radio' name='EMP_SEX' id='optionsRadios2' value='2' checked >女</label>"; } ?>
              </div>
        </div>


         <div class="row">
               <div class="span4">
                  <label class="control-label" for="EMP_HEIGHT">身高</label>
                     <input type="text" id="EMP_HEIGHT" name="EMP_HEIGHT" placeholder="身高" value="<?php echo ($base["EMP_HEIGHT"]); ?>"><span class="badge badge-important">厘米</span>
               </div>
              <div class="span5">
                  <label class="control-label" >民&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;族</label>
                  <select class="span2" name="EMP_NATION">
                    <?php if(is_array($nation_list)): $i = 0; $__LIST__ = $nation_list;if( count($__LIST__)==0 ) : echo "" ;else: foreach($__LIST__ as $key=>$vo): $mod = ($i % 2 );++$i;?><option value="<?php echo ($vo["CODE"]); ?>" <?php  if($base["EMP_NATION"]==$vo["CODE"]) echo "selected"; ?>><?php echo ($vo["NAME"]); ?></option><?php endforeach; endif; else: echo "" ;endif; ?>
                  </select>
                  
             </div>
        </div>

         <div class="row">
               <div class="span4">
                  <label class="control-label" for="EMP_NATIVE">籍贯</label>
                     <input type="text" id="EMP_NATIVE" name="EMP_NATIVE" placeholder="籍贯" value="<?php echo ($base["EMP_NATIVE"]); ?>">
               </div>
              <div class="span5">
                  <label class="control-label" >婚&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;否</label>
                  
                   
                      <?php  if($base["EMP_MARRAGE"]==1){ echo "<label class='radio'> <input type='radio' name='EMP_MARRAGE' id='optionsRadios1' value='1' checked >是 </label>"; echo "<label class='radio'><input type='radio' name='EMP_MARRAGE' id='optionsRadios2' value='0'  >否</label>"; }else{ echo "<label class='radio'> <input type='radio' name='EMP_MARRAGE' id='optionsRadios1' value='1'  >是 </label>"; echo "<label class='radio'><input type='radio' name='EMP_MARRAGE' id='optionsRadios2' value='0' checked >否</label>"; } ?>
                   
                    
                  
                  
                  
             </div>
        </div>

     <div class="row">
                <div class="span9">
                    <label class="control-label" for="EMP_RESIDENCE">户口</label>
                    <input type="text" id="EMP_RESIDENCE" name="EMP_RESIDENCE" class="span6" placeholder="户口所在地" value="<?php echo ($base["EMP_RESIDENCE"]); ?>">
                </div>
     </div>

    <div class="row">
                <div class="span9">
                    <label class="control-label" for="EMP_ADDRESS">住址</label>
                    <input type="text" id="EMP_ADDRESS" name="EMP_ADDRESS" class="span6" placeholder="现住址" value="<?php echo ($base["EMP_ADDRESS"]); ?>">
                </div>
     </div>

        <div class="row">
               <div class="span4">
                  <label class="control-label" >子女</label>

                    <?php  if($base["EMP_HAVECHILD"]==1){ echo "<label class='radio'> <input type='radio' name='EMP_HAVECHILD' id='optionsRadios1' value='1' checked >有 </label>"; echo "<label class='radio'><input type='radio' name='EMP_HAVECHILD' id='optionsRadios2' value='0'  >无</label>"; }else{ echo "<label class='radio'> <input type='radio' name='EMP_HAVECHILD' id='optionsRadios1' value='1'  >有 </label>"; echo "<label class='radio'><input type='radio' name='EMP_HAVECHILD' id='optionsRadios2' value='0' checked >无</label>"; } ?>
                </div>
              <div class="span5">
                   <label class="control-label" >政治面貌</label>

                   <select class="span2" name="EMP_POLITI">
                    <?php if(is_array($politics_list)): $i = 0; $__LIST__ = $politics_list;if( count($__LIST__)==0 ) : echo "" ;else: foreach($__LIST__ as $key=>$vo): $mod = ($i % 2 );++$i;?><option value="<?php echo ($vo["CODE"]); ?>" <?php  if($base["EMP_POLITI"]==$vo["CODE"]) echo "selected"; ?> ><?php echo ($vo["NAME"]); ?></option><?php endforeach; endif; else: echo "" ;endif; ?>
                   </select>
                  
             </div>
        </div>

        <div class="row">
               <div class="span4">
                    <label class="control-label" for="EMP_PHONE">手机</label>
                    <input type="text" id="EMP_PHONE" name="EMP_PHONE"  placeholder="联系方式" value="<?php echo ($base["EMP_PHONE"]); ?>">
               </div>
              <div class="span5">
                    <label class="control-label" for="EMP_LANGUAGE">外语程度</label>
                    <input type="text" id="EMP_LANGUAGE" name="EMP_LANGUAGE" placeholder="外语程度" value="<?php echo ($base["EMP_LANGUAGE"]); ?>">
              </div>
        </div>

    <div class="row">
                <div class="span9">
                    <label class="control-label" for="EMP_COLLEGE">院校</label>
                    <input type="text" id="EMP_COLLEGE" name="EMP_COLLEGE" class="span6" placeholder="毕业院校" value="<?php echo ($base["EMP_COLLEGE"]); ?>">
                </div>
     </div>

        <div class="row">
               <div class="span4">
                    <label class="control-label" for="EMP_EDU">学历</label>
                    <select class="span2" name="EMP_EDU">
                      <?php if(is_array($education_list)): $i = 0; $__LIST__ = $education_list;if( count($__LIST__)==0 ) : echo "" ;else: foreach($__LIST__ as $key=>$vo): $mod = ($i % 2 );++$i;?><option value="<?php echo ($vo["CODE"]); ?>" <?php  if($base["EMP_EDU"]==$vo["CODE"]) echo "selected"; ?> ><?php echo ($vo["NAME"]); ?></option><?php endforeach; endif; else: echo "" ;endif; ?>
                   </select>
               </div>
              <div class="span5">
                    <label class="control-label" for="EMP_PROFESSION">专&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;业</label>
                    <input type="text" id="EMP_PROFESSION" name="EMP_PROFESSION" placeholder="专业" value="<?php echo ($base["EMP_PROFESSION"]); ?>">
              </div>
        </div>

        <div class="row">
               <div class="span4">
                    <label class="control-label" for="EMP_TITLE">职称</label>
                    <input type="text" id="EMP_TITLE" name="EMP_TITLE"  placeholder="职称" value="<?php echo ($base["EMP_TITLE"]); ?>">
               </div>
              <div class="span5">
                    <label class="control-label" for="EMP_EXPSALARY">期望薪资</label>
                    <div class="input-prepend">
                    <span class="add-on">￥</span>
                    <input type="text" class="span2" id="EMP_EXPSALARY" name="EMP_EXPSALARY" placeholder="期望薪资" value="<?php echo ($base["EMP_EXPSALARY"]); ?>">
                  </div><span class="label label-important">(元/月)</span>
              </div>
        </div>

          <div class="row">
               <div class="span9">
                  <label class="control-label" for="EMP_CERTIFICATE">证书</label>
                      <textarea rows="3" class="span7" id="EMP_CERTIFICATE" name="EMP_CERTIFICATE" placeholder="资格证书"><?php  echo trim($base["EMP_CERTIFICATE"],"");?>
                      </textarea>
               </div>
          </div>
          <div class="row">
              <div class="span5">
                  <label class="control-label" >是否有亲属在公司(集团)</label>

                  <?php  if($base["EMP_HAVERELATIVE"]==1){ echo "<label class='radio'> <input type='radio' name='EMP_HAVERELATIVE' id='optionsRadios1' value='1' onclick='enablerelative()' checked >有</label>"; echo "<label class='radio'><input type='radio' name='EMP_HAVERELATIVE' id='radio_realtive' value='0' onclick='relativechange()' >无</label>"; }else{ echo "<label class='radio'> <input type='radio' name='EMP_HAVERELATIVE' id='optionsRadios1' value='1' onclick='enablerelative()' >有 </label>"; echo "<label class='radio'><input type='radio' name='EMP_HAVERELATIVE' id='radio_realtive' value='0' onclick='relativechange()' checked >无</label>"; } ?>
                  <input type="text" class="span2" id="EMP_RELATIVENAME" name="EMP_RELATIVENAME" placeholder="亲属姓名" value="<?php echo ($base["EMP_RELATIVENAME"]); ?>" disabled>
              </div>
        </div>
     <div class="row">
                <div class="span9 offset3">
                    <button type="submit" class="btn">保存</button>
                </div>
     </div><?php endforeach; endif; else: echo "" ;endif; ?>
  </form>
          </section>
      



<form class="form-inline" id="emerge-form" method="post" action="__URL__/addemerge" enctype="multipart/form-data">
  <section class="download" id="t2">
    <div class="page-header">
    <blockquote>
    <p>(二)紧急事件联络人</p>
    </blockquote>
   </div>

  <div class="row">
     <div class="span4">
          <label class="control-label" for="EMP_EMERGE_NAME">姓名</label>
          <input type="text" id="EMP_EMERGE_NAME" name="EMP_EMERGE_NAME"  placeholder="姓名" value="<?php echo ($base["EMP_EMERGE_NAME"]); ?>">
     </div>
    <div class="span5">
          <label class="control-label" for="EMP_EMERGE_PHONE">电话</label>
          <input type="text"  id="EMP_EMERGE_PHONE" name="EMP_EMERGE_PHONE" placeholder="联系电话" value="<?php echo ($base["EMP_EMERGE_PHONE"]); ?>">
    </div>
  </div>


  <div class="row">
     <div class="span4">
          <label class="control-label" for="EMP_EMERGE_ADDRESS">地址</label>
          <input type="text" id="EMP_EMERGE_ADDRESS" name="EMP_EMERGE_ADDRESS"  placeholder="通讯地址" value="<?php echo ($base["EMP_EMERGE_ADDRESS"]); ?>">
     </div>
    <div class="span5">
          <label class="control-label" for="EMP_EMERGE_MAILCODE">邮编</label>
          <input type="text"  id="EMP_EMERGE_MAILCODE" name="EMP_EMERGE_MAILCODE" placeholder="邮编" value="<?php echo ($base["EMP_EMERGE_MAILCODE"]); ?>">
    </div>
  </div>

  <div class="row">
    <div class="span9 offset3">
      <button type="submit" class="btn">保存</button>
    </div>
  </div>


  </section>
</form>


  <section class="download" id="t3">
    <div class="page-header">
    <blockquote>
    <p>(三)教育经历（高中/中专起）</p>
    </blockquote>
    </div>
  <div class="row">
    <div class="span9">
      <table class="table table-striped">
        <thead>
                <tr>
                  <th>#</th>
                  <th>学校名称</th>
                  <th>起止时间</th>
                  <th>学历</th>
                  <th>专业</th>
                  <th>操作时间</th>
                  <th>操作</th>
                </tr>
              </thead>
              <tbody>
                <?php if(is_array($school_infor)): $i = 0; $__LIST__ = $school_infor;if( count($__LIST__)==0 ) : echo "" ;else: foreach($__LIST__ as $key=>$vo): $mod = ($i % 2 );++$i;?><tr>
                      <td><?php echo ($vo["ID"]); ?></td>
                      <td><?php echo ($vo["SCHOOL_NAME"]); ?></td>
                      <td><?php echo ($vo["BEGINANDEND_TIME"]); ?></td>
                      <td><?php echo ($vo["EMP_EDU"]); ?></td>
                      <td><?php echo ($vo["EMP_PROFESSION"]); ?></td>
                      <td><?php echo ($vo["OPERTIME"]); ?></td>
                       <td><a class="btn btn-danger" onclick="delschool('<?php echo ($vo["ID"]); ?>')">删除</a></td>
                    </tr><?php endforeach; endif; else: echo "" ;endif; ?>
              </tbody>
      </table>
    </div>
  </div>
  <div class="row">
    <div class="span9">
         <a id="modal-240037" href="#modal-container-240037" role="button" class="btn btn-success" data-toggle="modal">新增教育经历</a>
        
        <div id="modal-container-240037" class="modal hide fade" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
          <div class="modal-header">
             <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h3 id="myModalLabel">
              教育经历
            </h3>
          </div>
      <form id="school-form" method="post" action="__URL__/addschool" enctype="multipart/form-data">
          <div class="modal-body">
                <div class="span9">
                    <label class="control-label" for="SCHOOL_NAME">学校名称</label>
                    <input type="text" id="SCHOOL_NAME" name="SCHOOL_NAME"  placeholder="学校名称">
               </div>
              <div class="span9">
                    <label class="control-label" for="SCHOOL_BEGINANDEND_TIME">起止时间</label>
                    <input type="text"  id="SCHOOL_BEGINANDEND_TIME" name="SCHOOL_BEGINANDEND_TIME" placeholder="起止时间">
              </div>
              <div class="span9">
                    <label class="control-label" for="SCHOOL_EMP_EDU">学&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;历</label>
                    <input type="text" id="SCHOOL_EMP_EDU" name="SCHOOL_EMP_EDU"  placeholder="学历">
               </div>
              <div class="span9">
                    <label class="control-label" for="SCHOOL_EMP_PROFESSION">专&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;业</label>
                    <input type="text"  id="SCHOOL_EMP_PROFESSION" name="SCHOOL_EMP_PROFESSION" placeholder="专业">
              </div>
          </div>
          <div class="modal-footer">
             <button class="btn" data-dismiss="modal" id="close_school" aria-hidden="true">关闭</button> <button  type="submit" class="btn btn-primary">新增</button>
          </div>
      </form>
        </div>
      </div>

  </div>
  </section>



  <section class="download" id="t4">
    <div class="page-header">
    <blockquote>
    <p>(四)培训经历</p>
    </blockquote>
  </div>
  <div class="row">
    <div class="span9">
      <table class="table table-striped">
        <thead>
                <tr>
                  <th>#</th>
                  <th>培训内容</th>
                  <th>起止日期</th>
                  <th>培训地点</th>
                  <th>培训目的</th>
                  <th>操作时间</th>
                  <th>操作</th>
                </tr>
              </thead>
              <tbody>
               <?php if(is_array($train_infor)): $i = 0; $__LIST__ = $train_infor;if( count($__LIST__)==0 ) : echo "" ;else: foreach($__LIST__ as $key=>$vo): $mod = ($i % 2 );++$i;?><tr>
                    <td><?php echo ($vo["ID"]); ?></td>
                    <td><?php echo ($vo["TRAIN_TITLE"]); ?></td>
                    <td><?php echo ($vo["BEGINANDEND_TIME"]); ?></td>
                    <td><?php echo ($vo["TRAIN_ADDRESS"]); ?></td>
                    <td><?php echo ($vo["TRAIN_PURPOSE"]); ?></td>
                    <td><?php echo ($vo["OPERTIME"]); ?></td>
                    <td><a class="btn btn-danger" onclick="deltrain('<?php echo ($vo["ID"]); ?>')">删除</a></td>
                  </tr><?php endforeach; endif; else: echo "" ;endif; ?>
                
              </tbody>
      </table>   
    </div>
  </div>
  <div class="row">
    <div class="span9">
         <a id="modal-pxjl" href="#modal-container-pxjl" role="button" class="btn btn-success" data-toggle="modal">新增培训经历</a>
        
        <div id="modal-container-pxjl" class="modal hide fade" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
          <div class="modal-header">
             <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h3 id="myModalLabel">
              培训经历
            </h3>
          </div>
      <form id="train-form" method="post" action="__URL__/addtrain" enctype="multipart/form-data">
        <div class="modal-body">
              <div class="span9">
                  <label class="control-label" for="TRAIN_TITLE">培训内容</label>
                  <input type="text" id="TRAIN_TITLE" name="TRAIN_TITLE"  placeholder="培训内容">
             </div>
            <div class="span9">
                  <label class="control-label" for="TRAIN_BEGINANDEND_TIME">起止时间</label>
                  <input type="text"  id="TRAIN_BEGINANDEND_TIME" name="TRAIN_BEGINANDEND_TIME" placeholder="起止时间">
            </div>
            <div class="span9">
                  <label class="control-label" for="TRAIN_ADDRESS">培训地点</label>
                  <input type="text" id="TRAIN_ADDRESS" name="TRAIN_ADDRESS"  placeholder="培训地点">
             </div>
            <div class="span9">
                  <label class="control-label" for="TRAIN_PURPOSE">培训目的</label>
                  <input type="text"  id="TRAIN_PURPOSE" name="TRAIN_PURPOSE" placeholder="培训目的">
            </div>
        </div>
        <div class="modal-footer">
           <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button> <button type="submit" class="btn btn-primary">新增</button>
        </div>
    </form>
        </div>
      </div>
    </div>

  </section>


  <section class="download" id="t5">
    <div class="page-header">
    <blockquote>
    <p>(五)工作经历</p>
    </blockquote>
   </div>
  <div class="row">
    <div class="span9">
      <table class="table table-striped">
        <thead>
                <tr>
                  <th>#</th>
                  <th>工作单位</th>
                  <th>起止时间</th>
                  <th>所在部门及岗位</th>
                  <th>薪资</th>
                  <th>证明人及电话</th>
                  <th>离职原因</th>
                  <th>操作时间</th>
                  <th>操作</th>
                </tr>
              </thead>
              <tbody>
              <?php if(is_array($job_infor)): $i = 0; $__LIST__ = $job_infor;if( count($__LIST__)==0 ) : echo "" ;else: foreach($__LIST__ as $key=>$vo): $mod = ($i % 2 );++$i;?><tr>
                    <td><?php echo ($vo["ID"]); ?></td>
                    <td><?php echo ($vo["JOB_COMPANY"]); ?></td>
                    <td><?php echo ($vo["BEGINANDEND_TIME"]); ?></td>
                    <td><?php echo ($vo["DEPARTANDPOST"]); ?></td>
                    <td><?php echo ($vo["JOB_SALARY"]); ?></td>
                    <td><?php echo ($vo["JOB_PROOF_PERSONANDTEL"]); ?></td>
                    <td><?php echo ($vo["LEAVE_REASON"]); ?></td>
                    <td><?php echo ($vo["OPERTIME"]); ?></td>
                    <td><a class="btn btn-danger" onclick="deljob('<?php echo ($vo["ID"]); ?>')">删除</a></td>
                  </tr><?php endforeach; endif; else: echo "" ;endif; ?>
              </tbody>
      </table>
    </div>
  </div>
  <div class="row">
    <div class="span9">
         <a id="modal-gzjl" href="#modal-container-gzjl" role="button" class="btn btn-success" data-toggle="modal">新增工作经历</a>
        
        <div id="modal-container-gzjl" class="modal hide fade" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
          <div class="modal-header">
             <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h3 id="myModalLabel">
              工作经历
            </h3>
          </div>
      <form id="job-form" method="post" action="__URL__/addjob" enctype="multipart/form-data">
          <div class="modal-body">
                <div class="span9">
                    <label class="control-label" for="JOB_COMPANY">工作单位</label>
                    <input type="text" id="JOB_COMPANY" name="JOB_COMPANY"  placeholder="工作单位">
               </div>
              <div class="span9">
                    <label class="control-label" for="JOB_BEGINANDEND_TIME">起止时间</label>
                    <input type="text"  id="JOB_BEGINANDEND_TIME" name="JOB_BEGINANDEND_TIME" placeholder="起止时间">
              </div>
              <div class="span9">
                    <label class="control-label" for="DEPARTANDPOST">所在部门及岗位</label>
                    <input type="text" id="DEPARTANDPOST" name="DEPARTANDPOST"  placeholder="所在部门及岗位">
               </div>
              <div class="span9">
                    <label class="control-label" for="JOB_SALARY">薪资</label>
                    <div class="input-prepend">
                    <span class="add-on">￥</span>
                    <input type="text"  id="JOB_SALARY" name="JOB_SALARY" class="span2" placeholder="薪资"></div><span class="label label-important">(元/月)</span>
              </div>
              <div class="span9">
                  <label class="control-label" for="JOB_PROOF_PERSONANDTEL">证明人及电话</label>
                  <input type="text" id="JOB_PROOF_PERSONANDTEL" name="JOB_PROOF_PERSONANDTEL"  placeholder="证明人及电话">
             </div>
            <div class="span9">
                  <label class="control-label" for="LEAVE_REASON">离职原因</label>
                  <input type="text"  id="LEAVE_REASON" name="LEAVE_REASON" placeholder="离职原因">
            </div>
          </div>
          <div class="modal-footer">
             <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button> <button type="submit" class="btn btn-primary">新增</button>
          </div>
    </form>
        </div>
      </div>
  </div>
  </section>



  <section class="download" id="t6">
    <div class="page-header">
    <blockquote>
    <p>(六)家庭成员</p>
    </blockquote>
    </div>
  <div class="row">
    <div class="span9">
      <table class="table table-striped">
        <thead>
                <tr>
                  <th>#</th>
                  <th>姓名</th>
                  <th>关系</th>
                  <th>年龄</th>
                  <th>工作单位</th>
                  <th>电话</th>
                  <th>操作时间</th>
                  <th>操作</th>
                </tr>
              </thead>
              <tbody>
              <?php if(is_array($family_infor)): $i = 0; $__LIST__ = $family_infor;if( count($__LIST__)==0 ) : echo "" ;else: foreach($__LIST__ as $key=>$vo): $mod = ($i % 2 );++$i;?><tr>
                  <td><?php echo ($vo["ID"]); ?></td>
                  <td><?php echo ($vo["FAMILY_NAME"]); ?></td>
                  <td><?php echo ($vo["FAMILY_RELATION"]); ?></td>
                  <td><?php echo ($vo["AGE"]); ?></td>
                  <td><?php echo ($vo["COMPANY"]); ?></td>
                  <td><?php echo ($vo["TEL"]); ?></td>
                  <td><?php echo ($vo["OPERTIME"]); ?></td>
                  <td><a class="btn btn-danger" onclick="delfamily('<?php echo ($vo["ID"]); ?>')">删除</a></td>
                </tr><?php endforeach; endif; else: echo "" ;endif; ?>
              </tbody>
      </table>
    </div>
  </div>
  <div class="row">
    <div class="span9">
         <a id="modal-jtcy" href="#modal-container-jtcy" role="button" class="btn btn-success" data-toggle="modal">新增家庭成员</a>
        
        <div id="modal-container-jtcy" class="modal hide fade" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
          <div class="modal-header">
             <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h3 id="myModalLabel">
              家庭成员
            </h3>
          </div>
        <form id="family-form" method="post" action="__URL__/addfamily" enctype="multipart/form-data">
          <div class="modal-body">
                <div class="span9">
                    <label class="control-label" for="FAMILY_NAME">姓名</label>
                    <input type="text" id="FAMILY_NAME" name="FAMILY_NAME"  placeholder="姓名">
               </div>
              <div class="span9">
                    <label class="control-label" for="FAMILY_RELATION">关系</label>
                    <input type="text"  id="FAMILY_RELATION" name="FAMILY_RELATION" placeholder="关系">
              </div>
              <div class="span9">
                    <label class="control-label" for="FAMILY_AGE">年龄</label>
                    <input type="text" id="FAMILY_AGE" name="FAMILY_AGE"  placeholder="年龄">
               </div>
              <div class="span9">
                    <label class="control-label" for="FAMILY_COMPANY">工作单位</label>
                    <input type="text"  id="FAMILY_COMPANY" name="FAMILY_COMPANY" placeholder="工作单位">
              </div>
              <div class="span9">
                  <label class="control-label" for="FAMILY_TEL">电话</label>
                  <input type="text" id="FAMILY_TEL" name="FAMILY_TEL"  placeholder="电话">
             </div>

          </div>
          <div class="modal-footer">
             <button class="btn" data-dismiss="modal" aria-hidden="true">关闭</button> <button type="submit" class="btn btn-primary">新增</button>
          </div>
      </form>
        </div>
    </div>
  </div>
  </section>



<form class="form-inline" id="myself-form" method="post" action="__URL__/addmyself" enctype="multipart/form-data">
  <section class="download" id="t7">
    <div class="page-header">
    <blockquote>
    <p>(七)性格特点及自我评价</p>
    </blockquote>
   </div>
  <div class="row">
    <div class="span9">
      <label><textarea  name="EMP_OTHERS" id="EMP_OTHERS" class="span9" row="10" style="height:200px"><?php  echo trim($base["EMP_OTHERS"],"");?></textarea></label>   
    </div>
  </div>
  <div class="row">
    <div class="span9 offset3">
      <button type="submit" class="btn">保存</button>
    </div>
  </div>
  </section>
</form>


<form class="form-inline">
  <section class="download" id="t8">
    <blockquote>
    <p>(八)诚信承诺</p>
    </blockquote>
  <div class="row">
    <div class="span9">
      <label>求职声明：<br />
1、本人现谨声明，在此表内所陈述全部资料确属事实，谨此授权贵公司查询有关事项，并清楚如任何一项情况失实，是严重违反贵公司规章制度的行为，贵公司任何时候都有权解除本人受聘之职或采取其他处理方式处理。<br />
2、本人已获知贵公司有关管理规定，能按公司规定勤奋工作；若本人违反公司有关规定，自愿接受公司处理。<br />
3、本人所交资料离职时均不带走，交公司存档。
</label> 
<?php
 if($emp_submitflag[0]["FLAG"]=="7"&&$base_infor[0]["STATE"]=="0") { echo "<button type='button' class='btn btn-danger offset3' onclick='updatestate();' >提交审核</button>"; }else if($emp_submitflag[0]["FLAG"]!="7"&&$base_infor[0]["STATE"]=="0"){ echo "<span class='label label-success'>请填写完毕个人信息,以启用该按钮</span><button type='button' class='btn btn-danger' onclick='updatestate();' disabled >提交审核</button>"; }else if($emp_submitflag[0]["FLAG"]=="7"&&$base_infor[0]["STATE"]!="0"){ echo "<span class='label label-success offset3'>修改个人信息,保存以后及时生效</span>"; } ?> 
    </div>
  </div>

  </section>
</form>
         

      </div>
    </div>

  </div>
  </div>

  </div>





    <!-- Le javascript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->

    <script src="__PUBLIC__/public/assets/js/jquery.min.js"></script>
    <script src="__PUBLIC__/public/assets/js/jquery.unveil.min.js"></script>
    <script src="__PUBLIC__/public/assets/js/bootstrap.min.js"></script>
    <script src="__PUBLIC__/public/assets/js/bootstro.min.js"></script>
    <script src="__PUBLIC__/public/assets/js/prettify.js"></script>

  <script src="__PUBLIC__/public/assets/js/jquery.scrollUp.min.js"></script>
    <script>
      $(document).ready(function(){
        $("img.lazy").unveil();
        
             $("#start-intro").click(function(){
                bootstro.start();    
            });

             $.scrollUp({
                  scrollName: 'scrollUp', // Element ID
                  topDistance: '300', // Distance from top before showing element (px)
                  topSpeed: 300, // Speed back to top (ms)
                  animation: 'fade', // Fade, slide, none
                  animationInSpeed: 200, // Animation in speed (ms)
                  animationOutSpeed: 200, // Animation out speed (ms)
                  scrollText: '', // Text for element
                  activeOverlay: false  // Set CSS color to display scrollUp active point, e.g '#00FFFF'
            });
          });
    </script>

    
    <script src="__PUBLIC__/public/assets/js/application.js"></script>
  </body>
</html>


    <!-- Footer
    ================================================== -->
    <footer class="footer">
      <div class="container">        
        <p><a href="#" >Copyright</a><a href="#" >锦艺集团© 版权所有<br /> Power By 集团综合管理部</a>.</p>             
      </div>
    </footer>

  </body>
</html>