<?php
class CommonAction extends Action {
	function _initialize() {
		if(!isset($_SESSION[C('USER_AUTH_KEY')])) {
		$this->assign("jumpUrl",__APP__.'/Index/');
        $this->error('您还没有登录，请您登陆后进行访问');
		}
		
	    
	}

}
?>