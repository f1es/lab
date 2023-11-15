<form action="" method="GET">
	<input type="text" name="email">
	<input type="submit">
</form>

<?php
	if (!empty($_REQUEST['email'])) {
		session_start();
		$_SESSION['email'] = $_REQUEST['email'];
	}
?>