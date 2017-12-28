<?php
// 本类由系统自动生成，仅供测试用途
class BaseInforAction extends CommonAction {
    public function index(){
    	// $this->redirect('Interviewing/index');
    	function format() {     
   
		 $args = func_get_args();    
			
		 if (count($args) == 0) { return;}    
			
		 if (count($args) == 1) { return $args[0]; } 
			  
		 $str = array_shift($args);      
			  
		 $str = preg_replace_callback('/\\{(0|[1-9]\\d*)\\}/', create_function('$match', '$args = '.var_export($args, true).'; return isset($args[$match[1]]) ? $args[$match[1]] : $match[0];'), $str);  
			  
		 return $str;  
  
		}
		//选择项信息加载
		$arr[0]["index"] = "NATION";
		$arr[0]["template"] = "nation_list";
		$arr[1]["index"] = "POLITICS";
		$arr[1]["template"] = "politics_list";
		$arr[2]["index"] = "EDUCATION";
		$arr[2]["template"] = "education_list";
		for ($i=0; $i <sizeof($arr); $i++) { 
				$temp=new Model();
				$strIndex = $arr[$i]["index"];
				$tempList = $temp->query("select a.code,a.name from com_dictionary a  where a.type ='".$strIndex."' and a.valid_state = 1 order by a.sort_id");
				$this->assign($arr[$i]["template"],$tempList);	
			
		}


		//个人扩展信息加载
		$data[0]["index"] = "hr.getschooinforbyid";
		$data[0]["template"] = "school_infor";
		$data[1]["index"] = "hr.gettraininforbyid";
		$data[1]["template"] = "train_infor";
		$data[2]["index"] = "hr.getjobinforbyid";
		$data[2]["template"] = "job_infor";
		$data[3]["index"] = "hr.getfamilyinforbyid";
		$data[3]["template"] = "family_infor";
		$data[4]["index"] = "hr.getempbaseinfor";
		$data[4]["template"] = "base_infor";
		$data[5]["index"] = "hr.getempinforstatebyid";
		$data[5]["template"] = "empinfor_state";
		$data[6]["index"] = "hr.getsubmitflag";
		$data[6]["template"] = "emp_submitflag";
		for ($i=0; $i <sizeof($data); $i++) { 
				$temp=new Model();
				$empid = $_SESSION[C('USER_AUTH_KEY')];
				$strIndex = $data[$i]["index"];
				$tempList = $temp->query("select b.name from com_sql b where b.id='".$strIndex."'");
				$tempSQL = $tempList[0]['NAME'];
				$tempSQL = format($tempSQL,$empid);
				$res=$temp->query($tempSQL);
				$this->assign($data[$i]["template"],$res);	
			
		}
		$this->display();
		
    	
    }
    //增加基础信息
	public function addbaseinfor(){
		function format() {     
   
		 $args = func_get_args();    
			
		 if (count($args) == 0) { return;}    
			
		 if (count($args) == 1) { return $args[0]; } 
			  
		 $str = array_shift($args);      
			  
		 $str = preg_replace_callback('/\\{(0|[1-9]\\d*)\\}/', create_function('$match', '$args = '.var_export($args, true).'; return isset($args[$match[1]]) ? $args[$match[1]] : $match[0];'), $str);  
			  
		 return $str;  
  
		} 
		$empid = $_SESSION[C('USER_AUTH_KEY')];
		$temp = new Model();
		$strIndex = "hr.updateempbaseinfor";
		$tempList = $temp->query("select b.name from com_sql b where b.id='".$strIndex."'");
		$tempSQL = $tempList[0]['NAME'];
				
		$data[0]=$_POST['EMP_NAME']; //姓名
		$data[1]=$_POST['EMP_IDEN'];//身份证号
		$data[2]=$_POST['EMP_AGE'];//年龄
		$data[3]=$_POST['EMP_SEX'];//性别
		$data[4]=$_POST['EMP_HEIGHT'];//身高
		$data[5]=$_POST['EMP_NATION'];//民族
		$data[6]=$_POST['EMP_NATIVE'];//籍贯
		$data[7]=$_POST['EMP_MARRAGE'];//婚否
		$data[8]=$_POST['EMP_RESIDENCE'];//户口
		$data[9]=$_POST['EMP_ADDRESS'];//住址
		$data[10]=$_POST['EMP_HAVECHILD'];//子女
		$data[11]=$_POST['EMP_POLITI'];//政治面貌
		$data[12]=$_POST['EMP_PHONE'];//手机
		$data[13]=$_POST['EMP_LANGUAGE'];//外语程度
		$data[14]=$_POST['EMP_COLLEGE'];//院校
		$data[15]=$_POST['EMP_EDU'];//学历
		$data[16]=$_POST['EMP_PROFESSION'];//专业
		$data[17]=$_POST['EMP_TITLE'];//职称
		$data[18]=$_POST['EMP_EXPSALARY'];//期望薪资
		$data[19]=$_POST['EMP_CERTIFICATE'];//证书
		$data[20]=$_POST['EMP_HAVERELATIVE'];//是否有亲属在公司
		if(isset($_POST['EMP_RELATIVENAME'])){
			$data[21]=$_POST['EMP_RELATIVENAME'];//亲属姓名

		}else{

			$data[21]="";//亲属姓名
		}
		$data[22] = $empid;//操作人
		$data[23] = $empid;//人员ID
		$tempSQL = format($tempSQL,$data[0],$data[1],$data[2],$data[3],$data[4],$data[5],$data[6],$data[7],$data[8],$data[9],$data[10],$data[11]
			,$data[12],$data[13],$data[14],$data[15],$data[16],$data[17],$data[18],$data[19],$data[20],$data[21],$data[22],$data[23]);
		$res=$temp->execute($tempSQL);
		//更新资料状态
		$temp = new Model();
		$temp->execute("update emp_infor_state b set b.status = '1',b.oper_date = sysdate,b.oper_code = '".$empid."' where b.inforkind = '1' and b.emp_id = '".$empid."'");

		echo $res;
	}

    //增加教育经历
	public function addschool(){
		function format() {     
   
		 $args = func_get_args();    
			
		 if (count($args) == 0) { return;}    
			
		 if (count($args) == 1) { return $args[0]; } 
			  
		 $str = array_shift($args);      
			  
		 $str = preg_replace_callback('/\\{(0|[1-9]\\d*)\\}/', create_function('$match', '$args = '.var_export($args, true).'; return isset($args[$match[1]]) ? $args[$match[1]] : $match[0];'), $str);  
			  
		 return $str;  
  
		} 
		$empid = $_SESSION[C('USER_AUTH_KEY')];
		$temp = new Model();
		$strIndex = "hr.insertschoolinfor";
		$tempList = $temp->query("select b.name from com_sql b where b.id='".$strIndex."'");
		$tempSQL = $tempList[0]['NAME'];
		//增加经历的sql索引hr.insertschoolinfor，更改经历的sql索引hr.updateschoolinfor
		$data[0]=$empid;
		$data[1]=$_POST['SCHOOL_NAME'];
		$data[2]=$_POST['SCHOOL_BEGINANDEND_TIME'];
		$data[3]=$_POST['SCHOOL_EMP_EDU'];
		$data[4]=$_POST['SCHOOL_EMP_PROFESSION'];
		$data[5] = $empid;
		$tempSQL = format($tempSQL,$data[0],$data[1],$data[2],$data[3],$data[4],$data[5]);
		$res=$temp->execute($tempSQL);
		//更新资料状态
		$temp = new Model();
		$temp->execute("update emp_infor_state b set b.status = '1',b.oper_date = sysdate,b.oper_code = '".$empid."' where b.inforkind = '3' and b.emp_id = '".$empid."'");
		echo $res;
	}
	//增加紧急事件
	public function addemerge(){
		function format() {     
   
		 $args = func_get_args();    
			
		 if (count($args) == 0) { return;}    
			
		 if (count($args) == 1) { return $args[0]; } 
			  
		 $str = array_shift($args);      
			  
		 $str = preg_replace_callback('/\\{(0|[1-9]\\d*)\\}/', create_function('$match', '$args = '.var_export($args, true).'; return isset($args[$match[1]]) ? $args[$match[1]] : $match[0];'), $str);  
			  
		 return $str;  
  
		} 
		$empid = $_SESSION[C('USER_AUTH_KEY')];
		$temp = new Model();
		$strIndex = "hr.updateempemergeinfor";
		$tempList = $temp->query("select b.name from com_sql b where b.id='".$strIndex."'");
		$tempSQL = $tempList[0]['NAME'];

		$data[0]=$_POST['EMP_EMERGE_NAME'];
		$data[1]=$_POST['EMP_EMERGE_PHONE'];
		$data[2]=$_POST['EMP_EMERGE_ADDRESS'];
		$data[3]=$_POST['EMP_EMERGE_MAILCODE'];
		$data[4] = $empid;
		$data[5] = $empid;
		$tempSQL = format($tempSQL,$data[0],$data[1],$data[2],$data[3],$data[4],$data[5]);
		$res=$temp->execute($tempSQL);
		//更新资料状态
		$temp = new Model();
		$temp->execute("update emp_infor_state b set b.status = '1',b.oper_date = sysdate,b.oper_code = '".$empid."' where b.inforkind = '2' and b.emp_id = '".$empid."'");
		echo $res;
	}
	
	//增加自我评价
	public function addmyself(){
		function format() {     
   
		 $args = func_get_args();    
			
		 if (count($args) == 0) { return;}    
			
		 if (count($args) == 1) { return $args[0]; } 
			  
		 $str = array_shift($args);      
			  
		 $str = preg_replace_callback('/\\{(0|[1-9]\\d*)\\}/', create_function('$match', '$args = '.var_export($args, true).'; return isset($args[$match[1]]) ? $args[$match[1]] : $match[0];'), $str);  
			  
		 return $str;  
  
		} 
		$empid = $_SESSION[C('USER_AUTH_KEY')];
		$temp = new Model();
		$strIndex = "hr.updateempmyselfinfor";
		$tempList = $temp->query("select b.name from com_sql b where b.id='".$strIndex."'");
		$tempSQL = $tempList[0]['NAME'];

		$data[0]=$_POST['EMP_OTHERS'];
		$data[1] = $empid;
		$data[2] = $empid;
		$tempSQL = format($tempSQL,$data[0],$data[1],$data[2]);
		$res=$temp->execute($tempSQL);
		//更新资料状态
		$temp = new Model();
		$temp->execute("update emp_infor_state b set b.status = '1',b.oper_date = sysdate,b.oper_code = '".$empid."' where b.inforkind = '7' and b.emp_id = '".$empid."'");
		echo $res;
	}
	public function delschool(){
		$id=$_POST['id'];
		$temp = new Model();
		$res = $temp->execute("delete from emp_edu_infor b where b.id = '".$id."'");
		echo $res;
	}
	//增加培训经历
	public function addtrain(){
		function format() {     
   
		 $args = func_get_args();    
			
		 if (count($args) == 0) { return;}    
			
		 if (count($args) == 1) { return $args[0]; } 
			  
		 $str = array_shift($args);      
			  
		 $str = preg_replace_callback('/\\{(0|[1-9]\\d*)\\}/', create_function('$match', '$args = '.var_export($args, true).'; return isset($args[$match[1]]) ? $args[$match[1]] : $match[0];'), $str);  
			  
		 return $str;  
  
		} 
		$empid = $_SESSION[C('USER_AUTH_KEY')];
		$temp = new Model();
		$strIndex = "hr.inserttraininfor";
		$tempList = $temp->query("select b.name from com_sql b where b.id='".$strIndex."'");
		$tempSQL = $tempList[0]['NAME'];
		
		$data[0]=$empid;
		$data[1]=$_POST['TRAIN_TITLE'];
		$data[2]=$_POST['TRAIN_BEGINANDEND_TIME'];
		$data[3]=$_POST['TRAIN_ADDRESS'];
		$data[4]=$_POST['TRAIN_PURPOSE'];
		$data[5] = $empid;
		$tempSQL = format($tempSQL,$data[0],$data[1],$data[2],$data[3],$data[4],$data[5]);
		$res=$temp->execute($tempSQL);
		//更新资料状态
		$temp = new Model();
		$temp->execute("update emp_infor_state b set b.status = '1',b.oper_date = sysdate,b.oper_code = '".$empid."' where b.inforkind = '4' and b.emp_id = '".$empid."'");
		echo $res;

	}
	public function deltrain(){
		$id=$_POST['id'];
		$empid = $_SESSION[C('USER_AUTH_KEY')];
		$temp = new Model();
		$res = $temp->execute("delete from emp_train_infor b where b.id = '".$id."'");
		//判断是否删除所有的子项，如果是，将不允许提交
		$arr = $temp->execute("select count(*) num from emp_train_infor b where b.emp_id = '".$empid."'");
		if($arr[0]["NUM"]==0){
			$temp->execute("update emp_infor_state a set a.status = '0' where  a.emp_id ='".$empid."'  and a.inforkind = '4'");
			$temp->execute("update com_employee_record b set b.state = 0 where b.id = '".$empid."'");
		}

		echo $res;
	}
	//更新员工状态
	public function updatestate(){
		$empid = $_SESSION[C('USER_AUTH_KEY')];
		$temp = new Model();
		$res = $temp->execute("update com_employee_record d set d.state = 1 where d.id =  '".$empid."'");
		echo $res;
	}
	//增加工作经历
	public function addjob(){
		function format() {     
   
		 $args = func_get_args();    
			
		 if (count($args) == 0) { return;}    
			
		 if (count($args) == 1) { return $args[0]; } 
			  
		 $str = array_shift($args);      
			  
		 $str = preg_replace_callback('/\\{(0|[1-9]\\d*)\\}/', create_function('$match', '$args = '.var_export($args, true).'; return isset($args[$match[1]]) ? $args[$match[1]] : $match[0];'), $str);  
			  
		 return $str;  
  
		} 
		$empid = $_SESSION[C('USER_AUTH_KEY')];
		$temp = new Model();
		$strIndex = "hr.insertjobinfor";
		$tempList = $temp->query("select b.name from com_sql b where b.id='".$strIndex."'");
		$tempSQL = $tempList[0]['NAME'];
		$data[0]=$empid;
		$data[1]=$_POST['JOB_COMPANY'];
		$data[2]=$_POST['JOB_BEGINANDEND_TIME'];
		$data[3]=$_POST['DEPARTANDPOST'];
		$data[4]=$_POST['JOB_SALARY'];
		$data[5]=$_POST['JOB_PROOF_PERSONANDTEL'];
		$data[6]=$_POST['LEAVE_REASON'];
		$data[7] = $empid;
		$tempSQL = format($tempSQL,$data[0],$data[1],$data[2],$data[3],$data[4],$data[5],$data[6],$data[7]);
		$res=$temp->execute($tempSQL);
		//更新资料状态
		$temp = new Model();
		$temp->execute("update emp_infor_state b set b.status = '1',b.oper_date = sysdate,b.oper_code = '".$empid."' where b.inforkind = '5' and b.emp_id = '".$empid."'");
		echo $res;

	}
	public function deljob(){
		$id=$_POST['id'];
		$temp = new Model();
		$res = $temp->execute("delete from emp_jobhistory_infor b where b.id = '".$id."'");
		echo $res;
	}
	//增加家庭成员
	public function addfamily(){
		function format() {     
   
		 $args = func_get_args();    
			
		 if (count($args) == 0) { return;}    
			
		 if (count($args) == 1) { return $args[0]; } 
			  
		 $str = array_shift($args);      
			  
		 $str = preg_replace_callback('/\\{(0|[1-9]\\d*)\\}/', create_function('$match', '$args = '.var_export($args, true).'; return isset($args[$match[1]]) ? $args[$match[1]] : $match[0];'), $str);  
			  
		 return $str;  
  
		} 
		$empid = $_SESSION[C('USER_AUTH_KEY')];
		$temp = new Model();
		$strIndex = "hr.insertfamilyinfor";
		$tempList = $temp->query("select b.name from com_sql b where b.id='".$strIndex."'");
		$tempSQL = $tempList[0]['NAME'];
		
		$data[0]=$empid;
		$data[1]=$_POST['FAMILY_NAME'];
		$data[2]=$_POST['FAMILY_RELATION'];
		$data[3]=$_POST['FAMILY_AGE'];
		$data[4]=$_POST['FAMILY_COMPANY'];
		$data[5]=$_POST['FAMILY_TEL'];
		$data[6] = $empid;
		$tempSQL = format($tempSQL,$data[0],$data[1],$data[2],$data[3],$data[4],$data[5],$data[6]);
		$res=$temp->execute($tempSQL);
		//更新资料状态
		$temp = new Model();
		$temp->execute("update emp_infor_state b set b.status = '1',b.oper_date = sysdate,b.oper_code = '".$empid."' where b.inforkind = '6' and b.emp_id = '".$empid."'");
		echo $res;
	}
	public function delfamily(){
		$id=$_POST['id'];
		$temp = new Model();
		$res = $temp->execute("delete from emp_family_infor b where b.id = '".$id."'");
		echo $res;
	}
}