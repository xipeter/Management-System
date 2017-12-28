<?php
return array(
		//'配置项'=>'配置值'
	'DB_TYPE' => 'Oracle', // 数据库类型
	'DB_HOST' => '1.192.159.59', // 服务器地址
	// 'DB_HOST' => 'localhost', // 服务器地址
	'DB_NAME' => '(DESCRIPTION =
    (ADDRESS = (PROTOCOL = TCP)(HOST = 1.192.159.59)(PORT = 1521))
    (CONNECT_DATA =
      (SERVER = DEDICATED)
      (SERVICE_NAME = orcl)
    )
  )', // 数据库名
	'DB_USER' => 'jinyi', // 用户名
	'DB_PWD' => 'jinyi', // 密码
		// 'DB_PORT' => '5896', // 端口
	'DB_PORT' => '1521', // 端口
	'db_prefix'=>'',
	'USER_NAME'=>'USER_NAME',
	'USER_AUTH_KEY'=>'USER_AUTH_KEY',
	
	
	'TMPL_CACHE_ON'=>false,
	'TMPL_PARSE_STRING'=>array('__PUBLIC__'=>'/mms/hr'),
	'TOKEN_ON'=>true,  // 是否开启令牌验证
    'TOKEN_NAME'=>'__hash__',    // 令牌验证的表单隐藏字段名称
    'TOKEN_TYPE'=>'md5',  //令牌哈希验证规则 默认为MD5
    'TOKEN_RESET'=>true,  //令牌验证出错后是否重置令牌 默认为true
);
?>