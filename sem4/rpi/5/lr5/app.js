const express = require("express");
   
const app = express();
   
// создаем парсер для данных 
const urlencodedParser = express.urlencoded({extended: false});

let result ; 
  
app.get("/", function (request, response) {
    response.sendFile(__dirname + "/index.html");
});
app.post("/", urlencodedParser, function (request, response) {
    if(!request.body) return response.sendStatus(400);
    console.log(request.body);

    // для переключателей
    result = Number(request.body.question1);
    // для флажков
    if(request.body.question21 == "1" && request.body.question22 == "1") result ++;

    response.send(`Привет ${request.body.userName} из ${request.body.userGroup} --- твой результат  ${result} из 2`);
});
   
app.listen(3000, ()=>console.log("Сервер запущен..."));