<html>
    <head>

    </head>
    <body>
        <?php
            $logins = array("Ivan", "Petr_php", "Lesha_php", "Sasha_php");
            if(isset($_POST["login"])){
                if(in_array($_POST["login"], $logins)){
                    echo "Здравствуйте, ".$_POST["login"];
                }
                else{
                    echo "вы не зарегестрированый пользователь";
                }
            }
        ?>
    </body>
</html>
