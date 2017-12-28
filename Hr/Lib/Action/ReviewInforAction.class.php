<?php
// 本类由系统自动生成，仅供测试用途
class ReviewInforAction extends CommonAction {
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
		$data[0]["index"] = "hr.getemplateststate";
		$data[0]["template"] = "emp_state";
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

}