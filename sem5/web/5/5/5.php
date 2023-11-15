<?php
		session_start();
        if (!isset($_SESSION['count'])) {
            $_SESSION['count'] = 0;
          } else {
            $_SESSION['count']++;
          }
        $update=$_SESSION['count'];
        if ($update==0) 
        {
            echo "Вы еще не обновляли страницу" . '<br>';
        }
        else
        {
            echo "Вы обновили эту страницу ".$update." раз. ";
        }
?>
