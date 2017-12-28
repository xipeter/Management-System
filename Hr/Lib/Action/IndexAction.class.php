<?php
/**
 * Login
 *
 * @package default
 * @author xizf 20140920
 */
class IndexAction extends Action{
   public function index(){
        $this->display();
   }
   public function checklogin()
	{
		$username = $_POST['username'];
		$passwd = $_POST['passwd'];	
		$verify = $_POST['verify'];	
		if(session('verify') != md5($_POST['verify'])) 
		{
			$this->error('验证码错误！');
        }
		
		$user = D("com_employee_record");
		//$User->where('id=8')->find();这里的where 语句要注意一下，如果是其他字段的话后面一定要有单引号
		$userinfo = $user->where("user_name ='$username'")->find();
		if(!empty($userinfo))
		{
			if($userinfo['USER_PWD'] == md5($passwd))
			{
     			//exit($userinfo['PASSWD']."<br>".md5($passwd));
				$_SESSION[C('USER_NAME')]=$userinfo['EMP_NAME'];
				$_SESSION[C('USER_AUTH_KEY')]=$userinfo['ID'];
				$this->assign("jumpUrl","__PUBLIC__/index.php/Login/");
				$this->success('登陆成功！');
			}
			else
			{
			   	// exit($userinfo['PASSWD']."<br>".md5($passwd));
				$this->assign("jumpUrl","__APP__/Index/");
				$this->error('密码出错，请重新输入！');
			}		
		}
		else
		{
			$this->assign("jumpUrl","__APP__/Index/");
			$this->error('用户名不存在！');
		}
		
		exit();
		
	}
}

?>
