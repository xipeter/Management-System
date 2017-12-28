<?php
/**
 * Login
 *
 * @package default
 * @author Gao Dongming
 */
class PublicAction extends Action{
   public function verify(){
        import('ORG.Util.Image');
        ob_end_clean(); 
        Image::buildImageVerify();
     }
}

?>
