<html>
    <head>

    </head>
    <body>
    <?php
    $login = "не определён";
    $password = "не определён";
    if(isset($_POST["login"])){
        if($_POST["login"] != ""){
            $login = $_POST["login"];
        }
        else{
            echo '<script type="text/javascript">alert("login не был введен")</script>';
        }
    }
        
    if(isset($_POST["password"])){
        if($_POST["password"] != ""){
            $password = $_POST["password"];
        }
        else{
            echo '<script type="text/javascript">alert("password не был введен")</script>';
        }
    }
    echo "login: ".$login."<br>password: ".$password;
?>
    </body>
</html>