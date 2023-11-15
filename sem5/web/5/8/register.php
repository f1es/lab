<?php
	session_start(); //стартуем сессию

	if(!empty($_SESSION['email']))
		$email = $_SESSION['email'];
	else
		$email = '';
?>

<form action="" method="GET">
	<p>name:<input type="text" name="name"></p>
	<p>surname:<input type="text" name="surname"></p>
	<p>password:<input type = "password" name = "password"></p>
	<p>email:<input type="text" name="email" value="<?php echo $email ?>"></p>
	
	<input type="submit">
</form>