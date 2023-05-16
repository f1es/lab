const express = require("express");

const app = express();

// создаем парсер для данных 
const urlencodedParser = express.urlencoded({ extended: false });

let result;

app.get("/", function (request, response) {
    response.sendFile(__dirname + "/index.html");
});
app.post("/", urlencodedParser, function (request, response) {
    if (!request.body) return response.sendStatus(400);
    console.log(request.body);

    let result = 0;
    // для переключателей
    result += Number(request.body.question1);
    // для флажков
    if (request.body.question21 == "1" && request.body.question22 == "1") result++;
    result += Number(request.body.question3);
    result += Number(request.body.question4);
    result += Number(request.body.question5);
    result += Number(request.body.question6);
    if (request.body.question71 == "1" && request.body.question72 == "1") result++;
    result += Number(request.body.question8);
    result += Number(request.body.question9);
    result += Number(request.body.question10);

    response.send(`Привет ${request.body.userName} из ${request.body.userGroup} --- твой результат  ${result} из 10`);
});

app.listen(3000, () => console.log("Сервер запущен..."));