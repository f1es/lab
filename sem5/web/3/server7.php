<html>
    <head>

    </head>
    <body>
        <?php
            if(isset($_POST["operation"])){
                echo $_POST["operation"]."<br>";
            }
            if(!isset($_POST["number"])){
                echo "you don't enter number";
                exit();
            }
            else{
                echo "number: ".$_POST["number"]."<br>";
            }
            for($i = 1;$i <= $_POST["number"];$i++){
                switch ($_POST["operation"]){
                    case "Even":
                        if($i % 2 == 0){
                            echo $i."<br>";
                        }
                        break;
                    case "Odd":
                        if($i % 2 != 0){
                            echo $i."<br>";
                        }
                        break;
                    case "Prime":
                        if(IsPrime($i)){
                            echo $i."<br>";
                        }
                        break;
                    case "Composite":
                        if(!IsPrime($i)){
                            echo $i."<br>";
                        }
                        break;
                }
            }
            
        ?>
        <?php
        function IsPrime($number){
            $i = 0;
            if($number == 1){
                return true;
            }
            for($j = 1;$j <= $number;$j++){
                if($number % $j == 0){
                    $i++;
                }
            }
            if($i == 2){
                return true;
            }
            else{
                return false;
            }
        }
        ?>
    </body>
</html>
