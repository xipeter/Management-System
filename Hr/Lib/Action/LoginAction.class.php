<?php
// 
class LoginAction extends Action {
    public function index(){
    	// $this->redirect('Interviewing/index');
		
		if(!isset($_SESSION[C('USER_AUTH_KEY')]))
		{
			$this->display();
		}
		else
		{
			$this->redirect('BaseInfor/index');
		}
    	
    }
	public function logout()
    {
        if(isset($_SESSION[C('USER_AUTH_KEY')])) 
        {
			unset($_SESSION[C('USER_AUTH_KEY')]);
			unset($_SESSION);
			session_destroy();
            $this->assign("jumpUrl",__APP__.'/Index/');
            $this->success('登出成功！');
        }
        else 
        {
			$this->assign("jumpUrl",__APP__.'/Index/');
            $this->error('已经登出！');
        }
    }
}