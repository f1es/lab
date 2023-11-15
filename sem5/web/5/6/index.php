<form action="" method="GET">
	<input type="text" name="username">
	<input type="submit">
</form>

<?php
	if (!empty($_GET['username'])) {
		session_start(); //стартуем сессию
		$_SESSION['username'] = $_GET['username']; //пишем в сессию
	}
?>