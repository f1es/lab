<html>
    <head>

    </head>
    <body>
    <?php
    $login = "не определён";
    $password = "не определён";
    if(isset($_POST["login"])){
        if($_POST["login"] != "admin"){
            echo "login isn't admin";
            exit();
        }
        $login = $_POST["login"];
    }
        
    if(isset($_POST["password"])){
        if($_POST["password"] != "12345"){
            echo "wrong password";
            exit();
        }
        $password = $_POST["password"];
    }
    echo "login: ".$login."<br>password: ".$password;
?>
    </body>
</html>