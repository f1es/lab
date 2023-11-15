<?php
	session_start(); //стартуем сессию

	//Если есть данные в сессии об имени пользователя:
	if (!empty($_SESSION['username'])) {
		echo $_SESSION['username']; //выведем имя на экран
	}
?>